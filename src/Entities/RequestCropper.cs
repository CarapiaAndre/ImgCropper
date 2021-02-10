namespace Andre.ImgCropper.src.Entities
{
    public class RequestCropper
    {
        public string Base64 {get; set;}

        public BoundingBox Box {get; set;}

        public class BoundingBox
        {
            public decimal Left {get; set;}
            public decimal Top {get; set;}
            public decimal Width {get; set;}
            public decimal Height {get; set;}
        }
    }
}