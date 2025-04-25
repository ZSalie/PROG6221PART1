using System;
using System.Threading;
using System.Speech.Synthesis;

namespace PROG6221Part1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintBorder("Welcome to the Cyber Awareness Bot");
            PlayVoiceGreeting();
            DisplayAsciiLogo();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Please enter your name: ");
            string userName = Console.ReadLine();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"\nBot: Nice to meet you, {userName}! Let's learn how to stay safe online.");
            Console.ResetColor();

            TypeEffect("Bot: You can ask me about phishing, password safety, safe browsing, or cyber hygiene.\n");
            //Loops for question and answer
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\n???: Ask a question (or type 'exit' to quit): ");
                Console.ResetColor();

                string userInput = Console.ReadLine().Trim().ToLower();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Bot: I didn’t quite understand that. Could you rephrase?");
                    Console.ResetColor();
                    continue;
                }

                if (userInput == "exit")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Bot: Goodbye! Stay cyber-safe!");
                    Console.ResetColor();
                    break;
                }

                RespondToUser(userInput, userName);
            }
        }

        static void PlayVoiceGreeting()
        {
            try
            {
                using (SpeechSynthesizer synth = new SpeechSynthesizer())
                {
                    synth.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult);
                    synth.Speak("Hello! Welcome to the Cybersecurity Awareness Bot. I'm here to help you stay safe online.");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Bot: Voice greeting could not play.");
                Console.WriteLine("Bot: Error: " + ex.Message);
                Console.ResetColor();

                Console.WriteLine("\nBot: Hello! Welcome to the Cybersecurity Awareness Bot.");
            }
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

        static void RespondToUser(string input, string userName)
        {
            input = input.ToLower();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n────────────────────────────────────────────");
            Console.ForegroundColor = ConsoleColor.Blue;

            // Uses keywords to determine the response
            bool ContainsAny(string[] keywords) => Array.Exists(keywords, keyword => input.Contains(keyword));

            if (ContainsAny(new[] { "how are you", "how you doing", "how do you feel" }))
            {
                Console.WriteLine("Bot: I'm doing great, thanks! Always ready to help you stay cyber-safe.");
            }
            else if (ContainsAny(new[] { "purpose", "what can you do", "what are you", "who are you", "what's your function" }))
            {
                Console.WriteLine("Bot: I'm here to teach you about online threats like phishing, weak passwords, and unsafe browsing.");
            }
            else if (ContainsAny(new[] { "help", "topics", "what can i ask", "what do you teach" }))
            {
                Console.WriteLine("Bot: You can ask about:\n- Phishing\n- Password safety\n- Safe browsing\n- Cyber hygiene tips");
            }
            else if (ContainsAny(new[] { "phishing", "scam", "email scam", "fake email", "fraud", "spoofing" }))
            {
                Console.WriteLine("Bot: Phishing is when attackers use fake emails or messages to trick you into giving away personal info. Never click suspicious links!");
            }
            else if (ContainsAny(new[] { "password", "passwords", "strong password", "safe password", "password safety", "password tip", "my password" }))
            {
                Console.WriteLine("Bot: Password safety means creating unique, complex passwords and using tools like password managers. Always enable two-factor authentication!");
            }
            else if (ContainsAny(new[] { "browsing", "browse safely", "safe surfing", "internet safety", "web safety", "online surfing" }))
            {
                Console.WriteLine("Bot: Safe browsing means checking URLs for HTTPS, not clicking unknown links, and using ad-blockers or antivirus software.");
            }
            else if (ContainsAny(new[] { "cyber hygiene", "stay safe", "online safety", "hygiene", "good habits", "cyber habits", "security habits", "cybersecurity habits" }))
            
                Console.WriteLine("Bot: Good cyber hygiene includes updating your software regularly, avoiding public Wi-Fi for sensitive tasks, and backing up your data.");
            
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Bot: Hmm, I didn't quite catch that. Try asking about 'phishing', 'password safety', 'safe browsing', or 'cyber hygiene'.");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("────────────────────────────────────────────");
            Console.ResetColor();
        }

        static void TypeEffect(string message, int delay = 30)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(delay);
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
    }
}
