using System;
using Jabbot;

namespace JabbrConsoleTest
{
    class Program
    {
        const string ServerUrl = "http://jabbr.net";
        const string RoomName = "Code52-testing-tw";

        static void Main()
        {
            Console.WriteLine("Connecting to {0}...", ServerUrl);

            var bot = new Bot(ServerUrl, "cyberzed-jibbr", "somepassword");

            bot.PowerUp();

            if (!TryCreateRoomIfNotExists(RoomName, bot))
            {
                Console.Write("Could not create room {0}. Exiting...");
                bot.ShutDown();
                return;
            }

            bot.Say("Hello world!", RoomName);

            Console.Write("Press any key to quit...");
            Console.ReadKey();

            bot.ShutDown();
        }

        private static bool TryCreateRoomIfNotExists(string roomName, Bot bot)
        {
            try
            {
                bot.CreateRoom(roomName);
            }
            catch (AggregateException e)
            {
                if (!e.GetBaseException().Message.Equals(string.Format("The room '{0}' already exists", roomName),
                        StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
