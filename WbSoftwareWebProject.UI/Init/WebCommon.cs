using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WbSoftwareWebProject.Common;
using WbSoftwareWebProject.UI.Models;

namespace WbSoftwareWebProject.UI.Init
{
    public class WebCommon : ICommon
    {
        public string GetCurrentUsername()
        {
            if (CurrentSession.User != null)
                return CurrentSession.User.Username;
            else
                return "system";

        }
    }
}