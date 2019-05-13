using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ToolRenter.Services.Engines.Equipment
{
    public class PhotoUploadEngine
    {
        public string Upload(HttpPostedFileBase file)
        {
            Account account = new Account(
                "dm7lepkwv",
                "453935962484596",
                "h68wAGIHesHWZKhQB5huALUPdW0"
                );

            Cloudinary cloudinary = new Cloudinary(account);

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription("test", file.InputStream)
            };

            return uploadParams.ToString();
        }
    }
}
