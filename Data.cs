using System;

namespace Laboratory_9
{
    public class Data
    {
        public static int GetIntFromConsole(string number)
        {
            Console.Write(number);
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int result))
                    return result;

                Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число.");
                Console.Write(number);
            }
        }

        public static Post GetPostFromInput(int index)
        {
            Console.WriteLine($"Ввод данных для поста {index + 1}:");
            int views = GetIntFromConsole("Введите количество просмотров: ");
            int comments = GetIntFromConsole("Введите количество комментариев: ");
            int reactions = GetIntFromConsole("Введите количество реакций: ");
            return new Post(views, comments, reactions);
        }

        public static void DisplayException(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Ошибка: {ex.Message}");
            Console.ResetColor();
        }

        public static void PrintPost(Post post)
        {
            Console.WriteLine($"Просмотры: {post.NumViews}, Комментарии: {post.NumComments}, Реакции: {post.NumReactions}");
        }

        public static void PrintPostArray(PostArray arr)
        {
            if (arr == null || arr.Length == 0)
            {
                Console.WriteLine("Массив пуст.");
                return;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Post {i + 1}:");  // Индекс начинается с 1 для пользователя
                PrintPost(arr[i]);
            }
        }

        // Метод для вывода информации об вовлеченности объекта
        public static void PrintEngagementInfo(Post post)
        {
            Console.WriteLine($" {post.EngagementRate}");
        }

        public static int GetArraySizeFromConsole()
        {
            int value = GetIntFromConsole("Введите размер массива: ");
            if (value <= 0)
                throw new Exception("Недопустимая длина.");
            return value;
        }

        public static PostArray CreatePostArrayFromInput()
        {
            int size = GetArraySizeFromConsole();
            PostArray array = new PostArray(size);

            for (int i = 0; i < array.Length; i++)
            {
                try
                {
                    array[i] = GetPostFromInput(i);
                }
                catch (Exception ex)
                {
                    DisplayException(ex);
                    i--; // Повторяем итерацию, чтобы пользователь мог повторно ввести данные
                }
            }

            return array;
        }
    }
}