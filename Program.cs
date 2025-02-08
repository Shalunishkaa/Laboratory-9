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
                Post p2 = new Post(1000, 52, 127);

                Console.WriteLine("\nИнформация о первом посте:");
                p1.Show();
                Console.WriteLine("\nИнформация о втором посте:");
                p2.Show();

                // Вывод количества созданных объектов
                Console.WriteLine($"\nКоличество созданных объектов Post: {Post.PostCount}");

                // Вычисление и вывод коэффициента вовлеченности с помощью статической функции
                Console.WriteLine("\nСтатическая функция:");
                Post.CalculateEngagementRate(p1, 1000);
                Console.Write("Коэффициент вовлеченности первого поста (проценты):");
                p1.PrintEngagementInfo();

                Post.CalculateEngagementRate(p2, 1000);
                Console.Write("Коэффициент вовлеченности второго поста (проценты):");
                p2.PrintEngagementInfo();

                // Вычисление и вывод коэффициента вовлеченности с помощью метода объекта
                Console.WriteLine("\nМетод объекта:");
                p1.CalculateEngagementRate(1000);
                Console.Write("Коэффициент вовлеченности первого поста (проценты):");
                p1.PrintEngagementInfo();

                p2.CalculateEngagementRate(1000);
                Console.Write("Коэффициент вовлеченности второго поста (проценты):");
                p2.PrintEngagementInfo();

                Console.WriteLine("\nЗадание 2");
                Post p3 = new Post(500, 50, 150);
                Post p4 = new Post(500, 50, 150);
                Post p5 = new Post(501, 50, 150);

                // Унарные операции
                p3 = !p3; // Увеличение количества реакций
                ++p4; // Увеличение количества просмотров
                Console.WriteLine("\nПосле унарных операций:");
                p3.Show();
                p4.Show();

                // Операции приведения типа
                Console.WriteLine($"\nУ поста 3 есть вовлеченность: {(bool)p3}");

                Console.WriteLine($"\nОхват поста 4: {(double)p4}%");

                // Бинарные операции
                Console.WriteLine("\nСравнение постов:");
                Console.WriteLine($"p4 == p5: {p4 == p5}"); // Должно быть true
                Console.WriteLine($"p3 != p4: {p3 != p4}"); // Должно быть true

                Console.WriteLine("\nЗадание 3");
                PostArray arr1 = new PostArray(5);
                arr1.Show();

                PostArray arr2 = new PostArray(arr1);
                arr2.Show();

                arr1[0].NumViews = 1000;
                Console.WriteLine("\nИзмененный массив 1");
                arr1.Show();

                Console.WriteLine("\nИзмененный массив 2");
                arr2.Show();

                Console.WriteLine("\nДемонстрация работы индексатора:");
                if (arr1.Length > 0)
                {
                    Console.WriteLine("Запись и получение с существующим индексом (0):");
                    arr1[0] = new Post(100, 10, 5);
                    arr1.Show();
                    Console.WriteLine($"\nПросмотры 1 элемента: {arr1[0].NumViews}");

                    //Console.WriteLine("\nЗапись и попытка получения с несуществующим индексом:");
                    //arr1[arr1.Length] = new Post(1, 2, 3);
                    //Console.WriteLine("Элемент успешно записан (этого не должно произойти!)");       
                }

                else
                {
                    Console.WriteLine("Массив пуст.");
                }

                Console.WriteLine($"\nОбщий коэффициент вовлеченности: {CalculateTotalEngagementRate(arr1)}%");

                Console.WriteLine($"\nКоличество объектов Post: {PostArray.PostCount}");
                Console.WriteLine($"\nКоличество объектов PostArray: {PostArray.CollectionCount}");
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
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
                return Math.Round(totalEngagement, 2);
            }
        }
    }


