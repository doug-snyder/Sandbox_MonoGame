using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace breakBricks
{
	class Ball
	{
		Vector2 motion;
		Vector2 position;
		Rectangle bounds;
		bool collided;
		const float ballStartSpeed = 8f;
		float ballSpeed = 4;

		Texture2D texture;
		Rectangle screenBounds;

		public Rectangle Bounds
		{
			get
			{
				bounds.X = (int)position.X;
				bounds.Y = (int)position.Y;
				return bounds;
			}
		}

		public Ball(Texture2D texture, Rectangle screenBounds)
		{
			bounds = new Rectangle(0, 0, texture.Width, texture.Height);
			this.texture = texture;
			this.screenBounds = screenBounds;
		}

		public void Update()
		{
			collided = false;
			position += motion * ballSpeed;
			ballSpeed += 0.01f;

			CheckWallCollision();
		}

		private void CheckWallCollision()
		{
			if(position.X < 0)
			{
				position.X = 0;
				motion.X *= -1;
			}

			if(position.X + texture.Width > screenBounds.Width)
			{
				position.X = screenBounds.Width - texture.Width;
				motion.X *= -1;
			}

			if(position.Y < 0)
			{
				position.Y = 0;
				motion.Y *= -1;
			}
		}

		public void SetInStartPosition(Rectangle paddleLocation)
		{
			Random rand = new Random();

			motion = new Vector2(rand.Next(2, 6), -rand.Next(2, 6));
			motion.Normalize();

			ballSpeed = ballStartSpeed;

			position.Y = paddleLocation.Y - texture.Height;
			position.X = paddleLocation.X + (paddleLocation.Width - texture.Width) / 2;
		}

		public bool OffBottom()
		{
			if(position.Y > screenBounds.Height)
			{
				return true;
			}
			return false;
		}

		public void PaddleCollision(Rectangle paddleLocation)
		{
			Rectangle ballLocation = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

			if(paddleLocation.Intersects(ballLocation))
			{
				position.Y = paddleLocation.Y - texture.Height;
				motion.Y *= -1;
			}
		}

		public void Deflection(Brick brick)
		{
			if (!collided)
			{
				motion.Y *= -1;
				collided = true;
			}
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(texture, position, Color.White);
		}

	}
}
