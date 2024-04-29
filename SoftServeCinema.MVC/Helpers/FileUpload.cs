namespace SoftServeCinema.MVC.Helpers
{
    public class FileUpload
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public FileUpload(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public string SaveFileToWwwRoot(string folderPath, string fileName, Stream fileStream)
        {
            string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(fileName);

            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, folderPath);
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStreamOutput = new FileStream(filePath, FileMode.Create))
            {
                fileStream.CopyTo(fileStreamOutput);
            }

            return uniqueFileName;
        }
    }
}
