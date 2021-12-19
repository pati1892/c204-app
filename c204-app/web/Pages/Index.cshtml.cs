using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Pages
{
    public class IndexModel : PageModel
    {
        public List<string> BlobNames = new List<string>();
        private readonly ILogger<IndexModel> _logger;
        private readonly BlobServiceClient blobServiceClient;

        public IndexModel(ILogger<IndexModel> logger, BlobServiceClient blobServiceClient)
        {
            _logger = logger;
            this.blobServiceClient = blobServiceClient;
        }

        public async Task OnGet()
        {
         
            BlobContainerClient blobContainerClient = this.blobServiceClient.GetBlobContainerClient("web-container");
           
            await foreach(BlobItem blobItem in blobContainerClient.GetBlobsAsync())
            {
                this.BlobNames.Add(blobItem.Name);
            }
           
        }
  
        
        public async Task UploadRandomBlob()
        {
            var file = System.IO.File.ReadAllText(@"template.tx");
            
        }
    }
}
