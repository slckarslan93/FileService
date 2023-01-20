using FileService.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace FileService.Models.Data.EF
{
    public class FileServiceDbContext : DbContext
    {
        public FileServiceDbContext(DbContextOptions<FileServiceDbContext> options) : base(options)
        {
        }

        public DbSet<FileEntity> FileEntities { get; set; }
    }
}