using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    class Program
    {
        private static int[] mas;

        static void Main(string[] args)
        {
          
            Presentor t = new Presentor();
            Console.WriteLine("Выбирите действие с массивом целых чисел" +
                              "\n1-Добавить элемент в конец " +
                               "\n2-Удалить по индексу " +
                               "\n3-Вывести на экран " +
                               "\n4-Сортировка по убыванию четных элементов,остальные на местах " +
                               "\n0-выход из прогораммы  ");

            int k = Convert.ToInt32(Console.ReadLine());

            switch (k)
            {
                case 1:
                    Console.WriteLine("Введите целое значение");
                    int f = Console.Read();
                    t.Add(mas, f);
                    break;
                case 2:
                    Console.WriteLine("Введите индекс элемента который вы хотите удалить");
                    int n = Convert.ToInt32(Console.ReadLine());
                    t.Delete(mas,n);
                    break;

                case 3:
                    t.Show(mas);
                    break;

                case 4: t.SortMas(mas);
                    break;

                default:
                    Console.WriteLine("default");
                    break;

            }

            
            Console.ReadKey();


        }
    }
}
