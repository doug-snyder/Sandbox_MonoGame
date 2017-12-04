using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace AnimatedSpriteTest
{
	class Sprite
	{
		private Texture2D _texture;

		public Input Input;
		public Vector2 Position;
		public float Speed = 2f;


		public Sprite(Texture2D texture)
		{
			_texture = texture;
		}

		public void Update()
		{
			Move();
		}

		private void Move()
		{
			if (Input == null)
			{
				return;
			}

			if (Keyboard.GetState().IsKeyDown(Input.Up))
			{
				Position.Y -= Speed;
			}
			if (Keyboard.GetState().IsKeyDown(Input.Left))
			{
				Position.X -= Speed;
			}
			if (Keyboard.GetState().IsKeyDown(Input.Down))
			{
				Position.Y += Speed;
			}
			if (Keyboard.GetState().IsKeyDown(Input.Right))
			{
				Position.X += Speed;
			}
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(_texture, Position, Color.White);
		}

	}
}
