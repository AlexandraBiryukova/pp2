﻿using System;
using System.Collections.Generic;
using System.IO;
namespace Snake
{
    public class Wall
    {
        public List<Point> body;
        public char sign;
        public ConsoleColor color;
        public  int level;

        public Wall()
        {
            color = ConsoleColor.Red;
            sign = '☐';
            body = new List<Point>();
            level = 1;
    
        }

        public void LoadLevel()
        {//загружаем уровень из существуещего тхт файла
            
            body.Clear();

            string filePath = string.Format(@"/Users/alexandra/Documents/LAB1/lab4/Snake/L{0}.txt", level);
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string line ="";
            int i = 0;
            int row = 0;
            while (i < 24)
            {
                line = sr.ReadLine();
                for (int col = 0; col < line.Length; col++)
                {
                    if (line[col] =='☐')
                    {
                        body.Add(new Point(col, row));
                    }
                }
                i++;
                row++;
            }
        }

        public void Draw()
        {
            Console.ForegroundColor = color;
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
            }
        }
    }
}
