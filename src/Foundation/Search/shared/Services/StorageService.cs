using System.IO;
using System.Net;
using System.Text;
using System.Web;
using Azure.Storage.Blobs;

namespace Mvp.Foundation.Search.Services
{
    public class StorageService : IStorageService
    {
        private const string ConnectionString = "DefaultEndpointsProtocol=https;AccountName=hackathonsearchstorage;AccountKey=9xQMr02DL3UpbAMQrrJ/PZA8LanZkbAxRKX2BUAKE4AJfQtgrCZU/c09q8I9xT8RgKKisC3pQAO3DOg1LOZeYA==;EndpointSuffix=core.windows.net";

        private const string ContainerName = "searchcontents";

        public StorageService()
        {
            var serviceClient = new BlobServiceClient(ConnectionString);
            var Client = serviceClient.GetBlobContainerClient(ContainerName);
            
        }

        private BlobContainerClient ContainerClient { get; }
        public void UploadPublication(string url)
        {
            string htmlContent;
            using (var webClient = new WebClient())
            {
                htmlContent = webClient.DownloadString(url);
            }
            

            var bytes = Encoding.UTF8.GetBytes(htmlContent);
            using (var stream = new MemoryStream(bytes))
            {
                var blobName = $"{HttpUtility.UrlEncode(url)}.html";
                var blobClient = ContainerClient.GetBlobClient(blobName);
                blobClient.Upload(stream, true);
            }
        }
    }
}
