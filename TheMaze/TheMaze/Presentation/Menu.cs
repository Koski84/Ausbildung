using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMaze.Business;

namespace TheMaze
{
	class Menu
	{

		public static void CloseApplication()
		{
			Environment.Exit(0);
		}

		
		public static int ShowMenu(string[] filesArray, int top)
		{
			bool loopComplete = false;
		   
			int selectedItem = 0;
			ConsoleKeyInfo key;

			Array.Resize(ref filesArray, filesArray.Length + 1);
			filesArray[filesArray.Length - 1] = "EXIT";

			int left = ((Console.WindowWidth / 2) - filesArray[0].Length/2);

			Console.CursorVisible = false;


		

			while (!loopComplete)
			{

				for (int i = 0; i < filesArray.Length; i++)
				{
					Console.SetCursorPosition(left, top + i);

					if (i == selectedItem)
					{
						
						Console.BackgroundColor = ConsoleColor.White;
					    Console.ForegroundColor = ConsoleColor.Black;
						Console.WriteLine(filesArray[i]);
						Console.ResetColor();
					}
					else
					{
						Console.WriteLine(filesArray[i]);
					}

					
				}

				key = Console.ReadKey(true); 
				switch (key.Key)
				{ 
					case ConsoleKey.UpArrow:
						if (selectedItem > 0)
						{
							selectedItem--;
						}
						else
						{
							selectedItem = (filesArray.Length - 1);
						}
						break;

					case ConsoleKey.DownArrow:
						if (selectedItem < (filesArray.Length - 1))
						{
							selectedItem++;
						}
						else
						{
							selectedItem = 0;
						}
						break;

					case ConsoleKey.Enter:

						if (selectedItem == filesArray.Length-1)
						{
							CloseApplication();
						}

						if ((selectedItem == 0)&&(filesArray[0].Contains("Start Algorithm")))
						{
							Console.Clear();
							return 0;
						}if((selectedItem == 1) && (filesArray[1].Contains("Main Menu")))
						{
							Console.Clear();
							return 1;
						}
						else {
							Program.ControlFlowOfProgram(filesArray[selectedItem], 2);
							break;
						}

						
				}
			
				Console.SetCursorPosition(left, top);
			}

			Console.CursorVisible = true;
			return selectedItem;
		}

	}
}



