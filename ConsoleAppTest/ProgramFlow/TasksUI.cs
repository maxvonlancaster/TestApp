using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.ProgramFlow
{
    // 
    public class TasksUI
    {
        // 
        public static void BlockTheUserInterface()
        {

        }

        // 
        public static void UsingATask()
        {

        }

        // 
        public static void UpdateTheUI()
        {

        }

        // 
        public static void UsingAsync()
        {

        }

        // 
        public static void ExceptionsAndAsync()
        {

        }

        private static async Task<string> FetchWebPage(string url)
        {
            HttpClient httpClient = new HttpClient();
            return await httpClient.GetStringAsync(url);
        }

        static async Task<IEnumerable<string>> FetchWebPages(string[] urls)
        {
            var tasks = new List<Task<String>>();
            foreach (string url in urls)
            {
                tasks.Add(FetchWebPage(url));
            }
            return await Task.WhenAll(tasks);
        }

        // An async method can contain a number of awaited actions. These will be completed in sequence.In other words, if you want to create an “awaitable” task
        // that returns when a number of parallel tasks have completed you can use the Task.WhenAll method to create a task that completes when a given lists of
        // tasks have been completed.  
        // The order of the items in the returned collection may not match the order of the submitted site names and there is no
        // aggregation of any exceptions thrown by the calls to FetchWebPage.There is also a WhenAny method that will return when any one of the given tasks
        // completes.This works in the same way as the WaitAny method that you saw earlier.        public static void AwaitParallelTasks()
        {
            string[] urls = new string[] { "https://www.wikipedia.org/", "https://www.duolingo.com" };
            var result = FetchWebPages(urls);
        }
    }
}
