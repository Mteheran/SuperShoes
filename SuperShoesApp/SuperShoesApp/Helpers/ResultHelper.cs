using ShuperShoesApp.Entities;
using ShuperShoesApp.Entities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperShoesApp.Helpers
{
    public static class ResultHelper
    {
        public static bool SetResult(Controller control, Result result)
        {
            if (result != null && !result.Success)
            {
                control.ModelState.AddModelError(string.Empty, result.Error_code + ": " + result.Error_msg);
            }

            return result.Success;
        }
    }
}