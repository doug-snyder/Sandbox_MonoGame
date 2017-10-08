using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NotMario.Screens;

namespace NotMario.Managers
{
	class ScreenManager
	{
		ArrayList Screens;
		Screen CurrentScreen;

		
		public ScreenManager(Rectangle screenSize)
		{
			Screens = new ArrayList();
			Screens.Add(new MenuScreen(screenSize));

			CurrentScreen = (Screen)Screens[0];
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			CurrentScreen.Draw(spriteBatch);
		}

	}
}
