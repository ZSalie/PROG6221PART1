using System;

namespace PROG6221POE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintBorder("Welcome to the Cyber Awareness Bot");

            using VoiceGreeting greeter = new VoiceGreeting();
            greeter.PlayWelcomeMessage();

            DisplayAsciiLogo();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Please enter your name: ");
            string userName = Console.ReadLine();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"\nBot: Nice to meet you, {userName}! Let's learn how to stay safe online.");
            Console.ResetColor();

            TypeEffect("Bot: You can ask me about phishing, password safety, safe browsing, or cyber hygiene.\n");

            CyberBotBot bot = new CyberBotBot(userName);
            ResponseManager responseManager = new ResponseManager();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\nAsk a question (or type 'exit' to quit): ");
                Console.ResetColor();

                string input = Console.ReadLine()?.Trim().ToLower();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(responseManager.GetRandomErrorResponse());
                    Console.ResetColor();
                    continue;
                }

                if (input == "exit")
                {
                    string farewell = $"Goodbye, {userName}! Stay cyber-safe.";
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Bot: {farewell}");
                    Console.ResetColor();

                    greeter.PlayVoiceMessage(farewell);
                    Console.WriteLine("\nPress any key to exit...");
                    Console.ReadKey();
                    break;
                }

                bot.Respond(input, responseManager);
            }
        }

        static void TypeEffect(string message, int delay = 30)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(delay);
            }
        }

        static void PrintBorder(string message)
        {
            string border = new string('═', message.Length + 4);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"╔{border}╗");
            Console.WriteLine($"║  {message}  ║");
            Console.WriteLine($"╚{border}╝");
            Console.ResetColor();
        }

        static void DisplayAsciiLogo()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"
 +----------------------------+
 |  Cyber Awareness Bot       |
 |  ========================= |
 |   [====] [====] [====]     |
 |   Stay Safe Online!        |
 +----------------------------+
");
            Console.ResetColor();
        }
    }
}
