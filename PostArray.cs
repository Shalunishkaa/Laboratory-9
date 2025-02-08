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

        private static int collectionCount;
        private static int postCount;

        public int Length => arr.Length;
        public static int PostCount => postCount;
        public static int CollectionCount => collectionCount;

        // Конструктор без параметров
        public PostArray()
        {
            arr = new Post[0];
            postCount++;
        }

        // Конструктор с параметрами, заполняющий элементы случайными значениями
        public PostArray(int length)
        {
            arr = new Post[length];

            for (int i = 0; i < length; i++)
            {
                arr[i] = new Post(rnd.Next(1000), rnd.Next(50), rnd.Next(100));
                postCount++;
            }
            collectionCount++;
        }

        // Конструктор глубокого клонирования
        public PostArray(PostArray other)
        {
            arr = new Post[other.Length];
            for (int i = 0; i < other.Length; i++)
            {
                arr[i] = new Post(other[i].NumViews, other[i].NumComments, other[i].NumReactions);
                postCount++;
            }
            collectionCount++;
        }

        // Метод для просмотра элементов массива
        public void Show()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Post {i+1}: ");
                arr[i].Show();
            }
        }

        // Индексатор для доступа к элементам коллекции
        public Post this[int index]
        {
            get
            {
                if (index >= 0 && index < arr.Length)
                    return arr[index];
                else throw new Exception("Выход за границы массива");
            }
            set
            {
                if (index >= 0 && index < arr.Length)
                    arr[index] = value;
                else throw new Exception("Выход за границы массива");
            }
        }
    }
}
