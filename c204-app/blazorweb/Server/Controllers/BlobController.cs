using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace blazorweb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlobController : ControllerBase
    {

        public BlobController(BlobServiceClient blobServiceClient)
        {
            BlobServiceClient = blobServiceClient;
        }

        public BlobServiceClient BlobServiceClient { get; }

        // GET: api/<BlobController>
        [HttpGet]
        public async Task<IEnumerable<string>> GetAsyn()
        {
            BlobContainerClient blobContainerClient = BlobServiceClient.GetBlobContainerClient("web-container");
            var blobNames = new List<string>();
            await foreach (BlobItem blobItem in blobContainerClient.GetBlobsAsync())
            {
                blobNames.Add(blobItem.Name);
            }
            return blobNames;
        }

        [HttpPost]
        public async Task PostRandomAsync()
        {
            var file = await System.IO.File.ReadAllTextAsync("template.txt");
            BlobContainerClient blobContainerClient = BlobServiceClient.GetBlobContainerClient("web-container");
            var currentDate = DateTime.Now.ToString();
            BlobClient blobClient = blobContainerClient.GetBlobClient($"template-{currentDate}.txt");
            file = file.Replace("{{Date}}", currentDate);       
            await blobClient.UploadAsync(new MemoryStream(Encoding.UTF8.GetBytes(file)), new BlobHttpHeaders
            {
                ContentType = "text/html"
            });
        }


    }
}
