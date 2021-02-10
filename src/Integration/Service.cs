using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Andre.ImgCropper.src.Entities;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Processing;

namespace Andre.ImgCropper.src.Integration
{
    public class Service
    {
        private byte[] base64Bin {get; set;}
        private Image image {get; set;}
        private int axisX {get; set;}
        private int axisY {get; set;}
        private int width {get; set;}
        private int height {get; set;}

        public Service(RequestCropper req)
        {
            base64Bin = Convert.FromBase64String(req.Base64);
            image = Image.Load(base64Bin);

            axisX = (int)(image.Width * req.Box.Left);
            axisY = (int)(image.Height * req.Box.Top);

            width = (int)(image.Width * req.Box.Width);
            height = (int)(image.Height * req.Box.Height);
        }
        public async Task<string> CropImage()
        {
            image.Mutate(
                x => x.Crop(new Rectangle(axisX, axisY, width, height))
            );

            return image.ToBase64String(PngFormat.Instance);   
        }
    }
}