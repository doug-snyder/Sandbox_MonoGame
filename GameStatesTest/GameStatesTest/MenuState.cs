using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameStatesTest
{
	public class MenuState : State
	{
		private List<Component> _components;

		public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager contentManager) : base(game, graphicsDevice, contentManager)
		{
			Texture2D buttonTexture = _content.Load<Texture2D>("Controls/button");
			SpriteFont font = _content.Load<SpriteFont>("Fonts/Font");

			Button newGameButton = new Button(buttonTexture, font)
			{
				Position = new Vector2(300, 150),
				Text = "New Game"
			};

			newGameButton.Click += NewGameButton_Click;

			Button loadGameButton = new Button(buttonTexture, font)
			{
				Position = new Vector2(300, 250),
				Text = "Load Game"
			};

			loadGameButton.Click += LoadGameButton_Click;

			Button quitGameButton = new Button(buttonTexture, font)
			{
				Position = new Vector2(300, 350),
				Text = "Quit Game"
			};

			quitGameButton.Click += QuitGameButton_Click;

			_components = new List<Component>()
			{
				newGameButton,
				loadGameButton,
				quitGameButton
			};
		}


		private void QuitGameButton_Click(object sender, EventArgs e)
		{
			_game.Exit();
		}

		private void LoadGameButton_Click(object sender, EventArgs e)
		{
			Console.WriteLine("Load");
		}

		private void NewGameButton_Click(object sender, EventArgs e)
		{
			_game.ChangeState(new GameState(_game, _graphicsDevice, _content));
		}

		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			spriteBatch.Begin();
			foreach(Component component in _components)
			{
				component.Draw(gameTime, spriteBatch);
			}
			spriteBatch.End();
		}

		public override void PostUpdate(GameTime gameTime){}

		public override void Update(GameTime gameTime)
		{
			foreach (Component component in _components)
			{
				component.Update(gameTime);
			};
		}
	}
}
