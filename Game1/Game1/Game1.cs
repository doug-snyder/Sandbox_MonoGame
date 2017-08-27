using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		private Texture2D background;
		private Texture2D shuttle;
		private Texture2D earth;

		private SpriteFont scoreFont;
		private int score = 0;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}

		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		protected override void Initialize()
		{


			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			spriteBatch = new SpriteBatch(GraphicsDevice);

			background = Content.Load<Texture2D>("Images/stars");
			shuttle = Content.Load<Texture2D>("Images/shuttle");
			earth = Content.Load<Texture2D>("Images/earth");

			scoreFont = Content.Load<SpriteFont>("Score");
		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// game-specific content.
		/// </summary>
		protected override void UnloadContent()
		{

		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
			{
				Exit();
			}

			score++;

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			spriteBatch.Begin();
			/*
			spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.White);
			spriteBatch.Draw(shuttle, new Vector2(450, 240), Color.White);
			spriteBatch.Draw(earth, new Vector2(400, 240), Color.White);
			*/

			spriteBatch.DrawString(scoreFont, "Score: " + score, new Vector2(100, 100), Color.Black);
			spriteBatch.End();

			base.Draw(gameTime);
		}

	} //Game1
} //namespace
