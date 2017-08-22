using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMaze.Business;


namespace TheMaze
{
	class Program
	{

		public static void WriteAtTheMiddleOfTheScreen(string message)
		{
			message = String.Format("{0," + ((Console.WindowWidth / 2) + (message.Length / 2)) + "}", message);
			Console.WriteLine(message);
		}
		public static void ControlFlowOfProgram(string Array, int component)
		{
			var ArrayOfFileNames = MapManager.GetFileNames();


			switch (component)
			{

				case 1:
					if (ArrayOfFileNames != null)
					{

						WriteAtTheMiddleOfTheScreen("Welcome To The Maze\n");
						Menu.ShowMenu(ArrayOfFileNames, 3);
						//Console.ReadKey();
					}
					else
					{
						WriteAtTheMiddleOfTheScreen("You Have no Maps On the Data Directory");
					}

					break;

				case 2:

					MapPathFinder pathFinder = new MapPathFinder();
					

					if (Array.Contains("MAP"))
					{
						var map = MapManager.ReadFile(Array);
						bool statusOfMap = MapDisplay.DisplayMap(map);

						if (statusOfMap)
						{
							string[] MenuToMapPathFinder = { "Start Algorithm", "Main Menu" };
							var selectedItem = Menu.ShowMenu(MenuToMapPathFinder, Console.WindowHeight / 2);

							if (selectedItem == 0)
							{
								
								var FoundEndOfPath = pathFinder.PathFinder(map);

								while (!FoundEndOfPath) {

									var RedrawMap = MapDisplay.DisplayMap(map);
                                 
									FoundEndOfPath = pathFinder.PathFinder(map);
						
								}

                								
							}

							else if(selectedItem == 1)
							{
								Console.Clear();
								ControlFlowOfProgram("", 1);
							}

							break;
						}
					}break;

			}

		}

		static void Main(string[] args)
		{
			ControlFlowOfProgram("", 1);
		}
	}
}
