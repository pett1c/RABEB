using System;

namespace RABEB
{
    internal class Image : Widget<ImageData, ImageRenderer> 
    {
        public Image(ImageData data) 
            : base(data, new ImageRenderer(data)) 
        {
        }
    }
}
