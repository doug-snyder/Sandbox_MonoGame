using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

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
			bullet.LinearVelocity = this.LinearVelocity * 2;
			bullet.LifeSpan = 2f;
			bullet.Parent = this;

			sprites.Add(bullet);
		}

	}
}
