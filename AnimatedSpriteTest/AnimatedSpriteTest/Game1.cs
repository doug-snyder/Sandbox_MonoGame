using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AnimatedSpriteTest
{
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		Texture2D spriteSheet;
		Rectangle source;
		Vector2 position;
		Vector2 origin;
		float time;
		float frameTime = 0.06f;
		int frameIndex;
		const int totalFrames = 7;
		int frameHeight = 96;
		int frameWidth = 64;

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

			position = new Vector2(this.Window.ClientBounds.Width / 2, this.Window.ClientBounds.Height / 2);
			origin = new Vector2(frameWidth / 2.0f, frameHeight);

			base.Initialize();
		}

		protected override void LoadContent()
		{
			spriteBatch = new SpriteBatch(GraphicsDevice);
			spriteSheet = Content.Load<Texture2D>("link spritesheet");
		}

		protected override void UnloadContent(){}

		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
			{
				Exit();
			}

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			time += (float)gameTime.ElapsedGameTime.TotalSeconds;
			while (time > frameTime)
			{
				frameIndex++;
				time = 0f;
			}

			if (frameIndex > totalFrames)
			{
				frameIndex = 0;
			}

			source = new Rectangle(frameIndex * frameWidth, 96*0, frameWidth, frameHeight);

			spriteBatch.Begin();
			spriteBatch.Draw(spriteSheet, position, source, Color.White, 0.0f, origin, 1.0f, SpriteEffects.None, 0.0f);
			spriteBatch.End();

			base.Draw(gameTime);
		}

	}
}
