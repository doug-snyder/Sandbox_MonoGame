using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CameraTrackingTest
{
	public class Player : Sprite
	{
		public Player(Texture2D texture) : base(texture){}


		public override void Update(GameTime gameTime)
		{
			Vector2 velocity = new Vector2();
			float speed = 3.0f;

			if (Keyboard.GetState().IsKeyDown(Keys.W))
			{
				velocity.Y = -speed;
			}
			else if (Keyboard.GetState().IsKeyDown(Keys.S))
			{
				velocity.Y = speed;
			}

			if (Keyboard.GetState().IsKeyDown(Keys.A))
			{
				velocity.X = -speed;
			}
			else if (Keyboard.GetState().IsKeyDown(Keys.D))
			{
				velocity.X = speed;
			}

			Position += velocity;
		}


	}
}
