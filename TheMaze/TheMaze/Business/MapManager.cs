using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMaze.Data;

namespace TheMaze.Business
{
	class MapManager
	{
		

		public static string[] GetFileNames()
		{

            string[] fileArray = Directory.GetFileSystemEntries(@"C:\Users\EMoreira\Documents\GitHub\Ausbildung\TheMaze\TheMaze\Data\", "*.txt");

			for (int i = 0; i < fileArray.Length; i++)
			{
				char[] charsToTrim = { '.', 't', 'x' };

				string[] Files = { };

				fileArray[i] = fileArray[i].Substring(fileArray[i].Length - 9).TrimEnd(charsToTrim);
			}

			return fileArray;
		}

		public static MapFile ReadFile(string FileName)
		{
			MapFile map = null;

			if (FileName.Contains("MAP"))
			{
                string[] lines = File.ReadAllLines(@"C:\Users\EMoreira\Documents\GitHub\Ausbildung\TheMaze\TheMaze\Data\" + FileName + ".txt");

				map = new MapFile();

				map.width = lines[0].Replace(" ", "").Length;
				map.height = lines.Length;

				map.Matrix = new byte[map.width, map.height];

			

				for (int y = 0; y < map.height; y++)
				{
					string line = lines[y].Replace(" ", "");
					
					
					for (int x = 0; x < map.width;x++)

					{
						map.Matrix[x,y] = Convert.ToByte(line[x]);

						if (line[x] == '#')
						{
							map.Matrix[x, y] = 1;
						}

						if (line[x] == '.')
						{
							map.Matrix[x, y] = 2;
						}

						if (line[x] == 'S')
						{
							map.Matrix[x, y] = 3;
						}

						if (line[x] == 'F')
						{
							map.Matrix[x, y] = 5;
						}
					}
				}
			}
			else
			{

			}

			return map;
		}

	}
}
