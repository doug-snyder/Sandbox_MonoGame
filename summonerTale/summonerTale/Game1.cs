using summonerTale.StateManager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace summonerTale
{
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		GameStateManager gameStateManager;
		ITitleIntroState titleIntroState;
		static Rectangle screenRectangle;

		public SpriteBatch SpriteBatch
		{
			get { return spriteBatch; }
		}

		public static Rectangle ScreenRectangle
		{
			get { return screenRectangle; }
		}

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			screenRectangle = new Rectangle(0, 0, 1280, 720);
			graphics.PreferredBackBufferWidth = ScreenRectangle.Width;
			graphics.PreferredBackBufferHeight = ScreenRectangle.Height;
			gameStateManager = new GameStateManager(this);
			Components.Add(gameStateManager);
			titleIntroState = new TitleIntroState(this);
			gameStateManager.ChangeState((TitleIntroState)titleIntroState, PlayerIndex.One);
		}

		protected override void Initialize()
		{
			var form = (System.Windows.Forms.Form)System.Windows.Forms.Control.FromHandle(this.Window.Handle);
			form.Location = new System.Drawing.Point(450, 250);

			base.Initialize();
		}

		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);
			// TODO: use this.Content to load your game content here
		}

		protected override void UnloadContent()
		{
			// TODO: Unload any non ContentManager content here
		}

		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
			{
				Exit();
			}

			// TODO: Add your update logic here

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			// TODO: Add your drawing code here

			base.Draw(gameTime);
		}
	}
}