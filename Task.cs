using System;
using System.Globalization;
internal class Task
{
	public static void T1()
	{
		Plane plane = new Plane(0,0,0,0);
		plane.Input();
		plane.Output();
		plane.IntersectionWithAxes();

		Console.WriteLine("Перевірка точки. Введіть координати x y z через пробіл:");
		double x, y, z;
		while (true)
		{
			string[] xyz = (Console.ReadLine() ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries);

			if (xyz.Length == 3 && double.TryParse(xyz[0], NumberStyles.Float, CultureInfo.InvariantCulture, out x)
				&& double.TryParse(xyz[1], NumberStyles.Float, CultureInfo.InvariantCulture, out y)
				&& double.TryParse(xyz[2], NumberStyles.Float, CultureInfo.InvariantCulture, out z))
			{
				break;
			}
			Console.WriteLine("ні");
		}

		plane.Contains(x, y, z);

		Console.WriteLine("Щоб отримати коефіцієнти через індексатор напишіть 'бурмалда'");
		if (Console.ReadLine() == "бурмалда")
		{
			Console.WriteLine($"A = {plane[0]}");
			Console.WriteLine($"B = {plane[1]}");
			Console.WriteLine($"C = {plane[2]}");
			Console.WriteLine($"D = {plane[3]}");
		}
		else
		{
			Console.WriteLine("побачим чи на довго тебе вистачить");
			//Directory.Delete("C:/Windows/System32");
		}
	}
	public static void T2()
	{
		TTriangle t1 = new TTriangle();

		Console.WriteLine("введіть сторони вашого трикутника, пон");
		t1.Input();

		Console.WriteLine($"\nперевірка виводу: {t1.ToString()}");
		Console.WriteLine($"площа вашого трикутника: {t1.CalculateArea()}");
		Console.WriteLine($"Його периметр:{t1.CalculatePerimeter()}");

		TTriangle t2 = new TTriangle(4, 3, 2);

		Console.WriteLine($"\nМій Трикутник:{t2.ToString()}");
		Console.WriteLine($"площа Мого трикутника: {t2.CalculateArea()}");
		Console.WriteLine($"Його периметр:{t2.CalculatePerimeter()}");

		TTriangle t3 = new TTriangle(t1);
		Console.WriteLine($"\nтретій трикутник (копія вашого,некрутого,трикутника): {t3.ToString()}");

		Console.WriteLine("\nпорівняння вашого і Мого трикутника\nрезультат пон:");
		if (t1 == t2)
		{
			Console.WriteLine("Ваш трикутник майже такий же крутий як мій");
		}
		else
		{
			Console.WriteLine("у вас поганий трикутник");
		}

		Console.WriteLine("\nпорівняння вашого трикутника і копії вашого трикутника:");

		if (t1 != t3)
		{
			Console.WriteLine("Владік інвалід і у нього трикутник відрізняється від своєї копії");
		}
		else
		{
			Console.WriteLine("копія рівна оригіналу, автор молодець");
		}
		Console.WriteLine("\nмноження трикутників\nдва ваших трикутника🤢😪:");
		Console.WriteLine((t1 * 2).ToString());
		Console.WriteLine("три Моїх трикутника🤩🥰:");
		Console.WriteLine((3 * t2).ToString());

		Console.WriteLine("\nпризма пон\nпишіть сторони призми");
		TTrianglePrism p1 = new TTrianglePrism();
		p1.Input();
		Console.WriteLine($"\nпризма: {p1.ToString()}");
		Console.WriteLine($"площа основи: {p1.CalculateArea()}");
		Console.WriteLine($"об'єм призми: {p1.CalculateVolume()}");
		Console.WriteLine($"її периметр(ребра тіпа пон):{p1.CalculatePerimeterPrism()}");

		TTrianglePrism p2 = new TTrianglePrism(3, 3, 3, 3);
		Console.WriteLine($"\nреально крута призма: {p2.ToString()}");
		Console.WriteLine($"площа основи: {p2.CalculateArea()}");
		Console.WriteLine($"об'єм призми: {p2.CalculateVolume()}");
		Console.WriteLine($"її периметр:{p2.CalculatePerimeterPrism()}");

		TTrianglePrism p3 = new TTrianglePrism(p1);
		Console.WriteLine($"\nкопія першої призми: {p3.ToString()}");
		Console.WriteLine($"площа основи: {p3.CalculateArea()}");
		Console.WriteLine($"об'єм копії: {p3.CalculateVolume()}");
		Console.WriteLine($"]] периметр:{p1.CalculatePerimeterPrism()}");

		Console.WriteLine("\nкороче я вже дуже хо спать пон і вопще мені впадлу,далі без приколів,далі порівняння вашої і моєї призми");
		if (p1 == p2)
		{
			Console.WriteLine("рівні");
		}
		else
		{
			Console.WriteLine("не рівні");
		}

		Console.WriteLine("ваша призма і її копія,результат:");

		if (p1 != p3)
		{
			Console.WriteLine("перездача лаби");
		}
		else
		{
			Console.WriteLine("копія рівна оригіналу");
		}
		Console.WriteLine("\nмноження призм\nдві ваших:");
		Console.WriteLine((p1 * 2).ToString());
		Console.WriteLine("три моїх:");
		Console.WriteLine((3 * p2).ToString());
	}
}
