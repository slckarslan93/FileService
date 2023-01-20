namespace FileService
{
    public class FileService
    {
        public static string UploadFormFile(string destination, IFormFile file)
        {
            if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", destination)))
            {
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", destination));
            }
            string newFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", destination, newFileName);
            using (var stream = new FileStream(SavePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return $"/{destination}/{newFileName}";
        }

        public static void DeleteFile(string fPath)
        {
            if (System.IO.File.Exists(fPath))
            {
                System.IO.File.Delete(fPath);
            }
        }
    }
}