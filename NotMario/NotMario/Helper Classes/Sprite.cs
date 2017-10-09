using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NotMario.Helper_Classes
{
	class Sprite
	{
		Texture2D _texture;
		Vector2 _position;
		Rectangle _bounds;


		public Sprite(Texture2D texture, Vector2 position)
		{
			_texture = texture;
			_position = position;

			_bounds = _texture.Bounds;
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(_texture, _position, _bounds, Color.White);
		}

	}
}
