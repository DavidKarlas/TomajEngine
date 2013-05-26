//
// TextField.cs
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
	public class TextField : InteractiveObject
	{
		private Text text;

		public TextField(Text text)
		{
			this.text = text;
		}

		public override void Draw(RenderTarget renderTarget)
		{
			renderTarget.Draw(text);
		}

		public override float Alpha
		{
			get
			{
				return text.Color.A / 255.0f;
			}
			set
			{
				text.Color = new Color(255, 255, 255, (byte)(value * 255));
			}
		}

		public override float Rotation
		{
			get
			{
				return text.Rotation;
			}
			set
			{
				text.Rotation = value;
			}
		}

		public override SFML.Window.Vector2f Scale
		{
			get
			{
				return text.Scale;
			}
			set
			{
				text.Scale = value;
			}
		}

		public override SFML.Window.Vector2f Position
		{
			get
			{
				return text.Position;
			}
			set
			{
				text.Position = value;
			}
		}

		public override SFML.Window.Vector2f Size
		{
			get
			{
				return new SFML.Window.Vector2f(text.GetLocalBounds().Width, text.GetLocalBounds().Height);
			}
			set
			{
				//TODO: Calculate and set Scale based on new Size input and old Size
			}
		}
	}
}