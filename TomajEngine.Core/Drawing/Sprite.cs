//
// Sprite.cs
//
// Author:
//       David Karlaš <david.karlas@gmail.com>
//
// Copyright (c) 2013 David Karlaš
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using SFML.Graphics;

namespace TomajEngine.Drawing
{
	public class Sprite : DisplayObjectContainer
	{
		private SFML.Graphics.Sprite sprite;

		private Sprite(SFML.Graphics.Sprite sprite)
		{
			this.sprite = sprite;
		}

		public Sprite(string path) :
			this(new SFML.Graphics.Sprite(new Texture(path)))
		{
		}

		public override void Draw(RenderTarget renderTarget)
		{
			renderTarget.Draw(sprite);
		}

		public override float Alpha
		{
			get
			{
				return sprite.Color.A / 255.0f;
			}
			set
			{
				sprite.Color = new Color(255, 255, 255, (byte)(value * 255));
			}
		}

		public override float Rotation
		{
			get
			{
				return sprite.Rotation;
			}
			set
			{
				sprite.Rotation = value;
			}
		}

		public override SFML.Window.Vector2f Scale
		{
			get
			{
				return sprite.Scale;
			}
			set
			{
				sprite.Scale = value;
			}
		}

		public override SFML.Window.Vector2f Position
		{
			get
			{
				return sprite.Position;
			}
			set
			{
				sprite.Position = value;
			}
		}

		public override SFML.Window.Vector2f Size
		{
			get
			{
				return new SFML.Window.Vector2f(sprite.GetLocalBounds().Width, sprite.GetLocalBounds().Height);
			}
			set
			{
				//TODO: Calculate and set Scale based on new Size input and old Size
			}
		}
	}
}