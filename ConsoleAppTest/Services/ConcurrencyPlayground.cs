using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleAppTest.Services
{
    public class ConcurrencyPlayground
    {
        // MultiThreading

        public void ClassThread()
        {
            // Поток предствляет некоторую часть кода программы. При выполнении программы каждому потоку выделяется определенный квант времени. 
            // И при помощи многопоточности мы можем выделить в приложении несколько потоков, которые будут выполнять различные задачи 
            // одновременно.
            // Main functionality in System.Threading, there class Thread -> separate thread

            Thread t = Thread.CurrentThread; // Get current Thread

            Console.WriteLine($"Имя потока: {t.Name}");
            Console.WriteLine($"Запущен ли поток: {t.IsAlive}");
            Console.WriteLine($"Приоритет потока: {t.Priority}"); // Lowest, BelowNormal, Normal(default), AboveNormal, Highest
            Console.WriteLine($"Статус потока: {t.ThreadState}"); // 
            Console.WriteLine($"Домен приложения: {Thread.GetDomain().FriendlyName}"); // получаем домен приложения

        }

        public void ThreadCreation()
        {
            // Используя класс Thread, мы можем выделить в приложении несколько потоков, которые будут выполняться одновременно.

            // Во - первых, для запуска нового потока нам надо определить задачу в приложении, которую будет выполнять данный поток. 
            // Для этого мы можем добавить новый метод, производящий какие-либо действия.

            // Для создания нового потока используется делегат ThreadStart, который получает в качестве параметра метод

            // И чтобы запустить поток, вызывается метод Start.
            Thread t = new Thread(new ThreadStart(DummyMethodOne));
            t.Start();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("First thread: {0}", i);
                Thread.Sleep(300);
            }

            // You can also use Thread myThread = new Thread(Count); ThreadStart delegate is created implicitly anyway
        }

        public void ThreadsWithParams()
        {
            // ParameterizedThreadStart -> передать какие-нибудь параметры в поток
            int number = 4;
            Thread t = new Thread(new ParameterizedThreadStart(DummyMethodTwo));
            // ParameterizedThreadStart мы сталкиваемся с ограничением: мы можем запускать во втором потоке только такой метод, который в 
            // качестве единственного параметра принимает объект типа object. Поэтому в данном случае нам надо дополнительно привести 
            // переданное значение к типу int, чтобы его использовать в вычислениях.
            t.Start(number);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("First thread: {0}", i);
                Thread.Sleep(300);
            }

            // Но что делать, если нам надо передать не один, а несколько параметров различного типа? В этом случае на помощь приходит 
            // классовый подход (Сначала определяем специальный класс Counter, объект которого будет передаваться во второй поток, а в 
            // методе Main передаем его во второй поток.)
        }

        
        static object locker = new object();
        static int x = 0;

        public void ThreadSynchronization()
        {
            // Нередко в потоках используются некоторые разделяемые ресурсы, общие для всей программы. Это могут быть общие переменные, файлы, 
            // другие ресурсы. (here it is x variable)

            // Решение проблемы состоит в том, чтобы синхронизировать потоки и ограничить доступ к разделяемым ресурсам на время их использования 
            // каким-нибудь потоком. Для этого используется ключевое слово lock. Оператор lock определяет блок кода, внутри которого весь код 
            // блокируется и становится недоступным для других потоков до завершения работы текущего потока.

            Action actionWithLocker = () => {
                lock (locker)
                {
                    for (x = 1; x < 10; x++)
                    {
                        Console.WriteLine("{0}: {1}", Thread.CurrentThread.Name, x);
                        Thread.Sleep(100);
                    }
                }
            };

            for (int i = 0; i < 5; i++) 
            {
                Thread t = new Thread(new ThreadStart(actionWithLocker));
                t.Name = "Thread " + i.ToString();
                t.Start();
            }
        }

        public void Monitors()
        {

        }

        public void ClassAutoResetEvent()
        {

        }


        // TPL

        public void UsingTask() 
        {
        
        }

        public void WorkingWithTask()
        {

        }

        public void TaskContinuation()
        {

        }

        public void ClassParallel()
        {

        }

        public void TaskCancellation()
        {

        }


        // Async

        public void AsyncMethods()
        {

        }

        public void ReturnResult()
        {

        }

        public void Calling()
        {

        }

        public void ErrorProcessing()
        {

        }

        public void Cancellation()
        {

        }

        public void Streams()
        {

        }


        // pLinq

        public void UsingAsParallel()
        {

        }

        public void UsingAsOrdered()
        {

        }

        public void PlinqCancellation()
        {

        }


        // Additional Methods

        private void DummyMethodOne() 
        {
            for (int i = 0; i < 10; i++) 
            {
                Console.WriteLine("Second thread: {0}", i);
                Thread.Sleep(400);
            }
        }

        private void DummyMethodTwo(object x)
        {
            int j = (int)x;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Second thread: {0}, paramether: {1}", i, j);
                Thread.Sleep(400);
            }
        }
    }
}
