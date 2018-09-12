using System.Drawing;

namespace eu.sig.cspacman.sprite
{
	public class EmptySprite : ISprite {

		public void draw(Graphics g,Rectangle rect) {
			// nothing to draw.
		}

		public ISprite split(Rectangle rect) {
			return new EmptySprite();
		}

		public int getWidth() {
			return 0;
		}

		public int getHeight() {
			return 0;
		}
	}
}
