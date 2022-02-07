﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using INS_FInal.Utilities;

namespace INS_FInal.ViewModels
{
    public class RegisterViewModel
    {
      
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }


            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password",
                ErrorMessage = "Password and confirmation password od not match.")]
            public string ConfirmPassword { get; set; }

        }
    }
