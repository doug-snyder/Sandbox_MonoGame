using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NotMario.Screens
{
	class Screen
	{
		public Rectangle ScreenSize;


		public Screen(Rectangle screenSize)
		{
			ScreenSize = screenSize;
		}

		public virtual void Draw(SpriteBatch spriteBatch){}

	}
}
