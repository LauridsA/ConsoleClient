using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;

namespace ConsoleClient
{
    public class ClientCaller
    {
        HttpClient client = new HttpClient();
        private string url = "Whatever the path is";
        public ClientCaller()
        {
            //intentionally empty
        }

        public void CallServiceInParallel(int numberOfTimesToCall)
        {
            for (int i = 0; i < numberOfTimesToCall; i++)
            {
                Thread thread = new Thread(CallService);
                thread.Start();
            }
        }

        private async void CallService()
        {
            Random rng = new Random();
            var rand1 = rng.Next(5000, 9000);
            var rand2 = rng.Next(10000, 100000);
            string logString = "";
            //log start
            Log("Starting request: ");

            HttpResponseMessage response = await client.GetAsync(Path.Combine(url, rand1.ToString(), rand2.ToString()));
            if (response.IsSuccessStatusCode)
                logString = await response.Content.ReadAsStringAsync();

            //log end
            Log("Logging end:\n" + logString);
        }

        private void Log(string logString)
        {
            //do the logging
        }
    }
}
