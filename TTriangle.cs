class TTriangle
{
	protected double a;
	protected double b;
	protected double c;

	public TTriangle()
	{
		a = 0;
		b = 0;
		c = 0;
	}

	public TTriangle(double a, double b, double c)
	{
		this.a = a;
		this.b = b;
		this.c = c;
	}

	public TTriangle(TTriangle other)
	{
		a = other.a;
		b = other.b;
		c = other.c;
	}

	public override string ToString()
	{
		return $"a = {a}, b = {b}, c = {c}";
	}

	public double CalculateArea()
	{
		double p = (a + b + c) / 2;
		return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
	}

	public double CalculatePerimeter()
	{
		return a+b+c;
	}

	public virtual bool Invalid(string[] abc)
	{
		return abc.Length < 3 ||
			!double.TryParse(abc[0], out a) ||
			!double.TryParse(abc[1], out b) ||
			!double.TryParse(abc[2], out c) ||
			a <= 0 || b <= 0 || c <= 0 ||
			!(a + b > c) ||
			!(a + c > b) ||
			!(b + c > a);
	}
	public virtual void Input()
	{
		string[] abc = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
		while (Invalid(abc))
		{
			Console.Write("ти шота тіпа не по понятіям пишеш тіпа\n");
			abc = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
		}
	}
	private const double eps = 1e-6;

	public static bool operator ==(TTriangle t1, TTriangle t2)
	{
		if (ReferenceEquals(t1, t2)) return true;
		if (t1 is null || t2 is null) return false;
		double[] sides1 = { t1.a, t1.b, t1.c };
		double[] sides2 = { t2.a, t2.b, t2.c };
		Array.Sort(sides1);
		Array.Sort(sides2);

		return Math.Abs(sides1[0] - sides2[0]) < eps &&
			   Math.Abs(sides1[1] - sides2[1]) < eps &&
			   Math.Abs(sides1[2] - sides2[2]) < eps;
	}

	public static bool operator !=(TTriangle t1, TTriangle t2)
	{
		return !(t1 == t2);
	}

	public override bool Equals(object? obj)
	{
		return obj is TTriangle other && this == other;
	}

	public override int GetHashCode()
	{
		double[] sides = { a, b, c };
		Array.Sort(sides);
		return HashCode.Combine(Math.Round(sides[0], 5),Math.Round(sides[1], 5),Math.Round(sides[2], 5));
	}

	public static TTriangle operator *(TTriangle tri, double num)
	{
		return new TTriangle(tri.a * num,tri.b * num,tri.c * num
		);
	}

	public static TTriangle operator *(double number, TTriangle triangle)
	{
		return triangle * number;
	}
}
