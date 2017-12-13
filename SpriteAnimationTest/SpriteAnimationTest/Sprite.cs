using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace SpriteAnimationTest
{
	public class Sprite
	{
		protected Texture2D _texture;
		protected AnimationManager _animationManager;
		protected Dictionary<string, Animation> _animations;
		protected Vector2 _position;

		public Vector2 Position
		{
			get { return _position; }
			set
			{
				_position = value;

				if (_animationManager != null)
				{
					_animationManager.Position = _position;
				}
			}
		}
		public Vector2 Velocity;
		public float Speed;
		public Input Input;

		public Rectangle Rectangle
		{
			get
			{
				return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
			}
		}


		public Sprite(Texture2D texture)
		{
			_texture = texture;
		}


		public Sprite(Dictionary<string, Animation> animations)
		{
			_animations = animations;
			_animationManager = new AnimationManager(_animations.First().Value);
		}


		public virtual void Update(GameTime gameTime, List<Sprite> sprites)
		{
			Move();

			SetAnimations();

			_animationManager.Update(gameTime);

			Position += Velocity;
			Velocity = Vector2.Zero;
		}


		public virtual void Draw(SpriteBatch spriteBatch)
		{
			if (_texture != null)
			{
				spriteBatch.Draw(_texture, Position, Color.White);
			}
			else if (_animationManager != null)
			{
				_animationManager.Draw(spriteBatch);
			}
			else throw new System.Exception("No texture or animation?!");
		}


		protected virtual void Move()
		{
			if (Keyboard.GetState().IsKeyDown(Input.Left))
			{
				Velocity.X = -Speed;
			}
			else if (Keyboard.GetState().IsKeyDown(Input.Right))
			{
				Velocity.X = Speed;
			}
			else if (Keyboard.GetState().IsKeyDown(Input.Up))
			{
				Velocity.Y = -Speed;
			}
			else if (Keyboard.GetState().IsKeyDown(Input.Down))
			{
				Velocity.Y = Speed;
			}
		}


		protected virtual void SetAnimations()
		{
			if (Velocity.X > 0)
			{
				_animationManager.Play(_animations["walkingRight"]);
			}
			else if (Velocity.X < 0)
			{
				_animationManager.Play(_animations["walkingLeft"]);
			}
			else if (Velocity.Y > 0)
			{
				_animationManager.Play(_animations["walkingDown"]);
			}
			else if (Velocity.Y < 0)
			{
				_animationManager.Play(_animations["walkingUp"]);
			}
			else
			{
				_animationManager.Stop();
			}
		}


		protected bool IsTouchingLeft(Sprite sprite)
		{
			return this.Rectangle.Right + this.Velocity.X > sprite.Rectangle.Left &&
				   this.Rectangle.Left < sprite.Rectangle.Left &&
				   this.Rectangle.Bottom > sprite.Rectangle.Top &&
				   this.Rectangle.Top < sprite.Rectangle.Bottom;
		}
		protected bool IsTouchingRight(Sprite sprite)
		{
			return this.Rectangle.Left + this.Velocity.X < sprite.Rectangle.Right &&
				   this.Rectangle.Right > sprite.Rectangle.Right &&
				   this.Rectangle.Bottom > sprite.Rectangle.Top &&
				   this.Rectangle.Top < sprite.Rectangle.Bottom;
		}
		protected bool IsTouchingTop(Sprite sprite)
		{
			return this.Rectangle.Bottom + this.Velocity.Y > sprite.Rectangle.Top &&
				   this.Rectangle.Top < sprite.Rectangle.Top &&
				   this.Rectangle.Right > sprite.Rectangle.Left &&
				   this.Rectangle.Left < sprite.Rectangle.Right;
		}
		protected bool IsTouchingBottom(Sprite sprite)
		{
			return this.Rectangle.Top + this.Velocity.Y < sprite.Rectangle.Bottom &&
				   this.Rectangle.Bottom > sprite.Rectangle.Bottom &&
				   this.Rectangle.Right > sprite.Rectangle.Left &&
				   this.Rectangle.Left < sprite.Rectangle.Right;
		}


	}
}
