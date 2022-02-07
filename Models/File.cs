using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INS_FInal.Models
{
    public class File
    {
        private readonly AppDbContext context;

        public File(AppDbContext context)
        {
            this.context = context;
        }

        public File()
        {

        }

        public File(string name, string filePath, bool isPrivate, string fkUploadedBy, DateTime uploadedOn)
        {
            Name = name;
            FilePath = filePath;
            IsPrivate = isPrivate;
            FkUploadedBy = fkUploadedBy;
            UploadedOn = uploadedOn;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string FilePath { get; set; }

        public bool IsPrivate { get; set; }
        public string FkUploadedBy { get; set; }
        public string UploadedBy { get; set; }
        public DateTime UploadedOn { get; set; }

      /*  public File AddFile (File file)
        {
            context.Files.Add(file);
            context.SaveChanges();

            return file;
            
        }*/

    }
}
