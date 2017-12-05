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
		public Vector2 Origin;
		public float RotationalOffset = 0f;
		public float Speed = 5f;
		public float RotationVelocity = 5f;
		public float LinearVelocity = 10f;
	
		private float _rotation;


		public Sprite(Texture2D texture)
		{
			_texture = texture;
		}

		public void Update()
		{
			//Move();
			Rotate();
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

		private void Rotate()
		{
			if (Input == null)
			{
				return;
			}

			if (Keyboard.GetState().IsKeyDown(Input.Left))
			{
				_rotation -= MathHelper.ToRadians(RotationVelocity);
			}
			if (Keyboard.GetState().IsKeyDown(Input.Right))
			{
				_rotation += MathHelper.ToRadians(RotationVelocity);
			}

			Vector2 direction = new Vector2((float)Math.Cos(RotationalOffset - _rotation), -(float)Math.Sin(RotationalOffset - _rotation));

			if (Keyboard.GetState().IsKeyDown(Input.Up))
			{
				Position += direction * LinearVelocity;
			}
			if (Keyboard.GetState().IsKeyDown(Input.Down))
			{
				Position -= direction * LinearVelocity;
			}
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(_texture, Position, null, Color.White, _rotation, Origin, 1, SpriteEffects.None, 0f);
		}

	}
}
