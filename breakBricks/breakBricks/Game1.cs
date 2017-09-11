using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace breakBricks
{
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		Paddle paddle;
		Ball ball;
		Rectangle screenRectangle;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";

			screenRectangle = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
		}

		protected override void Initialize()
		{
			var form = (System.Windows.Forms.Form)System.Windows.Forms.Control.FromHandle(this.Window.Handle);
			form.Location = new System.Drawing.Point(600, 350);

			base.Initialize();
		}

		protected override void LoadContent()
		{
			spriteBatch = new SpriteBatch(GraphicsDevice);

			Texture2D tempTexture = Content.Load<Texture2D>("paddle");
			paddle = new Paddle(tempTexture, screenRectangle);

			tempTexture = Content.Load<Texture2D>("ball");
			ball = new Ball(tempTexture, screenRectangle);

			StartGame();
		}

		private void StartGame()
		{
			paddle.SetInStartPosition();
			ball.SetInStartPosition(paddle.GetBounds());
		}

		protected override void UnloadContent() {}

		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
			{
				Exit();
			}

			paddle.Update();
			ball.Update();

			ball.PaddleCollision(paddle.GetBounds());

			if(ball.OffBottom())
			{
				StartGame();
			}

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			spriteBatch.Begin();
			paddle.Draw(spriteBatch);
			ball.Draw(spriteBatch);
			spriteBatch.End();

			base.Draw(gameTime);
		}

	}
}
