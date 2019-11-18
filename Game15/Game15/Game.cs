using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game15
{
    class Game
    {
        int _size;
        int[,] massiv;
        int space_x, space_y;
        public int[] numbInMasss = new int[16];
        public int[] rightNumb = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0 };

        static Random rand = new Random();
        

        public Game(int size)
        {
            if (size < 2)
                size = 2;
            if (size > 5)
                size = 5;
            _size = size;
            massiv = new int[size, size];
        }

        public void start()
        {
            int z = 0;

            for (int x = 0; x < _size; x++)
            {
                for (int y = 0; y < _size; y++)
                {
                    massiv[x, y] = coordsToPosition(x, y) + 1;
                    rightNumb[z] = massiv[x, y];
                    z++;
                }
            }

            space_x = _size - 1;
            space_y = _size - 1;
            massiv[space_x, space_y] = 0;
            rightNumb[15] = 0;
        }

        public int get_number(int pos)
        {
            int x, y;
            position_to_coords(pos, out x, out y);
            if (x < 0 || x >= _size)
                return 0;
            if (y < 0 || y >= _size)
                return 0;
            return massiv[x, y];
        }

        public void insertTail(int index)
        {
            int x, y;
            position_to_coords(index, out x, out y);
            massiv[x, y] = 0;
        }

        public void mixTails()
        {
            for (int i = 0; i < 1000000; i++)            
                swapTails(rand.Next(0, 16));            
        }

        public void swapTails(int index)
        {
            int x, y, xNew, yNew, tempCurrent;

            position_to_coords(index, out x, out y);

            tempCurrent = massiv[x, y];               
            xNew = space_x;
            yNew = space_y;
        

            if (space_x == x & (space_y + 1 == y || space_y - 1 == y))
            {
                space_x = x;
                space_y = y;
                massiv[space_x, space_y] = 0;
                massiv[xNew, yNew] = tempCurrent;
            }       
            else if (space_y == y & (space_x + 1 == x || space_x - 1 == x))
            {
                space_x = x;
                space_y = y;
                massiv[space_x, space_y] = 0;
                massiv[xNew, yNew] = tempCurrent;
            }

        }

        public bool checkToEndGame()
        {
            int z = 0;

            for (int x = 0; x < _size; x++)
            {
                for (int y = 0; y < _size; y++)
                {
                    numbInMasss[z] = massiv[x, y];
                    z++;
                }
            }            

            return rightNumb.SequenceEqual(numbInMasss);       
        }



        private int coordsToPosition(int x, int y)
        {
            return y * _size + x;
        }

        private void position_to_coords(int pos, out int x, out int y)
        {
            x = pos % _size;
            y = pos / _size;
        }
    }
}
