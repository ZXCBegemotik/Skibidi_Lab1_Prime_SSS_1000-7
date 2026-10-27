class TTrianglePrism : TTriangle
{
	private double height;

	public TTrianglePrism() : base()
	{
		height = 0;
	}

	public TTrianglePrism(double a, double b, double c, double height) : base(a, b, c)
	{
		this.height = height;
	}

	public TTrianglePrism(TTrianglePrism other) : base(other)
	{
		height = other.height;
	}

	public override void Input()
	{
		base.Input();

		Console.WriteLine("введіть висоту призми");
		while (!double.TryParse(Console.ReadLine(), out height) || height <= 0)
		{
			Console.WriteLine("ще раз");
		}
	}

	public double CalculateVolume()
	{
		return CalculateArea() * height;
	}
	public double CalculatePerimeterPrism()
	{
		return (a + b + c)*2+3*height;
	}

	public override string ToString()
	{
		return $"{base.ToString()}, h = {height}";
	}
	public static bool operator ==(TTrianglePrism p1, TTrianglePrism p2)
	{
		if (ReferenceEquals(p1, p2)) return true;
		if (p1 is null || p2 is null) return false;

		return (TTriangle)p1 == (TTriangle)p2 &&
			   Math.Abs(p1.height - p2.height) < 1e-6;
	}
	public static bool operator !=(TTrianglePrism p1, TTrianglePrism p2)
	{
		return !(p1 == p2);
	}
	public override bool Equals(object? obj)
	{
		return obj is TTrianglePrism other && this == other;
	}
	public override int GetHashCode()
	{
		return HashCode.Combine(base.GetHashCode(), Math.Round(height, 5));
	}
	public static TTrianglePrism operator *(TTrianglePrism p, double num)
	{
		return new TTrianglePrism(p.a * num, p.b * num, p.c * num, p.height * num);
	}
	public static TTrianglePrism operator *(double num, TTrianglePrism p)
	{
		return p * num;
	}
}