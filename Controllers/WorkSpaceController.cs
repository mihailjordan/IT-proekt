using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using INS_FInal.Models;
using INS_FInal.ViewModels;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace INS_FInal.Controllers
{
    [Authorize]
    public class WorkSpaceController : Controller
    {
        private readonly UserManager<AplicationUser> userManager;
        private readonly SignInManager<AplicationUser> signInManager;
        private readonly AppDbContext context;
        private readonly IHostingEnvironment hostingEnviroment;
        //private readonly Models.File files;

        public WorkSpaceController(UserManager<AplicationUser> userManager,
            SignInManager<AplicationUser> signInManager,
            AppDbContext context,
            IHostingEnvironment hostingEnviroment
            //Models.File files
            )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context = context;
            this.hostingEnviroment = hostingEnviroment;
            //this.files = files;
        }
       
        [HttpGet]
        public async Task<IActionResult> DisplayPrivate()
        {

            if (signInManager.IsSignedIn(User))
            {
                var user = await userManager.GetUserAsync(User);
                var userId = user.Id;
                List<Models.File> userFiles = new List<Models.File>();

                var filePermitions = context.FilePermitions;

                foreach(FilePermition fileP in filePermitions)
                {
                    if(fileP.FkUser == userId)
                    {
                        userFiles.Add(await context.Files.FindAsync(fileP.FkFile));
                       
                    }
                }

                if(userFiles == null)
                {
                    return View("NoFiles");
                }

                var model = new DisplayFilesViewModel(user, userFiles);
                return View(model);
            }

            return RedirectToAction("Index", "HomeController");
        }


        [HttpGet]
        public IActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = long.MaxValue)]
        public async Task<IActionResult> UploadFile(UploadFileViewModel model)
        {
            bool isPrivate = true;

            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.UploadedBy);
                
                    Models.File newFile = new Models.File()
                    {
                        Name = model.FileName,
                        FilePath = await ProcessUplodetFileAsync(model),
                        IsPrivate = model.IsPrivate,
                        FkUploadedBy = user.Id,
                        UploadedOn = model.UploadedOn,
                        UploadedBy = user.UserName                       
                    };
                //files.AddFile(newFile);
                context.AddFile(newFile);
                

                isPrivate = newFile.IsPrivate;
                if (isPrivate)
                {
                    FilePermition filePermition = new FilePermition()
                    {
                        FkUser = user.Id,
                        FkFile = newFile.Id
                    };
                    context.AddFilePermition(filePermition);
                    return RedirectToAction("DisplayPrivate", "WorkSpace");
                }
            }
           

            return RedirectToAction("DisplayPublic", "WorkSpace");
        }

        public IActionResult DisplayPublic()
        {
            if (signInManager.IsSignedIn(User))
            {
                List<Models.File> publicFiles = new List<Models.File>();


                foreach (Models.File file in context.Files)
                {
                    if (file.IsPrivate == false)
                    {
                        publicFiles.Add(file);

                    }
                }

                if (publicFiles == null)
                {
                    return View("NoFiles");
                }

                return View(publicFiles);
            }

            return RedirectToAction("Index", "HomeController");
        }

         private async Task<string> ProcessUplodetFileAsync(UploadFileViewModel model)
         {
            string uniqueFileName = null;
            string uploadsFolder = null;
            

            if (model.Files != null && model.IsPrivate == true)
            {
                uploadsFolder = Path.Combine(hostingEnviroment.WebRootPath, "PrivateFiles");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Files.FileName;
                
            } else if (model.Files != null && model.IsPrivate == false)
            {
                uploadsFolder = Path.Combine(hostingEnviroment.WebRootPath, "PublicFiles");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Files.FileName;
            }

            
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
               await model.Files.CopyToAsync(fileStream);
            }

            return uniqueFileName;
        }

        [HttpGet]
        public  IActionResult ViewFile(int fileId)
        {
            Models.File file = context.Files.Find(fileId);

            return View(file);
        }

        public IActionResult DeleteFile(int fileId)
        {//delete
            var file = context.Files.Find(fileId);
            bool privateFile = false;

            if(file == null)
            {
                ViewBag.ErrorMessage = "no such file found";
                return View("NotFound");
            }
            privateFile = file.IsPrivate;

            context.Files.Remove(file);
            context.SaveChanges();
            

            if (privateFile)
            {
                return RedirectToAction("DisplayPrivate", "WorkSpace");
            }

            return RedirectToAction("DisplayPublic", "WorkSpace");
        }

        [HttpGet]
        public IActionResult CreateDeparment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateDeparment(Department dep)
        {
            context.Departments.Add(dep);
            context.SaveChanges();

            return RedirectToAction("ManageDepartments", "WorkSpace");
        }


        [HttpGet]
        public IActionResult ManageDepartments()
        {
            List<Department> deps = context.Departments.ToList();

            return View(deps);
        }

        [HttpGet]
        public IActionResult EditDeparment(int id)
        {
            var dep = context.Departments.Find(id);

            if(dep == null)
            {
                ViewBag.ErrorMessage = $"department with Id = {id} can not be found";
                return View("NotFound");
            }
            var model = new List<EditDepartmentViewModel>();

            foreach (var user in userManager.Users)
            {
                var editDepViewModel = new EditDepartmentViewModel
                {
                    depId = id,
                    userId = user.Id,
                    UserName = user.UserName
                    
                };
                
                if(user.DepId == id.ToString())
                {
                    editDepViewModel.IsSelected = true;
                }
                else
                {
                    editDepViewModel.IsSelected = false;
                }

                model.Add(editDepViewModel);
            }


            return View(model);
        }

        /*[HttpPost]
        public async Task<IActionResult> EditDeparmentAsync(List<EditDepartmentViewModel> model)
        {
            var depId = model[0].depId;
            var dep = context.Departments.Find(depId);

            foreach(var user in model)
            {
                
                    var findUser = await userManager.FindByIdAsync(user.userId);
                    findUser.DepId = depId.ToString();

                if (user.IsSelected)
                {
                   var userWorkIn = dep.workersId.Find(x => x == findUser.Id.ToString());
                    if(userWorkIn == null)
                    {

                        context.SaveChanges();
                    }
                   
                }
                    
                
               
                
            }

            return RedirectToAction("ManageDepartments", "WorkSpace");
        }
        */



    }
}
