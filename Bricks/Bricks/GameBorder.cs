using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Bricks
{
	class GameBorder
	{
		public float Width { get; set; }
		public float Height { get; set; }

		private Texture2D ImgPixel { get; set; }
		private SpriteBatch spriteBatch;

		public GameBorder(float screenWidth, float screenHeight, SpriteBatch spriteBatch, GameContent gameContent)
		{
			Width = screenWidth;
			Height = screenHeight;
			ImgPixel = gameContent.ImgPixel;
			this.spriteBatch = spriteBatch;
		}

		public void Draw()
		{
			//draw top border
			spriteBatch.Draw(ImgPixel, new Rectangle(0, 0, (int)Width - 1, 1), Color.White);
			//draw left border
			spriteBatch.Draw(ImgPixel, new Rectangle(0, 0, 1, (int)Height - 1), Color.White);
			//draw right border
			spriteBatch.Draw(ImgPixel, new Rectangle((int)Width - 1, 0, 1, (int)Height - 1), Color.White);
		}

	}
}