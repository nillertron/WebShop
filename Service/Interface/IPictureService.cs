using BlazorInputFile;
using Model;
using System.Threading.Tasks;

namespace Service
{
   public interface IPictureService
    {
        Task DeletePictureFile(string webRootPath, WS_Pictures picture);
        Task DeletePictureDb(WS_Pictures picture);

        Task<WS_Pictures> SaveFile(IFileListEntry file, string webPath);
    }
}