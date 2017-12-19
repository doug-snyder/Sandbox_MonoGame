using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CameraTrackingTest
{
	public class Sprite : Component
	{
		protected Texture2D _texture;

		public Vector2 Position { get; set; }
		public Rectangle Rectangle
		{
			get { return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height); }
		}


		public Sprite(Texture2D texture)
		{
			_texture = texture;
		}


		public override void Update(GameTime gameTime)
		{
			
		}


		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(_texture, Position, Color.White);
		}


	}
}
