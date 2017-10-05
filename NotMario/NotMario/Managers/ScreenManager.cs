using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotMario.Managers
{
	class ScreenManager
	{
		ArrayList Screens;
		Screen CurrentScreen;

		
		public ScreenManager()
		{
			Screens = new ArrayList();
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			CurrentScreen.Draw();
		}

	}
}
