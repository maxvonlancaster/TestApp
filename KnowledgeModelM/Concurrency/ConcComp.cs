using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeModel.Concurrency
{
    public class ConcComp
    {
        // 1.1 Introduction to concurrency 

        // Concurrency -> doing more than one thing at a time

        // 1.2 Introduction to Asynchronous Programming 
        public async Task DoSomethingAsync()
        {
            // async keyword -> to enable await keyword within that method
            int val = 13;

            // asynchronously wait 1 sec
            await Task.Delay(TimeSpan.FromSeconds(1));

            val *= 2;

            // asynchronously wait 1 sec
            await Task.Delay(TimeSpan.FromSeconds(1));

            Trace.WriteLine(val);
        }

        public async Task DoSomethingNewAsync()
        {

        }

        // 1.6 Introduction to Multithreaded Programming 

        // 1.7 Introduction to Concurrent Applications 

    }
}
