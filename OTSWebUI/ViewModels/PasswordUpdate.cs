﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OTSWebUI.ViewModels
{
    public class PasswordUpdate
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string NewPasswordConfirm { get; set; }
    }
}