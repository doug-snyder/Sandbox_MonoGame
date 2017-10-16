using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NotMario.Managers;


namespace NotMario
{
	class Sprite
	{
		protected AnimationManager _animationManager;
		protected Dictionary<string, Animation> _animations;
		protected Vector2 _position;
		public Input input;
		protected Texture2D _texture;
		public float Speed = 1.0f;
		public Vector2 Velocity;
		private Rectangle _bounds;


		public Vector2 Position
		{
			get { return _position; }
			set
			{
				_position = value;

				if(_animationManager != null)
				{
					_animationManager.Position = _position;
				}
			}
		}

		public Sprite(Dictionary<string, Animation> animations)
		{
			_animations = animations;
			_animationManager = new AnimationManager(_animations.First().Value);
		}

		public Sprite(Texture2D texture, Vector2 position)
		{
			_texture = texture;
			Position = position;
			_bounds = _texture.Bounds;
		}

		public virtual void Move()
		{
			if (Keyboard.GetState().IsKeyDown(Keys.W))
			{
				Velocity.Y = -Speed;
			}
			if (Keyboard.GetState().IsKeyDown(Keys.A))
			{
				Velocity.X = -Speed;
			}
			if (Keyboard.GetState().IsKeyDown(Keys.S))
			{
				Velocity.Y = Speed;
			}
			if (Keyboard.GetState().IsKeyDown(Keys.D))
			{
				Velocity.X = Speed;
			}
			/*
			if (Keyboard.GetState().IsKeyDown(input.Up))
			{
				Velocity.Y = -Speed;
			}
			if (Keyboard.GetState().IsKeyDown(input.Left))
			{
				Velocity.X = -Speed;
			}
			if (Keyboard.GetState().IsKeyDown(input.Down))
			{
				Velocity.Y = Speed;
			}
			if (Keyboard.GetState().IsKeyDown(input.Right))
			{
				Velocity.X = Speed;
			}*/
		}

		public virtual void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(_texture, Position, _bounds, Color.White);
		}

		public Sprite(Texture2D texture)
		{
			_texture = texture;
		}

		public virtual void Update(GameTime gameTime, List<Sprite> sprites)
		{
			Move();

			//SetAnimations();

			Position += Velocity;
			Velocity = Vector2.Zero;
		}

		private void SetAnimations()
		{
			if (Velocity.X > 0)
			{
				_animationManager.Play(_animations["WalkRight"]);
			}
			else if (Velocity.X < 0)
			{
				_animationManager.Play(_animations["WalkLeft"]);
			}
			else if (Velocity.Y > 0)
			{
				_animationManager.Play(_animations["WalkDown"]);
			}
			else if (Velocity.Y < 0)
			{
				_animationManager.Play(_animations["WalkUp"]);
			}
		}

	}
}
