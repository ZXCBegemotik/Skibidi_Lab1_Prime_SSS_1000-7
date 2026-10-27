using System.Globalization;
using System.Numerics;

class Plane
{
	private double A, B, C, D;

	public Plane() { }

	public Plane(double a, double b, double c, double d)
	{
		A = a; B = b; C = c; D = d;
	}

	public double this[int index]
	{
		get
		{
			return index switch
			{
				0 => A,
				1 => B,
				2 => C,
				3 => D,
				_ => throw new IndexOutOfRangeException("Індекс має бути від 0 до 3")
			};
		}
		set
		{
			switch (index)
			{
				case 0: A = value; break;
				case 1: B = value; break;
				case 2: C = value; break;
				case 3: D = value; break;
				default: throw new IndexOutOfRangeException("Індекс має бути від 0 до 3");
			}
		}
	}

	public void Input()
	{
		bool invalid = true;

		while (invalid)
		{
			Console.WriteLine("Введіть A B C D в один рядок через пробіл:");
			string[] parts = (Console.ReadLine() ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries);

			if (parts.Length == 4
				&& double.TryParse(parts[0], out double a)
				&& double.TryParse(parts[1], out double b)
				&& double.TryParse(parts[2], out double c)
				&& double.TryParse(parts[3], out double d))
			{
				if (a == 0 && b == 0 && c == 0)
				{
					Console.WriteLine("A, B, C не можуть бути одночасно пулями.");
				}
				else
				{
					A = a; B = b; C = c; D = d;
					invalid = false;
				}
			}
			else
			{
				Console.WriteLine("Некоректне введення, спробуйте ще раз.");
			}
		}
	}

	public void Output()
	{
		if (!IsValid())
		{
			Console.WriteLine("Це не площина: A, B, C дорівнюють нулю.");
			return;
		}
		string equation = AddTerm(A, "x") + AddTerm(B, "y") + AddTerm(C, "z") + AddTerm(D, "");

		if (equation == "") equation = "0";
		else if (equation.StartsWith(" + ")) equation = equation.Substring(3);   
		else equation = "-" + equation.Substring(3);                             

		Console.WriteLine($"Рівняння площини: {equation} = 0");
	}

	private static string AddTerm(double coef, string variable)
	{
		if (coef == 0) return "";

		double abs = Math.Abs(coef);
		return (coef < 0 ? " - " : " + ") + (variable != "" && abs == 1 ? "" : abs.ToString()) + variable;
	}

	public void IntersectionWithAxes()
	{
		if (!IsValid())
		{
			Console.WriteLine("Перевірки перетинів не буде");
			return;
		}
		PrintAxis("Ox", A, 'x');
		PrintAxis("Oy", B, 'y');
		PrintAxis("Oz", C, 'z');
	}

	private void PrintAxis(string axis, double coef, char name)
	{
		if (coef == 0)
		{
			if (D == 0) Console.WriteLine($"Вісь {axis} лежить у площині.");
			else Console.WriteLine($"Площина не перетинає вісь {axis}.");
			return;
		}

		double t = -D / coef;
		string point = "";

		switch (name)
		{
			case 'x':
				point = $"({t}; 0; 0)";
				break;
			case 'y':
				point = $"(0; {t}; 0)";
				break;
			case 'z':
				point = $"(0; 0; {t})";
				break;
			default:
				Console.WriteLine("пон");
				break;
		}
		Console.WriteLine($"Перетин з віссю {axis}: {point}");
	}

	public void Contains(double x, double y, double z)
	{
		if (!IsValid())
		{
			if (D == 0) Console.WriteLine("Ріняння 0=0 виконується завжди,перевірка точок немає сенсу");
			else Console.WriteLine("перевірка точок немає сенсу,жодна з них не лежить на площині");
		}
		if (Math.Abs(A * x + B * y + C * z + D) < 1e-9) Console.WriteLine("Точка належить площині.");
		else Console.WriteLine("Точка не належить площині.");
	}
	private bool IsValid()
{
    return A != 0 || B != 0 || C != 0;
}
}