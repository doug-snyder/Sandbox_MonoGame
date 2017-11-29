using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AnimatedSpriteTest
{
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		private Texture2D _texture;
		private Vector2 _position;


		public Game1()
		{
			graphics = new GraphicsDeviceManager(this)
			{
				PreferredBackBufferWidth = 1280,
				PreferredBackBufferHeight = 720
			};
			graphics.ApplyChanges();
			Content.RootDirectory = "Content";
		}

		protected override void Initialize()
		{
			var form = (System.Windows.Forms.Form)System.Windows.Forms.Control.FromHandle(this.Window.Handle);
			form.Location = new System.Drawing.Point(450, 250);

			//position = new Vector2(this.Window.ClientBounds.Width / 2, this.Window.ClientBounds.Height / 2);
			//origin = new Vector2(frameWidth / 2.0f, frameHeight);

			base.Initialize();
		}

		protected override void LoadContent()
		{
			spriteBatch = new SpriteBatch(GraphicsDevice);

			_texture = Content.Load<Texture2D>("malefighter");
			_position = new Vector2(250, 250);
		}

		protected override void UnloadContent(){}

		protected override void Update(GameTime gameTime)
		{
			if (Keyboard.GetState().IsKeyDown(Keys.Escape))
			{
				Exit();
			}

			if (Keyboard.GetState().IsKeyDown(Keys.W))
			{
				_position.Y -= 1;
			}
			if (Keyboard.GetState().IsKeyDown(Keys.A))
			{
				_position.X -= 1;
			}
			if (Keyboard.GetState().IsKeyDown(Keys.S))
			{
				_position.Y += 1;
			}
			if (Keyboard.GetState().IsKeyDown(Keys.D))
			{
				_position.X += 1;
			}

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			spriteBatch.Begin();
			spriteBatch.Draw(_texture, _position, Color.White);
			spriteBatch.End();

			base.Draw(gameTime);
		}

	}
}
