using System;
using System.Threading;

namespace Laboratory_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Задание 1");
                // Создание объекта класса Post
                Post p1 = new Post();
                Post p2 = new Post(500, 52, 127);

                Console.WriteLine("\nПервый пост:");
                Data.PrintPost(p1);
                Console.WriteLine("\nВторой пост:");
                Data.PrintPost(p2);

                // Вывод количества созданных объектов
                Console.WriteLine($"\nКоличество созданных объектов в Post: {Post.PostCount}");

                // Вычисление и вывод коэффициента вовлеченности с помощью статической функции
                Console.WriteLine("\nСтатическая функция:");
                Post.CalculateEngagementRate(p1, 1000);
                Console.Write("Коэффициент вовлеченности первого поста (проценты):");
                Data.PrintEngagementInfo(p1);

                Post.CalculateEngagementRate(p2, 1000);
                Console.Write("Коэффициент вовлеченности второго поста (проценты):");
                Data.PrintEngagementInfo(p2);

                // Вычисление и вывод коэффициента вовлеченности с помощью метода объекта
                Console.WriteLine("\nМетод объекта:");
                p1.CalculateEngagementRate(1000);
                Console.Write("Коэффициент вовлеченности первого поста (проценты):");
                Data.PrintEngagementInfo(p1);

                p2.CalculateEngagementRate(1000);
                Console.Write("Коэффициент вовлеченности второго поста (проценты):");
                Data.PrintEngagementInfo(p2);

                Console.WriteLine("\nЗадание 2");
                Post p3 = new Post(500, 50, 150);
                Post p4 = new Post(500, 50, 150);
                Post p5 = new Post(501, 50, 150);

                Console.WriteLine("\nТретий пост:");
                Data.PrintPost(p3);
                Console.WriteLine("Четвертый пост:");
                Data.PrintPost(p4);
                Console.WriteLine("Пятый пост:");
                Data.PrintPost(p5);

                // Унарные операции
                p3 = !p3; // Увеличение количества реакций
                ++p4; // Увеличение количества просмотров
                Console.WriteLine("\nПосле унарных операций:");
                Console.WriteLine("\nТретий пост:");
                Data.PrintPost(p3);
                Console.WriteLine("Четвертый пост:");
                Data.PrintPost(p4);

                // Операции приведения типа
                Console.WriteLine($"\nУ поста 3 есть вовлеченность: {(bool)p3}");

                Console.WriteLine($"\nОхват поста 4: {(double)p4}%");

                // Бинарные операции
                Console.WriteLine("\nСравнение постов:");
                Console.WriteLine($"p4 == p5: {p4 == p5}"); // Должно быть true
                Console.WriteLine($"p3 != p4: {p3 != p4}"); // Должно быть true

                Console.WriteLine("\nЗадание 3");

                Console.WriteLine("Создание массива без параметров:");
                PostArray arr0 = new PostArray();
                Data.PrintPostArray(arr0);

                Console.WriteLine("\nСоздание массива ручным вводом:");
                PostArray arr3 = Data.CreatePostArrayFromInput();
                Data.PrintPostArray(arr3);

                Console.WriteLine("\nСоздание массива со случайной генерацией:");
                PostArray arr1 = new PostArray(3);
                Data.PrintPostArray(arr1);

                Console.WriteLine("\nГлубокое клонирование:");
                PostArray arr2 = new PostArray(arr1);
                Data.PrintPostArray(arr2);

                arr1[0].NumViews = 1000;
                Console.WriteLine("\nИзмененный массив 1");
                Data.PrintPostArray(arr1);

                Console.WriteLine("\nИзмененный массив 2");
                Data.PrintPostArray(arr2);

                Console.WriteLine("\nДемонстрация работы индексатора:");
                Console.WriteLine("Запись и получение с существующим индексом (0):");
                arr1[0] = new Post(100, 10, 5);
                Data.PrintPostArray(arr1);
                Console.WriteLine($"\nПросмотры 1 элемента: {arr1[0].NumViews}");

                //Console.WriteLine("\nЗапись и попытка получения с несуществующим индексом:");
                //arr1[arr1.Length] = new Post(1, 2, 3);
                //arr1.Show();

                Console.WriteLine($"\nОбщий коэффициент вовлеченности: {CalculateTotalEngagementRate(arr1)}%");

                Console.WriteLine($"\nКоличество созданных объектов в PostArray: {PostArray.PostCount}");
                Console.WriteLine($"\nКоличество созданных колекций в PostArray: {PostArray.CollectionCount}");
            }

            catch (Exception ex)
            {
                Data.DisplayException(ex);
            }

            finally
            {
                Console.WriteLine("\nКонец работы");
            }
        }
        // Функция, считающая общий коэффициент вовлечённости по постам одного сообщества
        private static double CalculateTotalEngagementRate(PostArray arr)
        {
            double totalEngagement = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                totalEngagement += arr[i].CalculateEngagementRate(1000);
            }
            if (totalEngagement > 100)
                return 100;

            else
                return Math.Round(totalEngagement, 2);
        }
    }
}    


