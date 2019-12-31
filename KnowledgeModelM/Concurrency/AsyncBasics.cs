using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeModel.Concurrency
{
    public class AsyncBasics
    {
        // Pausing for a Period of Time (chapter 2.1)
        // The Task type has a static method Delay that returns a task that completes after the specified time.
        static async Task<T> DelayResult<T>(T result, TimeSpan delay) 
        {
            await Task.Delay(delay);
            return result;
        }
    }
}
