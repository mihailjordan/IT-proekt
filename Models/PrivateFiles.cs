using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INS_FInal.Models
{
    public class PrivateFiles
    {
        private List<IFormFile> files;
        private string desctiption;

        public PrivateFiles()
        {
            files = new List<IFormFile>();
        }

        

    }
}
