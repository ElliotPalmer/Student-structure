/*Задание 1. На основе данных входного файла составить список студентов группы,
включив следующие данные: ФИО, год рождения, домашний адрес, какую школу окончил.
Вывести в новый файл информацию о студентах, окончивших заданную школу,
отсортировав их по году рождения.*/

using System;
using System.IO;

namespace struct_solution_11_1 {

	struct SSTudent {

		public string surname;
		public string name;
		public string fathername;
		public int year;
		public string address;
		public int schoolnum;

		public SSTudent(string surname, string name, string fathername, int year, string address, int schoolnum) {
			this.surname = surname;
			this.name = name;
			this.fathername = fathername;
			this.year = year;
			this.address = address;
			this.schoolnum = schoolnum;
		}

		public void Show() {
			Console.WriteLine("Фамилия {0}\n Имя {1}\n Отчество {2}\n Год рождения {3}\n Адрес {4}\n Номер школы {5}\n\n", 
			                  surname, name, fathername, year, address, schoolnum);
		}
	}


	class MainClass {

		static void Sort(SSTudent[] array, int count) {
			SSTudent temp;
			for (int i = 0; i < array.Length - 1; i++) {
				bool isSorted = true;
				for (int j = count - 1; j > i; j--) {
					if (array[j].year < array[j - 1].year) {
						isSorted = false;
						temp = array[j];
						array[j] = array[j - 1];
						array[j - 1] = temp;
					}
				}
				if (isSorted)
					return;
			}
		}
		static public SSTudent[] Input(int schoolNum, out int count) {
			using (StreamReader input = new StreamReader("/Users/neiru/Projects/struct_solution_11_1/struct_solution_11_1/input.txt")) {
				int n = int.Parse(input.ReadLine());
				SSTudent[] array = new SSTudent[n];
				count = 0;
				for (int i = 0; i < n; i++) {
					string[] split = input.ReadLine().Split(' ');
					string surname = split[0];
					string name = split[1];
					string fathername = split[2];
					int year = int.Parse(split[3]);
					string address = split[4];
					int schoolnum = int.Parse(split[5]);
					if (schoolnum == schoolNum) {
						array[count] = new SSTudent(surname, name, fathername, year, address, schoolnum);
						count++;
					}
				}
				return array;
			}
		}

		static public void Out(SSTudent[] array, int schoolNum, int count) {
			using (StreamWriter output = new StreamWriter("/Users/neiru/Projects/struct_solution_11_1/struct_solution_11_1/output.txt")) {
				for (int i = 0; i < count; i++) {
					output.WriteLine("{0} {1} {2} {3} {4} {5}", array[i].surname, array[i].name, array[i].fathername,
									 array[i].year, array[i].address, array[i].schoolnum);
				}
			}
		}

		static void Print(SSTudent[] array, int count) {
			for (int i = 0; i < count; i++) {
				array[i].Show();
			}
		}

		public static void Main(string[] args) {
			int count = 0;
			Console.WriteLine("Введите номер школы");
			int schoolNum = int.Parse(Console.ReadLine());
			SSTudent[] database = Input(schoolNum, out count);
			//Print(database, count);
			Sort(database, count);
			Out(database, schoolNum, count);
		}
	}
}
