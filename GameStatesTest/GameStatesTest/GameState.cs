using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameStatesTest
{
	public class GameState : State
	{
		public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content){}

	
		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch){}

		public override void PostUpdate(GameTime gameTime){}

		public override void Update(GameTime gameTime){}


	}
}
