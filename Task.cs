using System;
using System.Collections.Generic;

namespace Labirint
{
    internal class Tasks
    {
        public static int _counter { get; private set; } = 0;
        public static int HasExit(int startI, int startJ, int[,] l)
        {
            if (l[startI, startJ] == 1)
            {
                Console.WriteLine("Начальная точка находится в стене");
            }
            else if (l[startI, startJ] == 2)
            {
                _counter++;
                Console.WriteLine("Выход находится на входе");
            }

            var stack = new Stack<Tuple<int, int>>();
            stack.Push(new(startI, startJ));
            while (stack.Count > 0)
            {
                var tmp = stack.Pop();
                if (l[tmp.Item1, tmp.Item2] == 2)
                {
                    _counter++;
                    Console.WriteLine("Выход найден");
                }
                l[tmp.Item1, tmp.Item2] = 1;
                if (tmp.Item2 > 0 && l[tmp.Item1, tmp.Item2 - 1] != 1)
                    stack.Push(new(tmp.Item1, tmp.Item2 - 1)); // вверх
                if (tmp.Item2 + 1 < l.GetLength(1) && l[tmp.Item1, tmp.Item2 + 1] != 1)
                    stack.Push(new(tmp.Item1, tmp.Item2 + 1)); // низ
                if (tmp.Item1 > 0 && l[tmp.Item1 - 1, tmp.Item2] != 1)
                    stack.Push(new(tmp.Item1 - 1, tmp.Item2)); // влево
                if (tmp.Item1 + 1 < l.GetLength(0) && l[tmp.Item1 + 1, tmp.Item2] != 1)
                    stack.Push(new(tmp.Item1 + 1, tmp.Item2)); // вправо
            }
            Console.Write($"Всего выходов ");
            return _counter;
        }
    }
}