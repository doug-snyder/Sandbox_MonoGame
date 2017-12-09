using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ScreenBoundsTest
{
	public class Bomb : Sprite
	{
		public Bomb(Texture2D texture) : base(texture)
		{
			Position = new Microsoft.Xna.Framework.Vector2(Game1.Random.Next(0, Game1.ScreenWidth - _texture.Width), -_texture.Height);
			Speed = Game1.Random.Next(3, 10);
		}

		public override void Update(GameTime gameTime, List<Sprite> _sprites)
		{
			Position.Y += Speed;

			// Bottom of window collision
			if (Rectangle.Bottom > Game1.ScreenHeight)
			{
				IsRemoved = true;
			}
		}

	}
}
