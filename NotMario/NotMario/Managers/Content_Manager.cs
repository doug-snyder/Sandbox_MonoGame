using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotMario.Managers
{
	class Content_Manager
	{
		private static Content_Manager instance;
		ContentManager CM;

		public Dictionary<String, Texture2D> Textures;
		public Dictionary<String, TextureAtlas> TextureAtlases;


		private Content_Manager()
		{
			Textures = new Dictionary<String, Texture2D>();
		}

		public static Content_Manager GetInstance()
		{
			if (instance == null)
			{
				instance = new Content_Manager();
			}
			return instance;
		}

		public void LoadTextures(ContentManager content)
		{
			CM = content;
			AddTexture("mario sprite");
			AddTexture("menu_screen");
			AddTexture("brick");
			AddTexture("ground");
			AddTexture("scenery hill");
			AddTexture("coinsAnim");
		}

		public void AddTexture(String file, String name = "")
		{
			Texture2D newTexture = CM.Load<Texture2D>(file);
			if (name == "")
			{
				Textures.Add(file, newTexture);
			}
			else
			{
				Textures.Add(name, newTexture);
			}
		}

	}
}
