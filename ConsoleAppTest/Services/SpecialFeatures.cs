using ConsoleAppTest.DebugAndSecurity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Transactions;

namespace ConsoleAppTest.Services
{
    // TODO: Weakreference, Mutex, Transaction, 
    public class SpecialFeatures
    {
        public T DefaultValue<T>()
        {
            return default(T);
        }

        public void DeafultValues()
        {
            ArrayList list = new ArrayList();
            list.Add(DefaultValue<bool>());
            list.Add(DefaultValue<string>());
            list.Add(DefaultValue<int>());
            list.Add(DefaultValue<double>());
            list.Add(DefaultValue<float>());
            list.Add(DefaultValue<char>());
            list.Add(DefaultValue<MusicTrack>());
            list.Add(DefaultValue<object>());
            list.Add(DefaultValue<byte[]>());
            list.Add(DefaultValue<DateTime>());

            foreach (var elem in list)
            {
                Console.WriteLine(elem);
            }
        }

        public void HasValueProperty()
        {
            int? x = null;
            int y;
            if (x.HasValue)
                y = x.Value;
            bool b = x.HasValue;
        }

        public void StringJoin()
        {
            string outPut = String.Join(",", new string[] {"Hello", "There", "!" });
            Console.WriteLine(outPut);

            // TODO: Visual Studio feature. When you start your comment with TODO, it's added to your Visual Studio Task List (View -> Task List. Comments)

            var list = Enumerable.Range(0, 100);
            foreach (int elem in list)
            {
                Console.WriteLine(elem);
            }
        }

        public void MultipleObjectsUsing()
        {
            //using (Font f1 = )
            //{

            //}
        }

        // DefaultValue attribute -> Specifies the default value for a property.
        [DefaultValue(true)]
        public bool SomeProperty { get; set; }

        // Describes a clone of a transaction providing guarantee that the transaction cannot be committed until the application comes to 
        // rest regarding work on the transaction. This class cannot be inherited.
        public void Transactionc()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                // Perform transactional work here.
            }
        }

        public void StringIsNullOrEmptyUsage()
        {
            string s = "";
            if (String.IsNullOrEmpty(s))
                Console.WriteLine("Empty!");
        }

        // iterate through your generic list using a delegate method
        public void ListForeach()
        {
            List<string> list = new List<string>()
            {
                "a",
                "b",
                "c",
                "d"
            };

            list.ForEach(s => 
            {
                Console.WriteLine(s);
            });
        }

        // On-demand field initialization in one line:
        private string _str;

        public string Str
        {
            get { return _str ?? "new string"; }
        }


    }
}
