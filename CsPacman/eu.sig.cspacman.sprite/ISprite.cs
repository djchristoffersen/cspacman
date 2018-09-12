using System.Drawing;

namespace eu.sig.cspacman.sprite
{
	public interface ISprite {

		void draw(Graphics g, Rectangle rect);

		ISprite split(Rectangle rect);

		int getWidth();

		int getHeight();
	}
}