using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper : IFileHelper
    {
        private static string _currentDir = Environment.CurrentDirectory + "\\wwwroot";
        private static string _folderName = "\\Images\\";

        public void CheckDirectoryExists(string dir)
        {
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }

        public IResult CheckFileExists(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IResult CheckFileTypeValid(string type)
        {
            if (type != ".jpeg" || type != ".png" || type != ".jpg")
            {
                return new ErrorResult("This file format doesn't supported.");
            }
            return new SuccessResult();
        }

        public void CreateFile(string dir, IFormFile file)
        {
            using (FileStream fs = File.Create(dir))
            {
                file.CopyTo(fs);
                fs.Flush();

            }
        }

        public IResult Upload(IFormFile file)
        {
            var fileExists = CheckFileExists(file);
            if (fileExists.Message != null)
            {
                return new ErrorResult(fileExists.Message);
            }

            var type = Path.GetExtension(file.FileName);
            var typeValid = CheckFileTypeValid(type);

            var name = Guid.NewGuid().ToString();

            if (typeValid == null)
            {
                return new ErrorResult(typeValid.Message);
            }

            CheckDirectoryExists(_currentDir + _folderName);
            CreateFile(_currentDir + _folderName + name + type, file);

            return new SuccessResult((_folderName + name + type).Replace("\\", "/"));
        }
    }
}
