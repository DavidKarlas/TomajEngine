//
// TweenedPropertyDouble.cs
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

namespace TomajEngine.Tweening
{
	public class TweenedPropertyDouble : TweenedProperty
	{
		private Action<double> valueSetter;

		public TweenedPropertyDouble(object target, string propertyName, double startValue, double endValue) :
			base(propertyName, startValue, endValue)
		{
		}

		protected override void SetValue(object value)
		{
			valueSetter((double)value);
		}

		public override object Lerp(object startValue, object endValue, double progress)
		{
			return ((double)endValue - (double)startValue) * progress + (double)startValue;
		}

		internal override void CreateSetter(object obj)
		{
			valueSetter = (Action<double>)Delegate.CreateDelegate(typeof(Action<double>), obj, obj.GetType().GetProperty(PropertyName).GetSetMethod());
		}
	}
}