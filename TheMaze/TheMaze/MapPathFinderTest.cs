/*************



 * 
 * 
 * 
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
        public bool[,] correctPath = new bool[12, 12];
        public int[,] previousPoint = new int[12, 12];
        public bool startPointFound = false;
        public bool nextValidMove(MapFile map, int y, int x)
        {
            if ((y == map.width) || (x == map.height))
            {

                return false; //Checks if at the edge and terminates the method
            }

            if ((map.Matrix[y, x]) == 1)
            {
                return true; // check if at a wall and terminate the method
            }

            if (map.Matrix[x, y] == 5) return map.end;


            if (y - 1 >= 0 && map.Matrix[x, y - 1] == 2)
            {
                map.Matrix[y, x] = 9;
                previousPoint[y, x] = map.Matrix[y, x];
                return false;

            }
            //  Test the East wall...
            if (x + 1 <= map.width - 1 && map.Matrix[x + 1, y] == 2)
            {
                map.Matrix[y, x] = 9;
                previousPoint[y, x] = map.Matrix[y, x];
                return false;
            }
            //  Test the South wall...
            if (y + 1 <= map.height - 1 && map.Matrix[x, y + 1] == 2)
            {
                map.Matrix[y, x] = 9;
                previousPoint[y, x] = map.Matrix[y, x];
                return false;
            }
            //  Test the West wall...
            if (x - 1 >= 0 && map.Matrix[x - 1, y] == 2)
            {
                map.Matrix[y, x] = 9;
                previousPoint[y, x] = map.Matrix[y, x];
                return false;
            }

            return false;
        }

        public bool PathFinder(MapFile map)
        {
            for (int y = 0; y < map.width; y++)
            {
                for (int x = 0; x < map.height; x++)
                {
                    var status = MapDisplay.DisplayMap(map);
                    if (status)
                    {
                        nextValidMove(map, x, y);
                    }
                }
            }
            return true;
        }
    }
}



***************/