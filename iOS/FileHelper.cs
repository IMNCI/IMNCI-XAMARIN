using System;
using System.IO;
using Xamarin.Forms;
using IMNCI.iOS;


[assembly : Dependency(typeof(FileHelper))]
namespace IMNCI.iOS
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if(!Directory.Exists(libraryFolder)){
                Directory.CreateDirectory(libraryFolder);
            }

            return Path.Combine(libraryFolder, filename);
        }
    }
}
