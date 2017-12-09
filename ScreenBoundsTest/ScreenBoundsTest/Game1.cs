using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace ScreenBoundsTest
{
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		public static Random Random;

		public static int ScreenHeight;
		public static int ScreenWidth;

		private List<Sprite> _sprites;
		private float _timer;
		private bool _hasStarted = false;
		private Texture2D playerTexture;
		private Texture2D bombTexture;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";

			Random = new Random();

			ScreenWidth = graphics.PreferredBackBufferWidth;
			ScreenHeight = graphics.PreferredBackBufferHeight;
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

			bombTexture = Content.Load<Texture2D>("bomb");

			Restart();
		}

		private void Restart()
		{
			playerTexture = Content.Load<Texture2D>("duder");

			_sprites = new List<Sprite>()
			{
				new Player(playerTexture)
				{
					Position = new Vector2((ScreenWidth / 2) - (playerTexture.Width / 2), ScreenHeight - playerTexture.Height),
					Input = new Input()
					{
						Left = Keys.A,
						Right = Keys.D
					},
					Speed = 10f
				}
			};

			_hasStarted = false;
		}

		protected override void UnloadContent(){}

		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
			{
				Exit();
			}

			if (Keyboard.GetState().IsKeyDown(Keys.Space))
			{
				_hasStarted = true;
			}
			if (!_hasStarted)
			{
				return;
			}

			_timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

			foreach (Sprite sprite in _sprites)
			{
				sprite.Update(gameTime, _sprites);
			}

			if (_timer > 0.25f)
			{
				_timer = 0;
				_sprites.Add(new Bomb(bombTexture));
			}

			for (int i = 0; i < _sprites.Count; i++)
			{
				Sprite sprite = _sprites[i];

				if (sprite.IsRemoved)
				{
					_sprites.RemoveAt(i);
					i--;
				}

				if (sprite is Player)
				{
					Player player = sprite as Player;

					if (player.HasDied)
					{
						Restart();
					}
				}
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
