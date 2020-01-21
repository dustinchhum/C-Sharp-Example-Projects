using System;

namespace BasicCalculator {

	class Calculator {

		public static void Main(string[] args) {

			Console.WriteLine("******_Basic Calculator_******");

			int a = (75 - 33) * 7;

			Console.WriteLine("A. (75 - 33) x 7 = " + a);

			int b = 526 / 23;

			Console.WriteLine("B. 526 / 23 = " + b);

			double c = 526 / 23.0;

			Console.WriteLine("C. 526 /  23.0 = " + c);

			double d = 1.15 % 0.25;

			Console.WriteLine("D. The remainder of  1.15 / 0.25 is " + d);

			int e = 39 / 10;

			Console.WriteLine("E. The whole number (integer) portion of 39 / 10 is " + e);

			int f = -7 / 10;

			Console.WriteLine("F. The remainder of -7 / 10 is " + f);

			double g_double = 15 / 3.33;
			int g = (int)g_double;

			Console.WriteLine("G. The whole number (integer) portion of the quotient 15 / 3.33 is " + g);

			if (56 == 11)
				Console.WriteLine("Congratulations! Thousand of years of Mathematics were just thrown out the window!");
			Console.WriteLine("H. 56 is NEVER equal to 11");

			if (56 != 11)
				Console.WriteLine("I. 56 is indeed NOT equal to 11. Thank gosh for Mathematics.");

			double j = Math.Pow(Math.Sqrt(3.5), 2);
			double j_compare = 3.5;
			if (j == j_compare)
				Console.WriteLine("J. pow(sqrt(3.51) , 2) is equal to 3.5");

			//double k_power = Math.


		}
	}
}
