using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameStatesTest
{
	class Button : Component
	{
		private MouseState _currentMouseState;
		private SpriteFont _font;
		private bool _isHovering;
		private MouseState _previousMouseState;
		private Texture2D _texture;

		public event EventHandler Click;
		public bool Clicked { get; private set; }
		public Color PenColor { get; set; }
		public Vector2 Position { get; set; }
		public Rectangle Rectangle
		{
			get
			{
				return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
			}
		}
		public String Text { get; set; }


		public Button(Texture2D texture, SpriteFont font)
		{
			_texture = texture;
			_font = font;
			PenColor = Color.Black;
		}


		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			Color color = Color.White;

			if (_isHovering)
			{
				color = Color.Gray;
			}

			spriteBatch.Draw(_texture, Rectangle, color);

			if (!string.IsNullOrEmpty(Text))
			{
				float x = (Rectangle.X + (Rectangle.Width / 2)) - (_font.MeasureString(Text).X / 2);
				float y = (Rectangle.Y + (Rectangle.Height / 2)) - (_font.MeasureString(Text).Y / 2);

				spriteBatch.DrawString(_font, Text, new Vector2(x, y), PenColor);
			}
		}


		public override void Update(GameTime gameTime)
		{
			_previousMouseState = _currentMouseState;
			_currentMouseState = Mouse.GetState();

			Rectangle mouseRectangle = new Rectangle(_currentMouseState.X, _currentMouseState.Y, 1, 1);
			_isHovering = false;

			if (mouseRectangle.Intersects(Rectangle))
			{
				_isHovering = true;

				if (_currentMouseState.LeftButton == ButtonState.Released && _previousMouseState.LeftButton == ButtonState.Pressed)
				{
					Click?.Invoke(this, new EventArgs());
				}
			}
		}


	}
}
