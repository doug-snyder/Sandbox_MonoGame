using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace AnimatedSpriteTest
{
	class Ship : Sprite
	{
		public Bullet Bullet;
		
		public Ship(Texture2D texture) : base(texture) {}

		public override void Update(GameTime gameTime, List<Sprite> sprites)
		{
			_previousKey = _currentKey;
			_currentKey = Keyboard.GetState();

			if (_currentKey.IsKeyDown(Keys.Space) && _previousKey.IsKeyUp(Keys.Space))
			{
				Shoot(sprites);
			}

			base.Update(gameTime, sprites);
		}

		public void Shoot(List<Sprite> sprites)
		{
			Bullet bullet = Bullet.Clone() as Bullet;
			bullet.Direction = this.Direction;
			bullet.Position = this.Position;
			bullet.RotationAtCreation(Direction);
			bullet.LinearVelocity = this.LinearVelocity * 2;
			bullet.LifeSpan = 2f;
			bullet.Parent = this;

			sprites.Add(bullet);
		}

	}
}
