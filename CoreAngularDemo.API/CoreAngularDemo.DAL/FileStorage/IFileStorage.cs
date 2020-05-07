using Microsoft.AspNetCore.Http;

namespace CoreAngularDemo.DAL.FileStorage
{
    public interface IFileStorage
    {
        string Create(IFormFile file);
        byte[] Download(string FilePath);
        void Delete(string FilePath);
    }
}
