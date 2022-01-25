using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcGIS.Desktop.Framework.Dialogs;
using ArcGIS.Desktop.Framework.Threading.Tasks;

namespace ProTestCrash
{
    class Shared
    {
        public static async Task DoCrash(string caseToRun)
        {
            try
            {
                switch (caseToRun)
                {
                    case "demo1": // fine
                        // this won't cause a crash
                        var res2 = await ExampleTask1();
                        Console.WriteLine(res2);
                        break;

                    case "demo2": // crash pro
                        // if we combine QT and async void it crashes pro
                        ExampleTask2();
                        break;

                    case "demo3": // crash pro
                        // this should be safe in .net 4.5? yet it still crashes pro.
                        // see https://devblogs.microsoft.com/pfxteam/task-exception-handling-in-net-4-5/
                        ExampleTask3();
                        break;

                    case "demo4": // fine
                        await ExampleTask4();
                        break;
                }


            }
            catch (Exception e)
            {
                // success, this is what we want. Deal with the exception
                Console.WriteLine(e);
                MessageBox.Show("Success!");
            }

            switch (caseToRun)
            {
                case "demo5": // Pro crash (unobserved task exception)
                    Example5();
                    break;
            }

        }

        private static Task<bool> ExampleTask1()
        {
            return QueuedTask.Run<bool>(() =>
            {
                var i = 0;
                i = i / 0;
                return i > 0;
            });
        }

        private static async void ExampleTask2()
        {
            await QueuedTask.Run<bool>(() =>
            {
                var i = 0;
                i = i / 0;
                return i > 0;
            });

            await Task.Delay(2000);

        }

        private static async void ExampleTask3()
        {

            await ThrowAsync();
        }



        static async Task ExampleTask4()
        {

            await ThrowAsync();
        }

        static void Example5()
        {

            throw new Exception("An error occurred");
        }

        // Helper that sets an exception async
        static Task ThrowAsync()
        {
            var tcs = new TaskCompletionSource<string>();
            ThreadPool.QueueUserWorkItem(_ => tcs.SetException(new Exception("ThrowAsync")));
            return tcs.Task;
        }
    }
}
