using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_9
{
    public class Post
    {
        private int numViews;
        private int numComments;
        private int numReactions;
        private double engagementRate;
        private static int postCount;
        public static int PostCount => postCount;

        public int NumViews
        {
            get => numViews;
            set 
            {
                if (value < 0)
                    throw new Exception("Просмотры не могут быть отрицательными");
                else
                    numViews = value; 
            }
        }

        public int NumComments
        {
            get => numComments;
            set
            {
                if (value < 0)
                    throw new Exception("Комментраии не могут быть отрицательными");
                else
                    numComments = value;
            }
        }
        public int NumReactions
        {
            get => numReactions;
            set
            {
                if (value < 0)
                    throw new Exception("Реакции не могут быть отрицательными");
                else
                    numReactions = value;
            }
        }

        public double EngagementRate
        {
            get => engagementRate;
            set
            {
                if (value > 100)
                    EngagementRate = 100;

                else
                    engagementRate = value;
            }
        }

        // Конструктор без параметров
        public Post()
        {
            numViews = 0;
            numComments = 0;
            numReactions = 0;
            postCount++;
        }

        // Конструктор с параметрами
        public Post(int numViews, int numComments, int numReactions)
        {
            NumViews = numViews;
            NumComments = numComments;
            NumReactions = numReactions;
            postCount++;
        }

        // Метод для вывода информации об объекте
        public void Show()
        {
            Console.WriteLine($"Просмотры: {NumViews}, Комментарии: {NumComments}, Реакции: {NumReactions}");
        }

        // Метод для вычисления коэффициента вовлеченности
        public double CalculateEngagementRate(int numSubscribers)
        {
            if (numSubscribers <= 0) // Предотвращаем деление на ноль или отрицательное число подписчиков
            {
                EngagementRate = 0;
                Console.WriteLine("Недопустимое количество подписчиков.");
                return 0;
            }

            EngagementRate = ((double)(NumComments + NumReactions) / numSubscribers) * 100;
            EngagementRate = Math.Round(EngagementRate, 2); // Округляем до 0,01
            return EngagementRate;
        }

        // Статическая функция для вычисления коэффициента вовлеченности
        public static double CalculateEngagementRate(Post p, int numSubscribers)
        {
            if (numSubscribers <= 0) // Предотвращаем деление на ноль
            {
                p.EngagementRate = 0;
                Console.WriteLine("Недопустимое количество подписчиков.");
                return 0; // Или другое подходящее значение
            }

            p.EngagementRate = ((double)(p.NumComments + p.NumReactions) / numSubscribers) * 100;
            p.EngagementRate = Math.Round(p.EngagementRate, 2); // Округляем до 0,01

            return p.EngagementRate;
        }

        // Метод для вывода информации об вовлеченности объекта
        public void PrintEngagementInfo()
        {
            Console.WriteLine($" {EngagementRate}");
        }

        // Перегрузка унарного оператора !
        public static Post operator !(Post p)
        {
            p.NumReactions++;
            return p;
        }

        // Перегрузка унарного оператора ++
        public static Post operator ++(Post p)
        {
            p.NumViews++;
            return p;
        }

        // Перегрузка оператора явного приведения к bool
        public static explicit operator bool(Post p)
        {
            return p.NumViews > 0 && (p.NumComments > 0 || p.NumReactions > 0);
        }

        // Перегрузка оператора неявного приведения к double
        public static implicit operator double(Post post)
        {
            const int subscribers = 1000;
            return Math.Round((double)post.numViews / subscribers * 100, 2);
        }

        // Перегрузка оператора ==
        public static bool operator ==(Post p1, Post p2)
        {
            return p1.numViews == p2.numViews &&
                   p1.numComments == p2.numComments &&
                   p1.numReactions == p2.numReactions;
        }

        // Перегрузка оператора !=
        public static bool operator !=(Post p1, Post p2)
        {
            return !(p1 == p2);
        }

        // Метод Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Post other = (Post)obj;
            return this == other;
        }

        //Переопределение метода GetHashCode(важно при переопределении Equals)
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 31 + NumViews.GetHashCode();
            hash = hash * 31 + NumComments.GetHashCode();
            hash = hash * 31 + NumReactions.GetHashCode();
            return hash;
        }
    }
}
