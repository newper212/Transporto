using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transporto.Helpers
{
    public static class ExtensionHelpers
    {
        public static bool HasRol(this AppRol[] val)
        {
            var values = Enum.GetValues(typeof(AppRol)).Cast<AppRol>();

            return false;
        }


        public static string GetPath(this HttpPostedFileBase val, string basePath)
        {
            try
            {
                var filename = $"{Guid.NewGuid().ToString().Split('-')[1]}_{val.FileName}";
                var path = basePath + filename;
                val.SaveAs(path);
                return path;
            }
            catch (Exception ex)
            {
                return String.Empty;
            }
        }
    }
}