using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NotMario.Managers;

namespace NotMario.Screens
{
	class TempScreen : Screen
	{
		public TempScreen(Rectangle screenSize)
			: base(screenSize)
		{

		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(Content_Manager.GetInstance().Textures["mario1"], new Vector2(300, 300), Color.Blue);
		}

	}
}
