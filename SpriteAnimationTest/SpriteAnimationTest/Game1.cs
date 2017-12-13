using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace SpriteAnimationTest
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

			var animations = new Dictionary<string, Animation>()
			{
				{ "walkingDown", new Animation(Content.Load<Texture2D>("Player/walkingDown"), 3) },
				{ "walkingUp", new Animation(Content.Load<Texture2D>("Player/walkingUp"), 3) },
				{ "walkingLeft", new Animation(Content.Load<Texture2D>("Player/walkingLeft"), 3) },
				{ "walkingRight", new Animation(Content.Load<Texture2D>("Player/walkingRight"), 3) }
			};

			_sprites = new List<Sprite>()
			{
				new Sprite(animations)
				{
					Position = new Vector2(100, 100),
					Speed = 2f,
					Input = new Input()
					{
						Up = Keys.W,
						Down = Keys.S,
						Left = Keys.A,
						Right = Keys.D
					}
				},
				new Sprite(animations)
				{
					Position = new Vector2(300, 300),
					Speed = 3f,
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
