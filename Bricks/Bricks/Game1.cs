using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Bricks
{
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		GameContent gameContent;

		private Paddle paddle;
		private Wall wall;
		private GameBorder gameBorder;
		private int screenWidth = 0;
		private int screenHeight = 0;


		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}

		protected override void Initialize()
		{
			// Select window spawn point.
			//var form = (System.Windows.Forms.Form)System.Windows.Forms.Control.FromHandle(this.Window.Handle);
			//form.Location = new System.Drawing.Point(450, 250);

			base.Initialize();
		}

		protected override void LoadContent()
		{
			// Create new SpriteBatch for texture drawing.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			// TODO: this.Content for loading game content
			gameContent = new GameContent(Content);
			screenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
			screenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

			if (screenWidth >= 502)
			{
				screenWidth = 502;
			}
			if (screenHeight >= 700)
			{
				screenHeight = 700;
			}
			graphics.PreferredBackBufferWidth = screenWidth;
			graphics.PreferredBackBufferHeight = screenHeight;
			graphics.ApplyChanges();

			// Game Objects
			int paddleX = (screenWidth - gameContent.ImgPaddle.Width) / 2;						// center paddle
			int paddleY = screenHeight - 100;													// paddle 100 pixels from bottom
			paddle = new Paddle(paddleX, paddleY, screenWidth, spriteBatch, gameContent);		// create paddle
			wall = new Wall(1, 50, spriteBatch, gameContent);									// create wall
			gameBorder = new GameBorder(screenWidth, screenHeight, spriteBatch, gameContent);	// create game border

			gameContent = new GameContent(Content);
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

			spriteBatch.Begin();
			paddle.Draw();
			wall.Draw();
			gameBorder.Draw();

			spriteBatch.End();

			base.Draw(gameTime);
		}

	}
}
