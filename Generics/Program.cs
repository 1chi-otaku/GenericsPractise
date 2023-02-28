using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Program
    {
        
        static void Main(string[] args)
        {
            #region #1,2
            CompareThree<int> compare= new CompareThree<int>();
            compare.Max(5, 2, 20);
            compare.Min(5, 2, 20);
            #endregion
            #region #3

            int[] arr = new int[5] {1,2,3,5,12};
            SearchSum<int>(arr);

            #endregion
            #region 4

            MyStack<int> stack = new MyStack<int>(5);

            for (int i = 0; i < 10; i++)
            {
                stack.Push(i);
                stack.Print();
            }
            for (int i = 0; i < 15; i++)
            {
                stack.Pop();
                stack.Print();
            }
            #endregion
            #region 5
            MyQueue<int> queue = new MyQueue<int>(5);

            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
                queue.Print();
            }
            for (int i = 0; i < 15; i++)
            {
                queue.Denqueue();
                queue.Print();
            }
            #endregion
        }
        public static void SearchSum<T>(T[] arr)
        {
            dynamic sum = default(T);
            foreach (var elem in arr)
            {
                sum += elem;
            }
            Console.WriteLine(sum);
        }
    }
    class CompareThree<T>
        where T: IComparable<T>
    {
        public void Max(T a, T b, T c) {
            if(a.CompareTo(b) > 0 && a.CompareTo(c) > 0)
                Console.WriteLine(a);
            else if(b.CompareTo(c) > 0)
                Console.WriteLine(b);
            else
                Console.WriteLine(c);
        }
        public void Min(T a, T b, T c)
        {
            if (a.CompareTo(b) < 0 && a.CompareTo(c) > 0)
                Console.WriteLine(a);
            else if (b.CompareTo(c) < 0)
                Console.WriteLine(b);
            else
                Console.WriteLine(c);
        }
    }
   
    class MyStack<T>
    {
        T[] stack;
        public MyStack() {
            stack = new T[3];
        }
        public MyStack(int count)
        {
            stack = new T[count];
        }
        public MyStack(T[] stack) { 
            this.stack = stack;
        }

        public void Print()
        {
            foreach (var item in stack)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        public void Pop() => Array.Resize(ref stack, stack.Length - 1);
        public void Push(T item)
        {
            T[] newstack = new T[stack.Length + 1];
            for (int i = 0; i < stack.Length; i++)
            {
                newstack[i] = stack[i];
            }
            newstack[stack.Length] = item;
            stack = newstack;
        }

        public T Peek()
        {
            return stack[stack.Length - 1];
        }
        public int Count()
        {
            return stack.Length;
        }
    }
    class MyQueue<T>
    {
        T[] queue;
        public MyQueue()
        {
            queue = new T[3];
        }
        public MyQueue(int count)
        {
            queue = new T[count];
        }
        public MyQueue(T[] queue)
        {
            this.queue = queue;
        }
        public void Print()
        {
            foreach (var item in queue)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        public void Enqueue(T item)
        {
            T[] newqueue = new T[queue.Length + 1];
            for (int i = 0; i < queue.Length; i++)
            {
                newqueue[i] = queue[i];
            }
            newqueue[queue.Length] = item;
            queue = newqueue;
        }
        public void Denqueue() => queue = queue.Skip(1).ToArray();
        public T Peek()
        {
            return queue[0];
        }
        public int Count()
        {
            return queue.Length;
        }
    }


}
