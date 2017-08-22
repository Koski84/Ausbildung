using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TheMaze.Data;
using System.Diagnostics;

namespace TheMaze
{
	class MapPathFinder
	{
		
		public bool[,] correctPath = new bool[12,12];
        



		public bool startPointFound = false;
		public bool nextValidMove(MapFile map, int x, int y)
		{
			

			if ((x == map.width) && (y == map.height)) { 
             
                return false;
            }

			if ((map.Matrix[x, y]) == 1 ) {
                return true;
            }

            
			if (x != 0)
			{
               
				if (nextValidMove(map, x-1,y))
				{
                   
					map.Matrix[x, y] = 9;
					correctPath[x, y] = true;
                    return correctPath[x, y];
				}

				if (x != map.width - 1)
				{

					if (nextValidMove(map,x + 1, y))
					{
						map.Matrix[x, y] = 9;
						correctPath[x, y] = true;
                        return correctPath[x, y];
					}

					if (y != 0)
					{
						if (nextValidMove(map,x, y - 1))
						{
							map.Matrix[x, y] = 9;
							correctPath[x, y] = true;
                            return correctPath[x, y];

						}
					}

					if (y != map.height - 1)
					{
						if (nextValidMove(map,x, y + 1))
						{
							map.Matrix[x, y] = 9;
							correctPath[x, y] = true;
                            
                            return correctPath[x, y];
						}
					} 	
				}

                
			}
            
            return false;
		}

		public bool PathFinder(MapFile map)
		{			
			for (int x = 1; x < map.width; x++)
			{
				for (int y = 1; y < map.height; y++)
				{
                    var status = MapDisplay.DisplayMap(map);
                      if (status)
                    {
                       var solution = nextValidMove(map, x, y);
                    }
				}
							
			}


			return map.end;
		}
	}
}
