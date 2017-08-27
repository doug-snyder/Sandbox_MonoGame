using System;
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

		/*
		private Texture2D background;
		private Texture2D shuttle;
		private Texture2D earth;
		*/
		/*
		private SpriteFont scoreFont;
		private int score = 0;
		*/
		/*
		private Texture2D arrow;
		private float angle = 0;
		*/
		//private AnimatedSprite animatedSprite;

		private Texture2D red;
		private Texture2D green;
		private Texture2D blue;

		private float blueAngle = 0;
		private float greenAngle = 0;
		private float redAngle = 0;

		private float blueSpeed = 0.025f;
		private float greenSpeed = 0.017f;
		private float redSpeed = 0.022f;

		private float distance = 100;

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

			/*
			background = Content.Load<Texture2D>("Images/stars");
			shuttle = Content.Load<Texture2D>("Images/shuttle");
			earth = Content.Load<Texture2D>("Images/earth");
			*/

			//scoreFont = Content.Load<SpriteFont>("Score");

			//Texture2D texture = Content.Load<Texture2D>("Atlases/SmileyWalk");
			//animatedSprite = new AnimatedSprite(texture, 4, 4);

			//arrow = Content.Load<Texture2D>("Images/arrow");

			red = Content.Load<Texture2D>("Images/red");
			green = Content.Load<Texture2D>("Images/green");
			blue = Content.Load<Texture2D>("Images/blue");
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

			//score++;

			//animatedSprite.Update();

			//angle += 0.01f;

			blueAngle += blueSpeed;
			greenAngle += greenSpeed;
			redAngle += redSpeed;

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Black);

			Vector2 bluePosition = new Vector2(
							(float)Math.Cos(blueAngle) * distance,
							(float)Math.Sin(blueAngle) * distance);
			Vector2 greenPosition = new Vector2(
							(float)Math.Cos(greenAngle) * distance,
							(float)Math.Sin(greenAngle) * distance);
			Vector2 redPosition = new Vector2(
							(float)Math.Cos(redAngle) * distance,
							(float)Math.Sin(redAngle) * distance);

			Vector2 center = new Vector2(300, 140);

			spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive);

			/*
			spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.White);
			spriteBatch.Draw(shuttle, new Vector2(450, 240), Color.White);
			spriteBatch.Draw(earth, new Vector2(400, 240), Color.White);
			*/
			//spriteBatch.DrawString(scoreFont, "Score: " + score, new Vector2(100, 100), Color.Black);
			/*
			Vector2 location = new Vector2(400, 240);
			Rectangle sourceRectangle = new Rectangle(0, 0, arrow.Width, arrow.Height);
			Vector2 origin = new Vector2(arrow.Width / 2, arrow.Height);
			spriteBatch.Draw(arrow, location, sourceRectangle, Color.White, angle, origin, 1.0f, SpriteEffects.None, 1);
			*/

			spriteBatch.Draw(blue, center + bluePosition, Color.White);
			spriteBatch.Draw(green, center + greenPosition, Color.White);
			spriteBatch.Draw(red, center + redPosition, Color.White);

			spriteBatch.End();

			//animatedSprite.Draw(spriteBatch, new Vector2(400, 200));

			base.Draw(gameTime);
		}

	} //Game1
} //namespace
