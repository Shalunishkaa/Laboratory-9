using System;

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
                p1.PrintPostInfo();
                Console.WriteLine("\nИнформация о втором посте:");
                p2.PrintPostInfo();

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
                p3.PrintPostInfo();
                p4.PrintPostInfo();

                // Операции приведения типа
                bool hasEngagement = (bool)p3;
                Console.WriteLine($"\nУ поста 3 есть вовлеченность: {hasEngagement}");

                double reach = (double)p4;
                Console.WriteLine($"\nОхват поста 4: {reach}%");

                // Бинарные операции
                Console.WriteLine("\nСравнение постов:");
                Console.WriteLine($"p4 == p5: {p4 == p5}"); // Должно быть true
                Console.WriteLine($"p3 != p4: {p3 != p4}"); // Должно быть true
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
    }
}

