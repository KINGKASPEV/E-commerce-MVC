using Microsoft.AspNetCore.Http;

namespace IdentityRoleAuthorization.Service.Services.interfaces
{
    public interface IFileService
    {
        Tuple<int, string> SaveImage(IFormFile imageFile);
        public bool DeleteImage(string imageFileName);
    }

}

