namespace NehorohKode_Pz_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
			Console.WriteLine("🌀 ChronoCrypt Activation Sequence 🌀");

			Console.Write("\nEnter temporal signature");
			string input = Console.ReadLine();

			if (Vortex.Verify(input))
			{
				string converted = Vortex.Transmute(input);
				string day = Vortex.Reveal(input);

				Console.WriteLine($"{converted}");
				Console.WriteLine($"{day}");
			}
			else
			{
				Console.WriteLine("Invalid");
			}

			Console.Write("\nEnter first quantum coordinates");
			var parts1 = Console.ReadLine().Split(' ');

			if (parts1.Length == 3 &&
				int.TryParse(parts1[0], out int d1) &&
				int.TryParse(parts1[1], out int m1) &&
				int.TryParse(parts1[2], out int y1) &&
				Vortex.Verify($"{d1}/{m1}/{y1}"))
			{
				Quantum q1 = new Quantum(d1, m1, y1);

				Console.Write("Enter second quantum coordinates");
				var parts2 = Console.ReadLine().Split(' ');

				if (parts2.Length == 3 &&
					int.TryParse(parts2[0], out int d2) &&
					int.TryParse(parts2[1], out int m2) &&
					int.TryParse(parts2[2], out int y2) &&
					Vortex.Verify($"{d2}/{m2}/{y2}"))
				{
					Quantum q2 = new Quantum(d2, m2, y2);

					int divergence = q1.Measure(q2);
					Console.WriteLine($"Temporal divergence: {divergence} days");

					Console.Write("Enter temporal displacement: ");
					if (int.TryParse(Console.ReadLine(), out int shift))
					{
						Quantum q3 = q1.Shift(shift);
						Console.Write("Displaced quantum: ");
						q3.Display();
					}
					else
					{
						Console.WriteLine("Invalid displacement value!");
					}

					bool leap = q1.Check();
					Console.WriteLine($"Leap year resonance: {leap}");
				}
				else
				{
					Console.WriteLine("Invalid second quantum coordinates!");
				}
			}
			else
			{
				Console.WriteLine("Invalid first quantum coordinates!");
			}

			Console.WriteLine("\n🌀 ChronoCrypt Termination Sequence 🌀");
		}
	}
}
