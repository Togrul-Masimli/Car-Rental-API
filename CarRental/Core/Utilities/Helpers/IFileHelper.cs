using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Helpers
{
    public interface IFileHelper
    {
        void CreateFile(string dir, IFormFile file);
        void CheckDirectoryExists(string dir);
        IResult CheckFileTypeValid(string type);
        IResult CheckFileExists(IFormFile file);
        IResult Upload(IFormFile file);
    }
}
