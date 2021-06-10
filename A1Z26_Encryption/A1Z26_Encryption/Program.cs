using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace A1Z26_Encryption
{
	class Program
	{
		public static Dictionary<string, string> reverseDictionary = new Dictionary<string, string>();
		public static Dictionary<int, string> dictionary = new Dictionary<int, string>();

		public static void Main(string[] args)
		{

			int programType;
			string continueCondition;
			PopulateDictinary();
			while (true)
			{



				Console.WriteLine("\n1 for Decryption\n2 for Encryption ");
				Int32.TryParse(Console.ReadLine(), out programType);

				string output = "";



				//passes dictionary to a function that will poluate it


				switch (programType)
				{
					case 1:
						output += Decypher(dictionary);
						break;
					case 2:
						output += Encrypter(reverseDictionary);
						break;
					default:
						break;
				}

				//calls the decypher method and passes it the dictionary and the input that the user enters
				

				//writes the output to the console
				Console.WriteLine(output);
				//Ask user if they want to continue
				Console.WriteLine("Do You want to Continue? Y/n");
				continueCondition = Console.ReadLine().ToUpper();
				if (continueCondition != "Y")
				{
					break;
				}
				Console.Clear();

			}
		}

		private static string Decypher(Dictionary<int, string> dictionary)
		{
			string input;
			string code = "";
			int temp;
			bool isValid;
			bool DicCheck;
			

			Console.WriteLine("A1Z26 Decryption");
			Console.WriteLine("Enter the Number code in X.X.X format");
			input = Console.ReadLine();

			string[] strings = input.Split('.');

			foreach (string z in strings)
			{
				isValid = Int32.TryParse(z, out temp);
				DicCheck = dictionary.ContainsKey(temp);

				if(isValid & DicCheck)
				code += dictionary[temp];
				else
				{
					code = "Invalid Input Format";
					return code;
				}

			}
			return code;
		}
		//Populates The dictionary 
		private static void PopulateDictinary()
		{
			for (char c = 'A'; c <= 'Z'; c++)
			{
				int key = c - 'A' + 1;
				dictionary.Add(key, c.ToString());
			}
			dictionary.Add(27, " ");
			ReverseDictionary();
		}
		//Makes a reverse of the first dictionary for the Encoding function
		private static void ReverseDictionary()
		{
			for (char c = 'A'; c <= 'Z'; c++)
			{
				int key = c - 'A' + 1;
				reverseDictionary.Add(c.ToString(), key.ToString());
			}
			reverseDictionary.Add(" ", "27");
		}

		private static string Encrypter(Dictionary<string, string> dictionary)
		{
			string input;
			string code = "";
			bool isValid;
			bool DicCheck;





			Console.WriteLine("A1Z26 Encryption");
			Console.WriteLine("Enter Letters and Spaces only");

			input = Console.ReadLine();
			string theString = input.ToUpper();

			int counter = 0;

			foreach (char z in theString)
			{
				
				isValid = IsValidLetter(z);
				DicCheck = dictionary.ContainsKey(z.ToString());

				if (isValid & DicCheck)
				{
					code += dictionary[z.ToString()];
					
					if(counter < theString.Length-1)
						code += ".";
				}

				else
				{
					code = "Invalid Input Format";
					return code;
				}
				counter++;

			}
			return code;
		}
		private static bool IsValidLetter(char letter)
		{
			return (letter >= 'a' && letter <= 'z') ||
				   (letter >= 'A' && letter <= 'Z') || (letter == ' ');
		}

	}
}
