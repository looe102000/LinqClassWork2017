﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LinqClassWork
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] data = { 1, 3, 5, 7, 9 };

            //原始版本

            Console.WriteLine("原始版本");
            foreach (var item in Filter(data, (s) => s > 5))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            //Console.ReadLine();

            //Linq 版

            Console.WriteLine("Linq 版");
            var result = from s1 in data where s1 > 5 select s1;
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            //Console.ReadLine();

            //Linq 取得 Windows 資料夾中 .exe 檔案

            Console.WriteLine("Windows 資料夾中 .exe 檔案");
            var result1 = from s1 in Directory.GetFiles(@"C:\\Windows")
                          where s1.EndsWith(".exe")
                          select s1;

            foreach (var item in result1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            //Console.ReadLine();

            //IEnumerator 迭代子 ；底下實作內容與 for each 效果差不多

            Console.WriteLine("IEnumerator 迭代子 ；底下實作內容與 for each 效果差不多 ");
            IEnumerator iterator = data.GetEnumerator();

            while (iterator.MoveNext())
            {
                Console.WriteLine(iterator.Current.ToString());
            }
            Console.WriteLine();
            //Console.ReadLine();

            //使用 linq 查出 含有 b 的元素
            Console.WriteLine("使用 linq 查出 含有 b 的元素 ");

            string[] data2 = { "aa", "t", "ccccc", "cb", "db", "tb" };
            var result3 = from s1 in data2 where s1.Contains("b") select s1;
            foreach (var item in result3)
            {
                Console.WriteLine(item.ToString());
            }


            //string 陣列找出符合的元素
            Console.WriteLine("string 陣列找出符合的元素");

            string[] infilter = { "bbbbb","ccccc"};

            var result4 = from s1 in data2 where infilter.Contains(s1) select s1;
            foreach (var item in result4)
            {
                Console.WriteLine(item.ToString());
            }


            Console.WriteLine();
            Console.ReadLine();
        }

        //原始版本
        private static List<T> Filter<T>(T[] source, Func<T, Boolean> func)
        {
            List<T> result = new List<T>();
            foreach (var item in source)
            {
                if (func(item))
                    result.Add(item);
            }
            return result;
        }
    }
}