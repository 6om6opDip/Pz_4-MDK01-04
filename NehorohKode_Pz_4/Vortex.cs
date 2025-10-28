using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NehorohKode_Pz_4
{
	internal class Vortex
	{
		private static Dictionary<int, string> _celestial = new Dictionary<int, string>
		{
			{0, "S"}, {1, "M"}, {2, "Tu"}, {3, "W"},
			{4, "Th"}, {5, "F"}, {6, "S"}
		};

		public static string Transmute(string chrono)
		{
			string[] fragments = chrono.Split('/');
			return fragments.Length == 3 ? $"{fragments[1]}/{fragments[0]}/{fragments[2]}" : chrono;
		}

		public static bool Verify(string temporal)
		{
			if (string.IsNullOrWhiteSpace(temporal)) return false;

			string[] parts = temporal.Split('/');
			if (parts.Length != 3) return false;

			if (!int.TryParse(parts[0], out int d) ||
				!int.TryParse(parts[1], out int m) ||
				!int.TryParse(parts[2], out int y)) return false;

			if (y < 1 || y > 9999) return false;
			if (m < 1 || m > 12) return false;

			int[] daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
			int maxDays = daysInMonth[m - 1];

			if (m == 2 && ((y % 4 == 0 && y % 100 != 0) || (y % 400 == 0)))
				maxDays = 29;

			return d >= 1 && d <= maxDays;
		}

		public static string Reveal(string temporal)
		{
			if (!Verify(temporal)) return "Temporal Anomaly";

			string[] parts = temporal.Split('/');
			var phantom = new DateTime(int.Parse(parts[2]), int.Parse(parts[1]), int.Parse(parts[0]));
			return _celestial[(int)phantom.DayOfWeek];
		}
	}
}

