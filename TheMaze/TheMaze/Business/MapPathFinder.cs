using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMaze.Data;

namespace TheMaze
{
	class MapPathFinder
	{
		public bool[,] previousPoint = new bool[12,12];
		public bool[,] correctPath = new bool[12,12];

		public bool startPointFound = false;
		public bool nextValidMove(MapFile map, int x, int y)
		{
			

			if ((x == map.width) && (y == map.height)) { return true; }
			if ((map.Matrix[x, y]) == 2 || previousPoint[x, y]) { return false; }

			previousPoint[x, y] = true;

			if (x != 0)
			{
				if (nextValidMove(map, x-1,y))
				{
					map.Matrix[x, y] = 9;
					correctPath[x, y] = true;
					return true;
				}

				if (x != map.width - 1)
				{

					if (nextValidMove(map,x + 1, y))
					{
						map.Matrix[x, y] = 9;
						correctPath[x, y] = true;
						return true;
					}

					if (y != 0)
					{
						if (nextValidMove(map,x, y - 1))
						{
							map.Matrix[x, y] = 9;
							correctPath[x, y] = true;
							return true;

						}
					}

					if (y != map.height - 1)
					{
						if (nextValidMove(map,x, y + 1))
						{
							map.Matrix[x, y] = 9;
							correctPath[x, y] = true;
							return true;
						}
					}

					if (map.Matrix[x, y] == 5)
					{
						map.Matrix[x, y] = 9;
						return map.end = true;
					}

					return false;
				}
			}

		

			return false;
		}
		public bool PathFinder(MapFile map)
		{			
		

			for (int y = 0; y < map.height; y++)
			{
				for (int x = 0; x < map.width; x++)
				{
					nextValidMove(map, x, y);
					
				}
							
			}


			return map.end;
		}
	}
}
