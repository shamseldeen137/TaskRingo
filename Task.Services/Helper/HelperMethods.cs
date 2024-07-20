using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;



namespace Task.Services.Helper
{
    public class HelperMethods
    {



        #region ctor

        private readonly IHostEnvironment _host;

      


        public HelperMethods(IHostEnvironment host)
        {
            _host = host;

        


        }

      

     
        public async Task<string> SaveFile(string filePath, IFormFile formFile)
        {
            if (formFile != null && formFile.Length > 0 && !ContainsDangerousFileType(formFile.FileName))
            {
                Directory.CreateDirectory(_host.ContentRootPath + "/wwwroot/" + filePath);

                string filePhysicalPath;
                string fileName;

                //Generate a unique image name to be added to the folder
                do
                {
                    //Generate a unique number to be added to the target file name
                    //string uniqueKey = new Random().Next(50000, 1000000).ToString();
                    string dateNow = DateTime.Now.ToString("yyyy_MM_dd.HH_mm_ss_ffff");
                    string extension = Path.GetExtension(formFile.FileName);
                    fileName = string.Format("{0}{1}", dateNow, extension);

                    //Construct the physical path to save the file
                    //Physical Path = Application Root + Target Folder + Image file name
                    filePhysicalPath = _host.ContentRootPath + string.Format("/wwwroot/{0}/{1}", filePath, fileName);
                } while (File.Exists(filePhysicalPath));

                //Save the file
                using (var stream = new FileStream(filePhysicalPath, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }

                //Construct the virtual path to the image
                //virtual path = Upload Folder + Division folder + Image file name
                return string.Format("{0}", fileName);
            }
            else
                return null;
        }



        public bool ContainsDangerousFileType(string fileName)
        {
            #region Explanation of Filetypes

            //.EXE (machine language)
            //.COM (machine language)
            //.VB  (Visual Basic script)
            //.VBS (Visual Basic script)
            //.VBE (Visual Basic script-encoded)
            //.CMD (batch file - Windows)
            //.BAT (batch file - DOS/Windows)
            //.WS  (Windows script)
            //.WSF (Windows script)
            //.SCR (screen saver)
            //.SHS (OLE object package)
            //.PIF (shortcut to DOS file plus code)
            //.HTA (hypertext application)
            //.JS  (JavaScript script)
            //.JSE (JScript script)
            //.LNK (shortcut to an executable)

            #endregion Explanation of Filetypes

            string extension = Path.GetExtension(fileName);

            //No extension  == no uploading ;)
            if (extension == null)
            {
                return true;
            }
            List<string> _forbiddenFileTypes = new List<string>
            {
                ".EXE",".COM",".VB",".VBS",".VBE",".CMD",
                ".BAT",".WS",".WSF",".SCR",".SHS",".PIF",
                ".HTA",".JS",".JSE",".LNK",".MSI",
            };

            bool hasForbiddenFile = _forbiddenFileTypes.Any(type => type == extension.Trim().ToUpper());

            return hasForbiddenFile;
        }

        #endregion


    
      
    }
}
