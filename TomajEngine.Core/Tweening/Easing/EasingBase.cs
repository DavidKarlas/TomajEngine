//
// EasingBase.cs
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

namespace TomajEngine.Tweening.Easing
{
	public enum EasingModes
	{
		In,
		Out,
		InOut,
		OutIn
	}

	public abstract class EasingBase
	{
		public EasingModes EasingMode;

		public double Ease(double normalizedProgress)
		{
			if (normalizedProgress < 0)
				normalizedProgress = 0;
			if (normalizedProgress > 1)
				normalizedProgress = 1;
			switch (EasingMode)
			{
				case EasingModes.In:
					return EaseFunction(normalizedProgress);
				case EasingModes.Out:
					return 1.0 - EaseFunction(1 - normalizedProgress);
				case EasingModes.InOut:
					return (normalizedProgress <= 0.5
						? EaseFunction(normalizedProgress * 2) * 0.5
						: 1.0 - EaseFunction((1 - normalizedProgress) * 2) * 0.5);
				case EasingModes.OutIn:
					return (normalizedProgress >= 0.5
						? EaseFunction(normalizedProgress * 2) * 0.5
						: 1.0 - EaseFunction((1 - normalizedProgress) * 2) * 0.5);
				default:
					throw new InvalidOperationException("EasingMode value is invalid.(" + EasingMode + ")");
			}
		}

		protected abstract double EaseFunction(double value);
	}
}