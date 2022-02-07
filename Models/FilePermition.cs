using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INS_FInal.Models
{
    public class FilePermition
    {
        public int Id { get; set; }
        public string FkUser { get; set; }
        public int FkFile { get; set; }

        public FilePermition(string FkUser, int FkFile)
        {
            this.FkUser = FkUser;
            this.FkFile = FkFile;            
        }

        public FilePermition()
        {
        }
    }
}
