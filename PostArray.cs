using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_9
{
    internal class PostArray
    {
        static Random rnd = new Random();

        Post[] arr;

        private int Length => arr.Length;
        private static int collectionCount;

        public PostArray()
        {
            arr = new Post[0]; // Инициализируем пустой массив
            collectionCount++;
        }

        public PostArray(int Length)
        {
            arr = new Post[Length];

            for (int i = 0; i < Length; i++)
            {
                arr[i] = new Post(rnd.Next(1000), rnd.Next(50), rnd.Next(20));
            }
            collectionCount++;
        }

        public void Show()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Post {i+1}: ");
                arr[i].Show();
            }
        }   
    }
}
