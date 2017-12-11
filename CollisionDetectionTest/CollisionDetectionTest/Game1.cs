using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace CollisionDetectionTest
{
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		private List<Sprite> _sprites;


		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}


		protected override void Initialize()
		{
			var form = (System.Windows.Forms.Form)System.Windows.Forms.Control.FromHandle(this.Window.Handle);
			form.Location = new System.Drawing.Point(450, 250);

			base.Initialize();
		}


		protected override void LoadContent()
		{
			spriteBatch = new SpriteBatch(GraphicsDevice);

			Texture2D playerTexture = Content.Load<Texture2D>("Square");

			_sprites = new List<Sprite>()
			{
				new Player(playerTexture)
				{
					Input = new Input()
					{
						Left = Keys.A,
						Right = Keys.D,
						Up = Keys.W,
						Down = Keys.S
					},
					Position = new Vector2(100, 100),
					Color = Color.Blue,
					Speed = 5f
				},
				new Player(playerTexture)
				{
					Input = new Input()
					{
						Left = Keys.Left,
						Right = Keys.Right,
						Up = Keys.Up,
						Down = Keys.Down
					},
					Position = new Vector2(300, 300),
					Color = Color.Red,
					Speed = 5f
				}
			};
		}


		protected override void UnloadContent(){}


		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
			{
				Exit();
			}

			foreach (Sprite sprite in _sprites)
			{
				sprite.Update(gameTime, _sprites);
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
