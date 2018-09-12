using System.Drawing;

namespace eu.sig.cspacman.sprite
{
    public class ImageSprite : ISprite
    {

        private readonly Image image;

        public ImageSprite(Image img)
        {
            this.image = img;
        }

        public void draw(Graphics g, Rectangle rect)
        {
            g.DrawImage(image, rect.Location);
        }

        public ISprite split(Rectangle rect)
        {
            // TODO: maybe factor out Image (replace it by Bitmap everywhere)?
            System.Diagnostics.Debug.Assert(image is Bitmap);
            if (withinImage(rect.X, rect.Y) && withinImage(rect.X + rect.Width - 1, rect.Y + rect.Height - 1))
            {
                Bitmap newImage = ((Bitmap)image).Clone(rect, image.PixelFormat);
                return new ImageSprite(newImage);
            }
            return new EmptySprite();
        }

        private bool withinImage(int x, int y)
        {
            return x < image.Width && x >= 0 && y < image.Height && y >= 0;
        }

        public int getWidth()
        {
            return image.Width;
        }

        public int getHeight()
        {
            return image.Height;
        }
    }
}
