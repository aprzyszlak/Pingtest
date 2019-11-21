using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Threading;

namespace PingTest
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Podaj Ip serwera który pingować: ");
            string adres = Console.ReadLine();


            for ( ; ; )
            {
                bool ping = Pingowanie.PingHost(adres);
                Console.WriteLine("Status - Hana-srv:" + ping);
                Thread.Sleep(1000);
            }

            Console.ReadKey();
        }

        public static class Pingowanie
        {
            public static bool PingHost(string nameOrAddress, bool throwExceptionOnError = false)
            {
                bool pingable = false;
                using (Ping pinger = new Ping())
                {
                    try
                    {
                        PingReply reply = pinger.Send(nameOrAddress);
                        pingable = reply.Status == IPStatus.Success;
                    }
                    catch (PingException e)
                    {
                        if (throwExceptionOnError) throw e;
                        pingable = false;
                    }
                }
                return pingable;
            }
        }
    }
}
