using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NotMario.Managers;

namespace NotMario
{
	class Player
	{
		Sprite sprite;
		List<Sprite> spriteList;
		GameTime gameTime = new GameTime();

		public Player(Vector2 position)
		{
			sprite = new Sprite(Content_Manager.GetInstance().Textures["mario sprite"], position);
		}

		public void Update()
		{
			sprite.Update(gameTime, spriteList);
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			sprite.Draw(spriteBatch);
		}
	}

}
