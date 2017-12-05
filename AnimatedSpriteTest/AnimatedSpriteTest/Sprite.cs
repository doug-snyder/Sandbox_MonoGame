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
	class Sprite : ICloneable
	{
		protected Texture2D _texture;
		protected float _rotation;
		protected KeyboardState _currentKey;
		protected KeyboardState _previousKey;

		public Input Input;
		public Vector2 Position;
		public Vector2 Origin;
		public Vector2 Direction;
		public float RotationalOffset = 0f;
		public float RotationVelocity = 5f;
		public float LinearVelocity = 10f;
		public float LifeSpan = 0f;
		public bool IsRemoved = false;

		public Sprite Parent;
	
		
		public Sprite(Texture2D texture)
		{
			_texture = texture;
			Origin = new Vector2(_texture.Width / 2, _texture.Height / 2);
		}

		public virtual void Update(GameTime gameTime, List<Sprite> sprites)
		{
			//Move();
			RotateAndMove();
		}

		private void Move()
		{
			if (Input == null)
			{
				return;
			}

			if (Keyboard.GetState().IsKeyDown(Input.Up))
			{
				Position.Y -= LinearVelocity;
			}
			if (Keyboard.GetState().IsKeyDown(Input.Left))
			{
				Position.X -= LinearVelocity;
			}
			if (Keyboard.GetState().IsKeyDown(Input.Down))
			{
				Position.Y += LinearVelocity;
			}
			if (Keyboard.GetState().IsKeyDown(Input.Right))
			{
				Position.X += LinearVelocity;
			}
		}

		private void RotateAndMove()
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

			Direction = new Vector2((float)Math.Cos(RotationalOffset - _rotation), -(float)Math.Sin(RotationalOffset - _rotation));

			if (Keyboard.GetState().IsKeyDown(Input.Up))
			{
				Position += Direction * LinearVelocity;
			}
			if (Keyboard.GetState().IsKeyDown(Input.Down))
			{
				Position -= Direction * LinearVelocity;
			}
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(_texture, Position, null, Color.White, _rotation, Origin, 1, SpriteEffects.None, 0);
		}

		public object Clone()
		{
			return this.MemberwiseClone();
		}

	}
}
