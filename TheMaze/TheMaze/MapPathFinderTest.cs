/*************


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
        public int[,] previousPoint = new int[12,12];
        public bool[,] wasIHere = new bool[12,12];
        public bool startPointFound = false;
        public bool nextValidMove(MapFile map, int y, int x)
        {
            if ((y == map.width) || (x == map.height))
           {

               return false ; //Checks if at the edge and terminates the method
           }

        if(y<0 || x<0) return false;

            if ((map.Matrix[y, x]) == 1)
            {
                return false; // check if at a wall and terminate the method
            }

            //if (map.Matrix[y, x] == 5) return ;


            if (y - 1 >= 0 && map.Matrix[y - 1, x] == 2 && wasIHere[y-1, x] != true )
                {
                    map.Matrix[y, x] = 9;
                   previousPoint[y, x] = map.Matrix[y, x];
                   wasIHere[y, x] = true;
                    
                   
                }
                //  Test the East wall...
            if (x + 1 <= map.width - 1 && map.Matrix[y, x + 1] == 2 && wasIHere[y, x + 1] != true )
                {
                    map.Matrix[y, x] = 9;
                    previousPoint[y, x] = map.Matrix[y, x];
                    wasIHere[y, x] = true;
                   
                }
                //  Test the South wall...
            if (y + 1 <= map.height - 1 && map.Matrix[y + 1, x] == 2 && wasIHere[y + 1, x] != true )
                {
                    map.Matrix[y, x] = 9;
                    previousPoint[y, x] = map.Matrix[y, x];
                    wasIHere[y, x] = true;
                    
                }
                //  Test the West wall...
            if (x - 1 >= 0 && map.Matrix[y, x - 1] == 2 && wasIHere[y, x - 1] != true)
                {
                    map.Matrix[y, x] = 9;
                    previousPoint[y, x] = map.Matrix[y, x];
                    wasIHere[y, x] = true;
                   
                }

            
            if (map.Matrix[y, x - 1] == 2)
            {

            }

            if (map.Matrix[y, x + 1] == 2)
            {

            }

            if (map.Matrix[y - 1, x] == 2)
            {

            }

            if (map.Matrix[y + 1, x] == 2)
            {

            }

         
                
            return false ;
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
                        nextValidMove(map, y, x);
                    }
                }
            }
            return true;
        }
	}
}




***************/