using System;
using System.Threading;
using System.Speech.Synthesis;

namespace PROG6221Part1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PlayVoiceGreeting();

            DisplayAsciiLogo();

            Console.Write("👤 Please enter your name: ");
            string userName = Console.ReadLine();
            Console.WriteLine($"\n🔐 Nice to meet you, {userName}! Let's learn how to stay safe online.\n");

            TypeEffect("💬 You can ask me about phishing, password safety, or safe browsing.\n");

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\n❓ Ask a question (or type 'exit' to quit): ");
                Console.ResetColor();
                string userInput = Console.ReadLine().Trim().ToLower();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.WriteLine("⚠️ I didn’t quite understand that. Could you rephrase?");
                    continue;
                }

                if (userInput == "exit")
                {
                    Console.WriteLine("👋 Goodbye! Stay cyber-safe.");
                    break;
                }

                RespondToUser(userInput);
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
                Console.WriteLine("⚠️ Voice greeting could not play.");
                Console.WriteLine("💡 Error details: " + ex.Message);
                Console.ResetColor();

                
                Console.WriteLine("\n[Text Greeting] Hello! Welcome to the Cybersecurity Awareness Bot.");
            }
        }

        static void DisplayAsciiLogo()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"
      _______________________
     /                       \
    |     💬 Cyber Awareness |
    |       _______          |
    |      /       \         |
    |     |   ???   |        |
    |      \_______/         |
    |                        |
     \_______________________/
           \\
            \\
             \\
              🤖
    ");
            Console.ResetColor();
        }

        static void RespondToUser(string input)
        {
            switch (input)
            {
                case "how are you?":
                case "how are you":
                    Console.WriteLine("🤖 I'm always ready to help you stay safe online!");
                    break;
                case "what's your purpose?":
                case "what is your purpose?":
                    Console.WriteLine("🔍 I'm here to educate you about common cyber threats and how to avoid them.");
                    break;
                case "what can i ask you about?":
                case "help":
                case "topics":
                    Console.WriteLine("📚 You can ask about:\n- Phishing\n- Password safety\n- Safe browsing habits");
                    break;
                case "phishing":
                    Console.WriteLine("🎣 Phishing is when attackers trick you into giving away personal info using fake emails or websites.");
                    break;
                case "password safety":
                    Console.WriteLine("🔑 Use strong, unique passwords and enable two-factor authentication where possible.");
                    break;
                case "safe browsing":
                    Console.WriteLine("🌐 Always check URLs, avoid clicking on suspicious links, and keep your browser updated.");
                    break;
                default:
                    Console.WriteLine("❗ Sorry, I didn't understand that. Try asking about 'phishing', 'password safety', or 'safe browsing'.");
                    break;
            }
        }

        static void TypeEffect(string message, int delay = 30)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
        }
    }
}
