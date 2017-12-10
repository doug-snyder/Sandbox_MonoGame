using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ScoreTrackingTest
{
	public class Player : Sprite
	{
		public int Score;

		public Player(Texture2D texture) : base(texture)
		{	
		}

		public override void Update(GameTime gameTime, List<Sprite> sprites)
		{
			Move();

			foreach(Sprite sprite in sprites)
			{
				if (sprite is Player)
				{
					continue;
				}

				if (sprite.Rectangle.Intersects(this.Rectangle))
				{
					Score++;
					sprite.IsRemoved = true;
				}
			}
		}

		private void Move()
		{
			if (Keyboard.GetState().IsKeyDown(Input.Left))
			{
				Position.X -= Speed;
			}
			else if (Keyboard.GetState().IsKeyDown(Input.Right))
			{
				Position.X += Speed;
			}

			if (Keyboard.GetState().IsKeyDown(Input.Up))
			{
				Position.Y -= Speed;
			}
			else if (Keyboard.GetState().IsKeyDown(Input.Down))
			{
				Position.Y += Speed;
			}

			Position = Vector2.Clamp(Position, Vector2.Zero, new Vector2(Game1.ScreenWidth - this.Rectangle.Width,
																		 Game1.ScreenHeight - this.Rectangle.Height));
		}
	}
}
