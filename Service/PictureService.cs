using BlazorInputFile;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
   public class PictureService : IPictureService
    {
        private IDbService<WS_Pictures> dbService;
        public PictureService(IDbService<WS_Pictures> dbService)
        {
            this.dbService = dbService;
        }
        public async Task<WS_Pictures> SaveFile(IFileListEntry file, string webPath)
        {
            var path = Path.Combine(webPath, "images");
            path = Path.Combine(path, file.Name);
            var img = new WS_Pictures { Url = Path.Combine("http://webshop.nillertron.com/images", file.Name) };

            using (var fs = new FileStream(path, FileMode.CreateNew))
            {
                await file.Data.CopyToAsync(fs);
            }

            return img;

        }

        public async Task DeletePictureFile(string webRootPath, WS_Pictures picture)
        {
            var fileLocation = picture.Url.Replace("http://webshop.nillertron.com/", "");
            var path = Path.Combine(webRootPath, fileLocation);
            File.Delete(path);
        }

        public async Task DeletePictureDb(WS_Pictures picture)
        {
                await dbService.Repository.Delete(picture);       
        }
    }
}
