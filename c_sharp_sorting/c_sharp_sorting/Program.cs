using System;
using System.Collections.Generic;
using System.Linq;


namespace c_sharp_sorting {

	class Person {

		public int age { get; set; }
		public string name { get; set; }

	}

	class MainClass {

		static List<Person> people = new List<Person>();
		static List<Person> sorted_people = new List<Person>();

		public void create_people() {

			people.Add(new Person {
				age = 20,
				name = "Hal"
			});

			people.Add(new Person {
				age = 31,
				name = "Susann"
			});

			people.Add(new Person {
				age = 21,
				name = "Kassandra"
			});

			people.Add(new Person {
				age = 25,
				name = "Lawrence"
			});

			people.Add(new Person {
				age = 22,
				name = "Cindy"
			});

			people.Add(new Person {
				age = 27,
				name = "Cory"
			});

			people.Add(new Person {
				age = 19,
				name = "Mac"
			});

			people.Add(new Person {
				age = 27,
				name = "Romana"
			});

			people.Add(new Person {
				age = 32,
				name = "Doretha"
			});

			people.Add(new Person {
				age = 20,
				name = "Danna"
			});

			people.Add(new Person {
				age = 23,
				name = "Zara"
			});

			people.Add(new Person {
				age = 26,
				name = "Rosalyn"
			});

			people.Add(new Person {
				age = 24,
				name = "Risa"
			});

			people.Add(new Person {
				age = 28,
				name = "Benny"
			});

			people.Add(new Person {
				age = 33,
				name = "Juan"
			});

			people.Add(new Person {
				age = 25,
				name = "Natalie"
			});

		}

		public static void Main(string[] args) {

			float[] unsorted = { 645.32f, 37.40f, 76.30f, 5.40f, -34.23f, 1.11f, -34.94f, 23.37f, 635.46f, -876.22f, 467.73f, 62.26f };

			Array.Sort(unsorted);

			Console.WriteLine("Sorted Floats:");

			for (int i = 0; i < unsorted.Length; i++) {

				Console.Write(unsorted[i] + ", ");
			}

			Console.WriteLine("");


			Console.WriteLine("Sorted People By Name");

			sorted_people.AddRange(people.OrderBy(x => x.name));

			foreach (Person p in sorted_people) {
				Console.WriteLine(p.name);
			}

			Console.WriteLine("");

			Console.WriteLine("Sorted People By Age (Then Name)");

			sorted_people.AddRange(people.OrderByDescending(x => x.age).ThenBy(x => x.name));

			foreach (Person p in sorted_people) {
				Console.WriteLine(p.name);
			}

			Console.WriteLine("");

		}
	}
}
