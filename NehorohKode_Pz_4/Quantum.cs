using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NehorohKode_Pz_4
{
	internal class Quantum
	{
		private DateTime _nexus;

		public Quantum(int d, int m, int y)
		{
			_nexus = new DateTime(y, m, d);
		}

		public int Measure(Quantum other)
		{
			TimeSpan distortion = _nexus - other._nexus;
			return Math.Abs((int)distortion.TotalDays);
		}

		public Quantum Shift(int temporal)
		{
			DateTime shifted = _nexus.AddDays(temporal);
			return new Quantum(shifted.Day, shifted.Month, shifted.Year);
		}

		public bool Check()
		{
			return DateTime.IsLeapYear(_nexus.Year);
		}

		public void Display()
		{
			Console.WriteLine($"{_nexus:dd/MM/yyyy}");
		}
	}
}

