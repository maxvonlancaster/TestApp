using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

            Action actionWithLocker = () =>
            {
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
            // Наряду с оператором lock для синхронизации потоков мы можем использовать мониторы, представленные классом System.Threading.Monitor. 
            // Фактически конструкция оператора lock из прошлой темы инкапсулирует в себе синтаксис использования мониторов.

            // Метод Monitor.Enter принимает два параметра - объект блокировки и значение типа bool, которое указывает на результат блокировки 
            // (если он равен true, то блокировка успешно выполнена).

            Action actionWithMonitor = () =>
            {
                bool acquiredLock = false;

                try
                {
                    Monitor.Enter(locker, ref acquiredLock);
                    for (x = 1; x < 10; x++)
                    {
                        Console.WriteLine("{0}: {1}", Thread.CurrentThread.Name, x);
                        Thread.Sleep(100);
                    }
                }
                finally
                {
                    if (acquiredLock)
                        Monitor.Exit(locker);
                }
            };


            for (int i = 0; i < 5; i++)
            {
                Thread t = new Thread(new ThreadStart(actionWithMonitor));
                t.Name = "Thread " + i.ToString();
                t.Start();
            }
        }


        AutoResetEvent autoReset = new AutoResetEvent(true);

        public void ClassAutoResetEvent()
        {
            // Класс AutoResetEvent также служит целям синхронизации потоков. Этот класс является оберткой над объектом ОС Windows "событие" 
            // и позволяет переключить данный объект-событие из сигнального в несигнальное состояние

            Action actionWithARE = () =>
            {

                autoReset.WaitOne();
                for (x = 1; x < 10; x++)
                {
                    Console.WriteLine("{0}: {1}", Thread.CurrentThread.Name, x);
                    Thread.Sleep(100);
                }
                autoReset.Set();
            };


            for (int i = 0; i < 5; i++)
            {
                Thread t = new Thread(new ThreadStart(actionWithARE));
                t.Name = "Thread " + i.ToString();
                t.Start();
            }
        }

        // Thread is a lower-level concept: if you're directly starting a thread, you know it will be a separate thread, rather than executing on 
        // the thread pool etc.
        // Task is more than just an abstraction of "where to run some code" though - it's really just "the promise of a result in the future". 
        // ThreadPool is a wrapper around a pool of threads maintained by the CLR. ThreadPool gives you no control at all; you can submit work 
        // to execute at some point, and you can control the size of the pool, but you can't set anything else. You can't even tell when the 
        // pool will start running the work you submit to it.

        // В эпоху многоядерных машин, которые позволяют параллельно выполнять сразу несколько процессов, стандартных средств работы с потоками в 
        // .NET уже оказалось недостаточно. Поэтому во фреймворк .NET была добавлена библиотека параллельных задач TPL (Task Parallel Library), 
        // основной функционал которой располагается в пространстве имен System.Threading.Tasks. Данная библиотека позволяет распараллелить задачи и 
        // выполнять их сразу на нескольких процессорах, если на целевом компьютере имеется несколько ядер. Кроме того, упрощается сама работа по 
        // созданию новых потоков. Поэтому начиная с .NET 4.0. рекомендуется использовать именно TPL и ее классы для создания многопоточных 
        // приложений, хотя стандартные средства и класс Thread по-прежнему находят широкое применение.

        // TPL

        public void UsingTask()
        {
            // В основе библиотеки TPL лежит концепция задач, каждая из которых описывает отдельную продолжительную операцию. В библиотеке классов 
            // .NET задача представлена специальным классом - классом Task, который находится в пространстве имен System.Threading.Tasks. Данный 
            // класс описывает отдельную задачу, которая запускается асинхронно в одном из потоков из пула потоков. Хотя ее также можно запускать 
            // синхронно в текущем потоке.

            Task task = new Task(() => Console.WriteLine("Hello")); // В качестве параметра объект Task принимает делегат Action, то есть мы можем 
            // передать любое действие, которое соответствует данному делегату, например, лямбда-выражение, как в данном случае, или ссылку на 
            // какой-либо метод
            task.Start(); // 

            // Второй способ заключается в использовании статического метода Task.Factory.StartNew(). Этот метод также в качестве параметра 
            // принимает делегат Action, который указывает, какое действие будет выполняться. При этом этот метод сразу же запускает задачу
            Task task1 = Task.Factory.StartNew(() => Console.WriteLine("Hello1"));
            // В качестве результата метод возвращает запущенную задачу.

            // Третий способ определения и запуска задач представляет использование статического метода Task.Run():
            Task task2 = Task.Run(() => Console.WriteLine("Hello2"));

            // Важно понимать, что задачи не выполняются последовательно. Первая запущенная задача может завершить свое выполнение после последней 
            // задачи.
            Task task3 = new Task(DummyMethodOne);
            task3.Start();
            Console.WriteLine("End of main thread");
            // End of main thread may be before DummyMethodOne 

            // Чтобы указать, что тред Main должен подождать до конца выполнения задачи, нам надо использовать метод Wait:
            Task task4 = new Task(DummyMethodOne);
            task4.Start();
            task4.Wait();
            Console.WriteLine("End of main thread");

            // Класс Task имеет ряд свойств, с помощью которых мы можем получить информацию об объекте.Некоторые из них:
            // AsyncState: возвращает объект состояния задачи
            // CurrentId: возвращает идентификатор текущей задачи
            // Exception: возвращает объект исключения, возникшего при выполнении задачи
            // Status: возвращает статус задачи
            Console.WriteLine(task4.AsyncState);
            Console.WriteLine(task4.Status);
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
