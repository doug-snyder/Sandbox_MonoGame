using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace AnimatedSpriteTest
{
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		private List<Sprite> _sprites;

		private Texture2D _texture;


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

			_sprites = new List<Sprite>()
			{
				new Sprite(_texture)
				{
					Position = new Vector2(250, 250),
					Input = new Input()
					{
						Up = Keys.W,
						Down = Keys.S,
						Left = Keys.A,
						Right = Keys.D
					}
				},
				new Sprite(_texture)
				{
					Position = new Vector2(100, 100),
					Input = new Input()
					{
						Up = Keys.Up,
						Down = Keys.Down,
						Left = Keys.Left,
						Right = Keys.Right
					}
				}
			};
		}

		protected override void UnloadContent(){}

		protected override void Update(GameTime gameTime)
		{
			if (Keyboard.GetState().IsKeyDown(Keys.Escape))
			{
				Exit();
			}

			foreach (Sprite sprite in _sprites)
			{
				sprite.Update();
			}

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			spriteBatch.Begin();
			
			foreach (Sprite sprite in _sprites)
			{
				sprite.Draw(spriteBatch);
			}

			spriteBatch.End();

			base.Draw(gameTime);
		}

	}
}
