using VotingApplication.DTOs.VotersDTO;
using VotingApplication.Entities;
using VotingApplication.Repositories.Intefaces;
using VotingApplication.Services.Interface;
using OpenCvSharp;

namespace VotingApplication.Services.Implemetation
{
    public class VotersService : IVotersService
    {
        private readonly CascadeClassifier faceCascade;
        private readonly IVotersRepository votersRepo;

        public VotersService(CascadeClassifier faceCascade, IVotersRepository votersRepo)
        {
            this.votersRepo = votersRepo;
            var cascadePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "haarcascades", "haarcascade_frontalface_default.xml");
            this.faceCascade = new CascadeClassifier(cascadePath);
        }

        private string SaveFileToUploads(IFormFile file, string uploadDirectory)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("No file uploaded");

            var uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";
            var fullPath = Path.Combine(uploadDirectory, uniqueFileName);

            try
            {
                using var fileStream = new FileStream(fullPath, FileMode.Create);
                file.CopyTo(fileStream);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to save file", ex);
            }

            return uniqueFileName; 
        }




        public void RegisterVoter(RegisterVotersRequestModel request)
        {
            var existingVoterByCard = votersRepo.GetVoter(v => v.VotersCardNumber == request.VotersCardNumber);
            if (existingVoterByCard != null)
            {
                throw new Exception("Voter with this card number already exists.");
            }

            var uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
            if (!Directory.Exists(uploadDir))
                Directory.CreateDirectory(uploadDir);

            var savedFileName = SaveFileToUploads(request.FaceData, uploadDir);
            var fullImagePath = Path.Combine(uploadDir, savedFileName);

            try
            {
                if (IsDuplicateFace(fullImagePath))
                {
                    File.Delete(fullImagePath);
                    throw new InvalidOperationException("Voter with the same face already exists. Duplicate registration is not allowed!");
                }

                var voter = new Voters
                {
                    Name = request.Name,
                    Email = request.Email,
                    Password = request.Password,
                    VotersCardNumber = request.VotersCardNumber,
                    FaceDate = savedFileName,
                    HasVoted = false,
                    VotersId = Guid.NewGuid()
                };

                votersRepo.CreateVoter(voter);
            }
            catch (Exception ex)
            {
                // Cleanup on failure
                if (File.Exists(fullImagePath))
                    File.Delete(fullImagePath);

                throw new InvalidOperationException("Failed to register voter", ex);
            }
        }


        private bool IsDuplicateFace(string newFacePath)
        {
            var newFaceImage = new Mat(newFacePath, ImreadModes.Color);
            if (newFaceImage.Empty())
                throw new InvalidOperationException("Could not read the new face image");

            var newGrayImage = new Mat();
            Cv2.CvtColor(newFaceImage, newGrayImage, ColorConversionCodes.BGR2GRAY);

            var newFaceRect = faceCascade.DetectMultiScale(newGrayImage, 1.1, 3, HaarDetectionTypes.ScaleImage, new OpenCvSharp.Size(30, 30));

            if (newFaceRect.Length == 0)
                throw new InvalidOperationException("No face detected in the uploaded image");


            foreach (var voter in votersRepo.GetAllVoters())
            {
                if (string.IsNullOrEmpty(voter.FaceDate)) continue;

                var existingFacePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", voter.FaceDate);
                if (!File.Exists(existingFacePath)) continue;

                var existingFaceImage = new Mat(existingFacePath, ImreadModes.Color);
                if (existingFaceImage.Empty()) continue;

                var existingGrayImage = new Mat();
                Cv2.CvtColor(existingFaceImage, existingGrayImage, ColorConversionCodes.BGR2GRAY);

                var existingFaceRect = faceCascade.DetectMultiScale(existingGrayImage, 1.1, 3, HaarDetectionTypes.ScaleImage, new OpenCvSharp.Size(30, 30));

                if (existingFaceRect.Length == 0) continue;

                // Compare bounding box sizes
                if (newFaceRect.Equals(existingFaceRect))
                    return true;
            }

            return false;
        }

    }
}
