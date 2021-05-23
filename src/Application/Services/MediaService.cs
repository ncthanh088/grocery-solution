using System.IO;
using System.Threading.Tasks;
using Grocery.Application.Services.Abstractions;
using Grocery.Domain.Entities;

namespace Grocery.Application.Services
{
    public class MediaService : IMediaService
    {
        public Task DeleteMediaAsync(Media media)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteMediaAsync(string fileName)
        {
            throw new System.NotImplementedException();
        }

        public string GetMediaUrl(Media media)
        {
            throw new System.NotImplementedException();
        }

        public string GetMediaUrl(string fileName)
        {
            throw new System.NotImplementedException();
        }

        public string GetThumbnailUrl(Media media)
        {
            throw new System.NotImplementedException();
        }

        public Task SaveMediaAsync(Stream mediaBinaryStream, string fileName, string mimeType = null)
        {
            throw new System.NotImplementedException();
        }
    }
}