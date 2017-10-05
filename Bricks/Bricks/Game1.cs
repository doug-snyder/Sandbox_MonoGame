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
		private Ball ball;
		private Ball staticBall;

		private int screenWidth = 0;
		private int screenHeight = 0;
		private MouseState oldMouseState;
		private KeyboardState oldKeyboardState;
		private bool readyToServeBall = true;
		private int ballsRemaining = 3;


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
			gameBorder = new GameBorder(screenWidth, screenHeight, spriteBatch, gameContent);   // create game border
			ball = new Ball(screenWidth, screenHeight, spriteBatch, gameContent);

			staticBall = new Ball(screenWidth, screenHeight, spriteBatch, gameContent)			// for indicating 'balls left'
			{
				X = 25,
				Y = 25,
				Visible = true,
				UseRotation = false
			};
		}

		protected override void UnloadContent(){}

		protected override void Update(GameTime gameTime)
		{
			if (IsActive == false)
			{
				return;		// window is not yet active — don't update
			}

			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
			{
				Exit();
			}

			KeyboardState newKeyboardState = Keyboard.GetState();
			MouseState newMouseState = Mouse.GetState();

			// mouse events
			if (oldMouseState.X != newMouseState.X)
			{
				if (newMouseState.X >= 0 || newMouseState.X < screenHeight)
				{
					paddle.MoveTo(newMouseState.X);
				}
			}
			if (newMouseState.LeftButton == ButtonState.Released && oldMouseState.LeftButton == ButtonState.Pressed
					&& oldMouseState.X == newMouseState.X && oldMouseState.Y == newMouseState.Y && readyToServeBall)
			{
				ServeBall();
			}

			// keyboard events
			if (newKeyboardState.IsKeyDown(Keys.Left) || newKeyboardState.IsKeyDown(Keys.A))
			{
				paddle.MoveLeft();
			}
			if (newKeyboardState.IsKeyDown(Keys.Right) || newKeyboardState.IsKeyDown(Keys.D))
			{
				paddle.MoveRight();
			}
			if (oldKeyboardState.IsKeyUp(Keys.Space) && newKeyboardState.IsKeyDown(Keys.Space) && readyToServeBall)
			{
				ServeBall();
			}

			oldMouseState = newMouseState;
			oldKeyboardState = newKeyboardState;

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			spriteBatch.Begin();
			paddle.Draw();
			wall.Draw();
			gameBorder.Draw();

			if (ball.Visible)
			{
				bool inPlay = ball.Move(wall, paddle);
				if (inPlay)
				{
					ball.Draw();
				}
				else
				{
					ballsRemaining--;
					readyToServeBall = true;
				}
			}
			staticBall.Draw();

			string scoreMsg = "Score: " + ball.Score.ToString("00000");
			Vector2 space = gameContent.LabelFont.MeasureString(scoreMsg);
			spriteBatch.DrawString(gameContent.LabelFont, scoreMsg, new Vector2((screenWidth - space.X) / 2, screenHeight - 40), Color.White);
			if (ball.BricksCleared >= 70)
			{
				ball.Visible = false;
				ball.BricksCleared = 0;
				wall = new Wall(1, 50, spriteBatch, gameContent);
				readyToServeBall = true;
			}
			if (readyToServeBall)
			{
				if (ballsRemaining > 0)
				{
					string startMsg = "Press <Space> or Click Mouse to Start";
					Vector2 startSpace = gameContent.LabelFont.MeasureString(startMsg);
					spriteBatch.DrawString(gameContent.LabelFont, startMsg, new Vector2((screenWidth - startSpace.X) / 2, screenHeight / 2), Color.White);
				}
				else
				{
					string endMsg = "Game Over";
					Vector2 endSpace = gameContent.LabelFont.MeasureString(endMsg);
					spriteBatch.DrawString(gameContent.LabelFont, endMsg, new Vector2((screenWidth - endSpace.X) / 2, screenHeight / 2), Color.White);
				}
			}
			spriteBatch.DrawString(gameContent.LabelFont, ballsRemaining.ToString(), new Vector2(40, 10), Color.White);

			spriteBatch.End();

			base.Draw(gameTime);
		}

		private void ServeBall()
		{
			if (ballsRemaining < 1)
			{
				ballsRemaining = 3;
				ball.Score = 0;
				wall = new Wall(1, 50, spriteBatch, gameContent);
			}

			readyToServeBall = false;
			float ballX = paddle.X + (paddle.Width) / 2;
			float ballY = paddle.Y - ball.Height;
			ball.Launch(ballX, ballY, -3, -3);
		}

	}
}
