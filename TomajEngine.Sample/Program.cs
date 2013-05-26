using System;
using SFML.Graphics;
using SFML.Window;
using TomajEngine.Drawing;
using TomajEngine.Tweening;

namespace TomajEngine.Sample
{
	internal static class Program
	{
		private static Stage game;
		private static Bitmap bitmap;

		private static void Main()
		{
			game = new Stage(new RenderWindow(new VideoMode(800, 600, 32), "TomajEngine"));
			bitmap = new Bitmap("resources\\devices.png", new IntRect(0, 0, 96, 96));
			game.AddChild(bitmap);
			var textField = new TextField(new Text("Tomaj Engine", new Font("resources\\sansation.ttf"), 20));
			game.AddChild(textField);
			bitmap.Position = new Vector2f(100, 100);
			Tweener.To(textField, TimeSpan.FromSeconds(2), new TweenedPropertyVector2f("Position", new Vector2f(200, 200), new Vector2f(400, 400)));
			Tweener.To(textField, TimeSpan.FromSeconds(2), new TweenedPropertyFloat("Rotation", 0, 90));
			tweener_Complete(null);
			game.Run();
		}

		private static void tweener_Complete(Tweener obj)
		{
			if (bitmap.Alpha == 0)
				Tweener.To(bitmap, 2000, new TweenedPropertyFloat("Alpha", 0, 1), new TweenedPropertyVector2f("Position", bitmap.Position, new Vector2f(100, 100))).Complete += tweener_Complete;
			else
				Tweener.To(bitmap, 2000, new TweenedPropertyFloat("Alpha", 1, 0), new TweenedPropertyVector2f("Position", bitmap.Position, new Vector2f(300, 300))).Complete += tweener_Complete;
		}
	}
}