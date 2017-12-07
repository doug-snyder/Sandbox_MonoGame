using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace AnimatedSpriteTest.Sprites
{
	public class Player : Sprite
	{
		public bool HasDied = false;

		public Player(Texture2D texture) : base(texture) {}

		public override void Update(GameTime gameTime, List<Sprite> sprites)
		{
			Move();

			foreach (Sprite sprite in sprites)
			{
				if (sprite == this)
				{
					continue;
				}

				if (sprite.Rectangle.Intersects(this.Rectangle))
				{
					this.HasDied = true;
				}
			}

			Position += Velocity;
			Position.X = MathHelper.Clamp(Position.X, 0, Game1.ScreenWidth - Rectangle.Width);
		}

		private void Move()
		{
			if (Input == null)
			{
				throw new Exception("Please assign a value to 'Input'.");
			}

			if (Keyboard.GetState().IsKeyDown(Input.Left))
			{
				Velocity.X = -Speed;
			}
			else if (Keyboard.GetState().IsKeyDown(Input.Right))
			{
				Velocity.X = Speed;
			}
		}
	}
}
