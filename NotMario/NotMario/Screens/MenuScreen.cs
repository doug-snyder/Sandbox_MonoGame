using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using NotMario.Managers;

namespace NotMario.Screens
{
	class MenuScreen : Screen
	{
		Texture2D MenuLogo;
		TileManager tileManager;


		public MenuScreen(Rectangle screenSize)
			: base(screenSize)
		{
			MenuLogo = Content_Manager.GetInstance().Textures["menu screen"];
			tileManager = new TileManager();

			tileManager.AddTile(Content_Manager.GetInstance().Textures["scenery hill"], new Vector2(2, ScreenSize.Height / 32 - 3));
			tileManager.AddTile(Content_Manager.GetInstance().Textures["scenery hill"], new Vector2(12, ScreenSize.Height / 32 - 3));

			for (int x = 0; x <= ScreenSize.Width / 32; x++)
			{
				tileManager.AddTile(Content_Manager.GetInstance().Textures["ground"], new Vector2(x, ScreenSize.Height / 32));
				tileManager.AddTile(Content_Manager.GetInstance().Textures["ground"], new Vector2(x, ScreenSize.Height / 32 - 1));
			}

			tileManager.AddTile(Content_Manager.GetInstance().Textures["mario sprite"], new Vector2(4, ScreenSize.Height / 32 - 3), new Vector2(0, 21));
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(MenuLogo, new Vector2(ScreenSize.Width / 2 - MenuLogo.Width / 2, 75), Color.White);
			tileManager.Draw(spriteBatch);
		}

	}
}
