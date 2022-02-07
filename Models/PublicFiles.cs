using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INS_FInal.Models
{
    public class PublicFiles
    {
        private List<IFormFile> publicFiles;
        public PublicFiles()
        {
            publicFiles = new List<IFormFile>();
        }
    }
}
