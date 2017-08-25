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
        public bool [,]previousPoint = new bool[12,12];
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

            if(y<0 || x<0) return false ;

                if (nextValidMove(map, y - 1, x)&&!previousPoint[y-1,x])
                {
                    map.Matrix[y, x] = 9; //changes the color of the position
                    correctPath[y, x] = true;
                    previousPoint[y, x] = true;

                    return correctPath[y, x];
                }

               
                    if (nextValidMove(map, y + 1, x) && !previousPoint[y + 1, x])
                    {
                        map.Matrix[y, x] = 9;
                        correctPath[y, x] = true;
                        previousPoint[y, x] = true;
                        return correctPath[y, x];
                    }
                

               
                    if (nextValidMove(map, y, x - 1) && !previousPoint[y, x-1])
                    {
                        map.Matrix[y, x] = 9;
                        correctPath[y, x] = true;
                        previousPoint[y, x] = true;
                        return correctPath[y, x];
                    }
                

              
                    if (nextValidMove(map, y, x + 1) && !previousPoint[y, x+1])
                    {
                        map.Matrix[y, x] = 9;
                        correctPath[y, x] = true;
                        previousPoint[y, x] = true;

                        return correctPath[y, x];
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
