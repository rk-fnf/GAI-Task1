using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace EmployeeFormUI.Services
{
    public class UploadBase : ComponentBase
    {

        public List<string> errors = new();
        public IBrowserFile selectedFile;
        public string uploadResult;

        public async Task LoadFiles(InputFileChangeEventArgs e)
        {
            selectedFile = e.File;
            errors.Clear();

        }
        public async Task UploadFile()
        {
            if (selectedFile != null)
            {
                try
                {
                    var connectionString = "DefaultEndpointsProtocol=https;AccountName=empstorage5641;AccountKey=4ErxZNXlMCAs466AWB6VYp9YdG28+7iMVEHln7o87AoDpdxsnc/6cuco/2D/ctEh2ARFOhVk11Ct+AStUc/2/w==;EndpointSuffix=core.windows.net";
                    var containerName = "empdatacontainer";
                    var blobName = Guid.NewGuid().ToString();

                    var blobServiceClient = new BlobServiceClient(connectionString);
                    var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
                    var blobClient = containerClient.GetBlobClient(blobName);

                    using (var stream = selectedFile.OpenReadStream())
                    {
                        await blobClient.UploadAsync(stream, true);
                    }

                    uploadResult = "File uploaded successfully!";
                }
                catch (Exception ex)
                {
                    uploadResult = $"Error: {ex.Message}";
                }
            }
        }
    }
}
