using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using INS_FInal.Models;

namespace INS_FInal.ViewModels
{
    public class EditDepartmentViewModel
    {
        /*public Department dep;
        public List<AplicationUser> users;
        public EditDepartmentViewModel()
        {
            users = new List<AplicationUser>();
        }

        public EditDepartmentViewModel(Department dep, List<AplicationUser> users)
        {
            this.dep = dep;
            this.users = users;
        }*/
        public int depId { get; set; }

        public string userId { get; set; }
        public string UserName { get; set; }

        public bool IsSelected { get; set; }
    }
}
