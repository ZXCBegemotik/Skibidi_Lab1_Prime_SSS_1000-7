namespace Skibidi_Lab1_Prime_SSS_1000_7
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int a;
			while (true)
			{
				Console.WriteLine("1-перше завдання\n2-друге завдання");
				while (!int.TryParse(Console.ReadLine(), out a)) Console.WriteLine("ні");
				switch (a)
				{
					case 1:
						Task.T1();
						break;
					case 2:
						Task.T2();
						break;
					default:
						Console.WriteLine("веном");
						break;
				}
			}
		}

	}
}
