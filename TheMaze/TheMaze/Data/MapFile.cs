using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMaze.Data
{
	class MapFile
	{
		
		public byte[,] Matrix = null;

		public int width = 0;
		public int height = 0;
		public bool start = false;
		public bool end = false;

		public int[,] PathFollowed = null;

	}
}
