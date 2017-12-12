using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SimpleTwoPlayerTest
{
	public class Score
	{
		public int Score1;
		public int Score2;

		private SpriteFont _font;

		public Score(SpriteFont font)
		{
			_font = font;
		}


		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.DrawString(_font, Score1.ToString(), new Microsoft.Xna.Framework.Vector2(320, 70), Color.White);
			spriteBatch.DrawString(_font, Score2.ToString(), new Microsoft.Xna.Framework.Vector2(430, 70), Color.White);
		}


	}
}
