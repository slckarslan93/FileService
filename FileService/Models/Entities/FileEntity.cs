namespace FileService.Models.Entities
{
    public class FileEntity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; }
        public string Path { get; set; } = string.Empty;
    }
}