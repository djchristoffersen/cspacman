using System.Drawing;
using System.IO;
using NUnit.Framework;

namespace eu.sig.cspacman.sprite
{
	[TestFixture]
	public class SpriteTest {

		private ISprite sprite;
		private SpriteStore store;

		private readonly int spriteSize = 64;

		[SetUp]
		public void SetUp() {
			store = new SpriteStore();
			sprite = store.loadSprite("Sprites.64x64white.png");
		}

		[Test]
		public void spriteWidth() {
			Assert.AreEqual(spriteSize, sprite.getWidth());
		}

		[Test]
		public void spriteHeight() {
			Assert.AreEqual(spriteSize, sprite.getHeight());
		}

		[Test]
		[ExpectedException(typeof(IOException))]
		public void resourceMissing() {
			store.loadSprite("Sprites.nonexistingresource.png");
		}

		[Test]
		public void animationWidth() {
			AnimatedSprite animation = store.createAnimatedSprite(sprite, 4, 0,
				false);
			Assert.AreEqual(16, animation.getWidth());
		}

		[Test]
		public void animationHeight() {
			AnimatedSprite animation = store.createAnimatedSprite(sprite, 4, 0,
				false);
			Assert.AreEqual(64, animation.getHeight());
		}

		[Test]
		public void splitWidth() {
            Rectangle rect = new Rectangle { X = 10, Y = 11, Width = 12, Height = 13 };
			ISprite split = sprite.split(rect);
			Assert.AreEqual(12, split.getWidth());
		}

		[Test]
		public void splitHeight() {
            Rectangle rect = new Rectangle { X = 10, Y = 11, Width = 12, Height = 13 };
            ISprite split = sprite.split(rect);
			Assert.AreEqual(13, split.getHeight());
		}

		[Test()]
		public void splitOutOfBounds() {
            Rectangle rect = new Rectangle { X = 10, Y = 11, Width = 12, Height = 13 };
            ISprite split = sprite.split(rect);
			Assert.IsTrue(split is EmptySprite);
		}
	}
}
