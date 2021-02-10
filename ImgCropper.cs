using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Andre.ImgCropper.src.Entities;
using System.Text;
using Andre.ImgCropper.src.Integration;

namespace Andre.ImgCropper
{
    public static class ImgCropper
    {
        [FunctionName("ImgCropper")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<RequestCropper>(requestBody);
            
            var service = new Service(data);
            return new OkObjectResult(await service.CropImage());
        }
    }
}
