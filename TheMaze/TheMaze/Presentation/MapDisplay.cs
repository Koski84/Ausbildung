using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMaze.Data;
using System.Threading;

namespace TheMaze
{
	class MapDisplay: Menu
	{
		
		public static bool DisplayMap(MapFile map)
		{

		

			for (int y = 0; y < map.height; y++)
			{

				
				Console.WriteLine();
				Console.SetCursorPosition(((Console.WindowWidth / 2) - (map.width / 2)), y + 2);
				Console.Write("");
                Thread.Sleep(50);

				for (int x = 0; x<map.width; x++)
				{
                    

					if (map.Matrix[x, y] == 3)
					{

						Console.BackgroundColor = ConsoleColor.Black;
						Console.ForegroundColor = ConsoleColor.White;
						Console.Write('░');
						Console.ResetColor();


					}
					else if (map.Matrix[x, y] == 2)
					{
						Console.BackgroundColor = ConsoleColor.Blue;
						Console.ForegroundColor = ConsoleColor.Blue;
						Console.Write("2");
						Console.ResetColor();
					}
					else if (map.Matrix[x, y] == 5)
					{
						Console.BackgroundColor = ConsoleColor.Black;
						Console.ForegroundColor = ConsoleColor.White;
						Console.Write("▓");
						Console.ResetColor();
					}
					else if (map.Matrix[x, y] == 1)
					{
						Console.BackgroundColor = ConsoleColor.DarkRed;
						Console.ForegroundColor = ConsoleColor.DarkRed;
						Console.Write("1");
						Console.ResetColor();
					}

					else if (map.Matrix[x, y]==9)
					{
                        
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("9");
                        Console.ResetColor();
					}

					else if (map.Matrix[x, y] == 10)
					{
						Console.BackgroundColor = ConsoleColor.Red;
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.Write(".");
						Console.ResetColor();
					}

					else if (map.Matrix[x, y] == 11)
					{
						Console.BackgroundColor = ConsoleColor.Black;
						Console.ForegroundColor = ConsoleColor.Black;
						Console.Write(":");
						Console.ResetColor();
					}
				}
				
			}
			Console.WriteLine();
			//Thread.Sleep(400);
			return true;
			

		}

	

	}
}
