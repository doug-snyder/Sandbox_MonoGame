using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace InterfaceTest
{
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		private Color _backgroundColor = Color.CornflowerBlue;
		private List<Component> _gameComponents;


		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}


		protected override void Initialize()
		{
			var form = (System.Windows.Forms.Form)System.Windows.Forms.Control.FromHandle(this.Window.Handle);
			form.Location = new System.Drawing.Point(450, 250);

			IsMouseVisible = true;

			base.Initialize();
		}


		protected override void LoadContent()
		{
			spriteBatch = new SpriteBatch(GraphicsDevice);

			Button randomButton = new Button(Content.Load<Texture2D>("Controls/button"), Content.Load<SpriteFont>("Fonts/font"))
			{
				Position = new Vector2(350, 100),
				Text = "Random"
			};

			randomButton.Click += RandomButton_Click;

			Button quitButton = new Button(Content.Load<Texture2D>("Controls/button"), Content.Load<SpriteFont>("Fonts/font"))
			{
				Position = new Vector2(350, 250),
				Text = "Quit"
			};

			quitButton.Click += QuitButton_Click;

			_gameComponents = new List<Component>()
			{
				randomButton,
				quitButton
			};
		}


		private void QuitButton_Click(object sender, System.EventArgs e)
		{
			Exit();
		}


		private void RandomButton_Click(object sender, System.EventArgs e)
		{
			Random random = new Random();

			_backgroundColor = new Color(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
		}


		protected override void UnloadContent(){}


		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
			{
				Exit();
			}

			foreach(Component component in _gameComponents)
			{
				component.Update(gameTime);
			}

			base.Update(gameTime);
		}


		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(_backgroundColor);

			spriteBatch.Begin();
			foreach (Component component in _gameComponents)
			{
				component.Draw(gameTime, spriteBatch);
			}
			spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
