using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;

namespace NotMario.Managers
{
	class TileManager
	{
		ArrayList tiles;


		public TileManager()
		{
			tiles = new ArrayList();
		}

		public void AddTile(Texture2D texture, Vector2 position, Vector2? offset = null)
		{
			tiles.Add(new Tile(texture, position, offset));
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			foreach (Tile tile in tiles)
			{
				spriteBatch.Draw(tile.texture, new Vector2(tile.position.X * 32, tile.position.Y * 32) + tile.offset, Color.White);
			}
		}

	}

	class Tile
	{
		public Texture2D texture;
		public Vector2 position;
		public Vector2 offset;


		public Tile(Texture2D texture, Vector2 position, Vector2? offset)
		{
			this.texture = texture;
			this.position = position;
			this.offset = (offset == null ? new Vector2(0, 0) : offset.Value);
		}
	}
}
