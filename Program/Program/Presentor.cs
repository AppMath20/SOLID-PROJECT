using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    class Presentor
    {
        public static int size = 10;
        public int[] mas = new int[size];

        public Presentor()
        {

            Random r = new Random();
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = r.Next(-100, 101);
                Console.Write(mas[i] + " ");
            }
        }

        public void Add(int []mas, int value)
        { 
                int[] newArray = new int[size + 1];

            for (int i = 0; i < size; i++)
            {
                newArray[i] = mas[i];
            }

            newArray[size+1] = value;

            mas = newArray;
        }

  

        public void Delete(int []mas,int i)
        { 
            Console.WriteLine(string.Join(" ", mas.Select(x => x.ToString()).ToArray()));
          
            var query = mas.Where(n => mas.ElementAt(i) != n);
            Console.WriteLine(string.Join(" ", query.Select(x => x.ToString()).ToArray()));
            Console.ReadKey();

        }

        public void Show(int[] mas)
        {
            for (int i = 0; i < mas.Length; i++)
            {

                Console.Write(mas[i] + " ");

            }
        }

        public void SortMas(int []mas)
        {
            for (int i = 0; i < mas.Length - 1; i++)
            {
                if (mas[i] % 2==0) continue;
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if ((mas[j] % 2!=0) && (mas[i] > mas[j]))
                    {
                        int tmp = mas[i];
                        mas[i] = mas[j];
                        mas[j] = tmp;
                    }
                }
            }
        }
    }
}
