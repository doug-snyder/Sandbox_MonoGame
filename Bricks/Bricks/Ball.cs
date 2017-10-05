using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Bricks
{
	class Ball
	{
		public float X { get; set; }
		public float Y { get; set; }
		public float XVelocity { get; set; }
		public float YVelocity { get; set; }
		public float Height { get; set; }
		public float Width { get; set; }
		public float Rotation { get; set; }
		public bool UseRotation { get; set; }
		public float ScreenWidth { get; set; }
		public float ScreenHeight { get; set; }
		public bool Visible { get; set; }
		public int Score { get; set; }
		public int BricksCleared { get; set; }

		private Texture2D ImgBall { get; set; }
		private SpriteBatch spriteBatch;
		private GameContent gameContent;

		public Ball(float screenWidth, float screenHeight, SpriteBatch spriteBatch, GameContent gameContent)
		{
			X = 0;
			Y = 0;
			XVelocity = 0;
			YVelocity = 0;
			Rotation = 0;
			ImgBall = gameContent.ImgBall;
			Width = ImgBall.Width;
			Height = ImgBall.Height;
			this.spriteBatch = spriteBatch;
			this.gameContent = gameContent;
			ScreenWidth = screenWidth;
			ScreenHeight = screenHeight;
			Visible = false;
			Score = 0;
			BricksCleared = 0;
			UseRotation = true;
		}

		public void Draw()
		{
			if (Visible == false)
			{
				return;
			}

			if (UseRotation)
			{
				Rotation += .1f;
				if (Rotation > 3 * Math.PI)
				{
					Rotation = 0;
				}
			}

			spriteBatch.Draw(ImgBall, new Vector2(X, Y), null, Color.White, Rotation, new Vector2(Width / 2, Height / 2), 1.0f, SpriteEffects.None, 0);
		}

		public void Launch(float x, float y, float xVelocity, float yVelocity)
		{
			if (Visible == true)
			{
				return;
			}
			PlaySound(gameContent.StartSound);
			Visible = true;
			X = x;
			Y = y;
			XVelocity = xVelocity;
			YVelocity = yVelocity;
		}

		public bool Move(Wall wall, Paddle paddle)
		{
			if (Visible == false)
			{
				return false;
			}

			X = X + XVelocity;
			Y = Y + YVelocity;

			// Wall hits
			if (X < 1)
			{
				X = 1;
				XVelocity = XVelocity * -1;
				PlaySound(gameContent.WallBounceSound);
			}
			if (X > ScreenWidth - Width + 5)
			{
				X = ScreenWidth - Width + 5;
				XVelocity = XVelocity * -1;
				PlaySound(gameContent.WallBounceSound);
			}
			if (Y < 1)
			{
				Y = 1;
				YVelocity = YVelocity * -1;
				PlaySound(gameContent.WallBounceSound);
			}
			if (Y + Height > ScreenHeight)
			{
				Visible = false;
				Y = 0;
				PlaySound(gameContent.MissSound);
				return false;
			}

			// Paddle hits
			Rectangle paddleRect = new Rectangle((int)paddle.X, (int)paddle.Y, (int)paddle.Width, (int)paddle.Height);
			Rectangle ballRect = new Rectangle((int)X, (int)Y, (int)Width, (int)Height);
			if (HitTest(paddleRect, ballRect))
			{
				PlaySound(gameContent.PaddleBounceSound);
				int offset = Convert.ToInt32((paddle.Width - (paddle.X + paddle.Width - X + Width / 2)));

				offset = offset / 5;
				if (offset < 0)
				{
					offset = 0;
				}

				switch (offset)
				{
					case 0:
						XVelocity = -6;
						break;
					case 1:
						XVelocity = -5;
						break;
					case 2:
						XVelocity = -4;
						break;
					case 3:
						XVelocity = -3;
						break;
					case 4:
						XVelocity = -2;
						break;
					case 5:
						XVelocity = -1;
						break;
					case 6:
						XVelocity = 1;
						break;
					case 7:
						XVelocity = 2;
						break;
					case 8:
						XVelocity = 3;
						break;
					case 9:
						XVelocity = 4;
						break;
					case 10:
						XVelocity = 5;
						break;
					default:
						XVelocity = 6;
						break;
				}

				YVelocity = YVelocity * -1;
				Y = paddle.Y - Height + 1;
				return true;
			}

			bool hitBrick = false;
			for (int i = 0; i < 7; i++)
			{
				if (hitBrick == false)
				{
					for (int j = 0; j < 10; j++)
					{
						Brick brick = wall.BrickWall[i, j];
						if (brick.Visible)
						{
							Rectangle brickRect = new Rectangle((int)brick.X, (int)brick.Y, (int)brick.Width, (int)brick.Height);
							if (HitTest(ballRect, brickRect))
							{
								PlaySound(gameContent.BrickSound);
								brick.Visible = false;
								Score = Score + 7 - i;
								YVelocity = YVelocity * -1;
								BricksCleared++;
								hitBrick = true;
								break;
							}
						}
					}
				}
			}
			return true;
		}

		public static bool HitTest(Rectangle r1, Rectangle r2)
		{
			if (Rectangle.Intersect(r1, r2) != Rectangle.Empty)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public static void PlaySound(SoundEffect sound)
		{
			float volume = 1;
			float pitch = 0.0f;
			float pan = 0.0f;
			sound.Play(volume, pitch, pan);
		}

	}
}
