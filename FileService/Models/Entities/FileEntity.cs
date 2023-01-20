namespace FileService.Models.Entities
{
    public class FileEntity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string Path { get; set; } = string.Empty;
    }
}