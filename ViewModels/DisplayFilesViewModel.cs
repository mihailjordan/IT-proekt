using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using INS_FInal.Models;

namespace INS_FInal.ViewModels
{
    public class DisplayFilesViewModel
    {
        public AplicationUser user = null;
        public List<File> files = null;

        public DisplayFilesViewModel(AplicationUser user, List<File> files)
        {
            this.user = user;
            this.files = files;
        }

        public AplicationUser getUser()
        {
            return user;
        }

        public List<File> getFiles()
        {
            return files;
        }

        
    }
}
