using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace CameraTrackingTest
{
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		private Camera _camera;
		private List<Component> _components;
		private Player _player;

		public static int ScreenHeight;
		public static int ScreenWidth;


		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}


		protected override void Initialize()
		{
			ScreenHeight = graphics.PreferredBackBufferHeight;
			ScreenWidth = graphics.PreferredBackBufferWidth;

			base.Initialize();
		}


		protected override void LoadContent()
		{
			spriteBatch = new SpriteBatch(GraphicsDevice);

			_camera = new Camera();
			_player = new Player(Content.Load<Texture2D>("pc"));

			_components = new List<Component>()
			{
				new Sprite(Content.Load<Texture2D>("background")),
				_player,
				new Sprite(Content.Load<Texture2D>("npc"))
			};
		}


		protected override void UnloadContent(){}


		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
			{
				Exit();
			}

			foreach (Component component in _components)
			{
				component.Update(gameTime);
			}

			_camera.Follow(_player);

			base.Update(gameTime);
		}


		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			spriteBatch.Begin(transformMatrix: _camera.Transform);
			foreach (Component component in _components)
			{
				component.Draw(gameTime, spriteBatch);
			}
			spriteBatch.End();

			base.Draw(gameTime);
		}


	}
}
