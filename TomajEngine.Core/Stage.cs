//
// Stage.cs
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

using System;
using System.Diagnostics;
using SFML.Graphics;
using TomajEngine.Drawing;
using TomajEngine.Tweening;

namespace TomajEngine
{
	public class Stage : DisplayObjectContainer
	{
		private bool running = false;
		private RenderWindow renderWindow;
		private TextField fpsText;

		public Stage(RenderWindow renderWindow)
		{
			this.renderWindow = renderWindow;
			renderWindow.Closed += new EventHandler(renderWindow_Closed);
			renderWindow.KeyPressed += new EventHandler<SFML.Window.KeyEventArgs>(renderWindow_KeyPressed);
			fpsText = new TextField(new Text());
			AddChild(fpsText);
		}

		private void renderWindow_KeyPressed(object sender, SFML.Window.KeyEventArgs e)
		{
			if (e.Code == SFML.Window.Keyboard.Key.Escape)
				renderWindow.Close();
		}

		private void renderWindow_Closed(object sender, EventArgs e)
		{
			renderWindow.Close();
		}

		public void Run()
		{
			running = true;
			Stopwatch stageTime = Stopwatch.StartNew();
			TimeSpan lastFrameTime = stageTime.Elapsed;
			while (running && renderWindow.IsOpen())
			{
				TimeSpan currentTime = stageTime.Elapsed;
				//CurrentTime is used because it could happend that stageTime.Elapsed changes beween two following lines
				//and missing some ticks could result in undesirable effects
				TimeSpan elapsedTime = currentTime - lastFrameTime;
				lastFrameTime = currentTime;

				Console.WriteLine(elapsedTime.Milliseconds);

				Update(elapsedTime);
				renderWindow.DispatchEvents();
				renderWindow.Clear(Color.Black);
				Draw(renderWindow);
				renderWindow.Display();
			}
		}

		private void Update(TimeSpan elapsedTime)
		{
			TweenerManager.Update(elapsedTime);
		}

		public override float Alpha
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public override float Rotation
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public override SFML.Window.Vector2f Scale
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public override SFML.Window.Vector2f Position
		{
			get
			{
				return new SFML.Window.Vector2f(renderWindow.Position.X, renderWindow.Position.Y);
			}
			set
			{
				renderWindow.Position = new SFML.Window.Vector2i((int)value.X, (int)value.Y);
			}
		}

		public override SFML.Window.Vector2f Size
		{
			get
			{
				return new SFML.Window.Vector2f(renderWindow.Size.X, renderWindow.Size.Y);
			}
			set
			{
				renderWindow.Size = new SFML.Window.Vector2u((uint)value.X, (uint)value.Y);
			}
		}
	}
}