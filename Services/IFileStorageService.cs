using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crowdfunding_API.Services
{
    public interface IFileStorageService
    {
        Task<string> EditFile(byte[] content, string extension, string containerName, string fileRoute, string contentType);
        Task DeleteFiles(string fileRoute, string containerName);
        Task<string> SaveFile(byte[] content, string extension, string containerName, string contentType);
    }
}
