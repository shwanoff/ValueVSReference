using System;
using System.Collections;
using System.Collections.Generic;

namespace ValueVSReference
{
    public static class Program
    {
        const int COUNT = 100_000_000;

        public static void Main()
        {
            ValueTypePerfTest(COUNT);
            ReferenceTypePerfTest(COUNT);
            Console.ReadLine();
        }

        private static void ValueTypePerfTest(int count)
        {

            using (new OperationTimer("List<int>"))
            {
                var list = new List<int>();
                for (var i = 0; i < count; i++)
                {
                    list.Add(i);     // Без упаковки         
                    var x = list[i]; // Без распаковки      
                }

                list = null; // Для удаления в процессе уборки мусора    
            }

            using (new OperationTimer("ArrayList of int"))
            {
                var array = new ArrayList();
                for (var i = 0; i < count; i++)
                {
                    array.Add(i);          // Упаковка         
                    var x = (int)array[i]; // Распаковка      
                }

                array = null; // Для удаления в процессе уборки мусора    
            }
        }

        private static void ReferenceTypePerfTest(int count)
        {
            using (new OperationTimer("List<string>"))
            {
                var list = new List<string>();
                for (var i = 0; i < count; i++)
                {
                    list.Add("X");   // Копирование ссылки       
                    var x = list[i]; // Копирование ссылки    
                }

                list = null; // Для удаления в процессе уборки мусора  
            }

            using (new OperationTimer("ArrayList of string"))
            {
                var array = new ArrayList();
                for (var i = 0; i < count; i++)
                {
                    array.Add("X");           // Копирование ссылки         
                    var x = (string)array[i]; // Проверка преобразования и копирование ссылки     
                }
                
                array = null; // Для удаления в процессе уборки мусора
            }
        }
    }
}