//
// Tweener.cs
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
using System.Collections.Generic;

namespace TomajEngine.Tweening
{
	public partial class Tweener
	{
		private object obj;
		private TweenerParameters tweenerParameters;
		private TimeSpan tweenedTime;
		private List<TweenedProperty> props = new List<TweenedProperty>();

		public Tweener(object obj, TweenerParameters tweenerParameters, TweenedProperty[] values)
		{
			this.obj = obj;
			this.tweenerParameters = tweenerParameters;
			foreach (var val in values)
			{
				val.CreateSetter(obj);
				props.Add(val);
			}
			TweenerManager.AddTweener(this);
		}

		public event Action<Tweener> Complete;

		internal bool Update(TimeSpan elapsedTime)
		{
			tweenedTime += elapsedTime;
			double progress = (double)tweenedTime.Ticks / tweenerParameters.Duration.Ticks;
			if (progress >= 1)
			{
				foreach (var prop in props)
				{
					prop.Value = prop.EndValue;
				}
				if (Complete != null)
					Complete(this);
				return true;
			}
			else
			{
				foreach (var prop in props)
				{
					prop.Value = prop.Lerp(prop.StartValue, prop.EndValue, tweenerParameters.Easing.Ease(progress));
				}
				return false;
			}
		}
	}
}