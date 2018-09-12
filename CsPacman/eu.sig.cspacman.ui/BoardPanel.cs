using System.Drawing;
using System.Windows.Forms;

using eu.sig.cspacman.game;
using eu.sig.cspacman.board;

namespace eu.sig.cspacman.ui
{
	internal class BoardPanel : Panel {

		private readonly Color BACKGROUND_COLOR = Color.Black;

		private const int SQUARE_SIZE = 16;

		private readonly Game game;

		internal BoardPanel(Game game) : base() {
			System.Diagnostics.Debug.Assert(game != null);
			this.game = game;

			IBoard board = game.Level.Board;

			int w = board.Width * SQUARE_SIZE;
			int h = board.Height * SQUARE_SIZE;

			Size = new Size(w, h);
		}

		protected override void OnPaint(PaintEventArgs e) {
			System.Diagnostics.Debug.Assert(e != null);
            base.OnPaint(e);
            using (BufferedGraphics buffer = BufferedGraphicsManager.Current
                .Allocate(e.Graphics, DisplayRectangle))
            {
                render(game.Level.Board, buffer.Graphics, Size);
                buffer.Render();
            }
		}

		private void render(IBoard board, Graphics g, Size window) {
            Rectangle rect = new Rectangle();

			rect .Width = window.Width / board.Width;
			rect.Height = window.Height / board.Height;

			g.Clear(BACKGROUND_COLOR);

			for (int y = 0; y < board.Height; y++) {
				for (int x = 0; x < board.Width; x++) {
					rect.X = x * rect.Width;
					rect.Y = y * rect.Height;
					Square square = board.SquareAt(x, y);
					render(square, g, rect);
				}
			}
		}

		private void render(Square square, Graphics g, Rectangle rect) {
			square.Sprite.draw(g, rect);
			foreach (Unit unit in square.Occupants) {
				unit.Sprite.draw(g,rect);
			}
		}
	}
}
