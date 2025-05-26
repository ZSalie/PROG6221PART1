using System;
using System.Speech.Synthesis;

namespace PROG6221POE
{
    public class CyberAwarenessBot : BaseBot
    {
        public override void GreetUser()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"\nBot: Nice to meet you, {UserName}! Let's learn how to stay safe online.");
            Console.ResetColor();
            TypeEffect("Bot: You can ask me about phishing, password safety, safe browsing, or cyber hygiene.\n");
        }

        public override void Respond(string input)
        {
            string lowerInput = input.ToLower();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n────────────────────────────────────────────");
            Console.ForegroundColor = ConsoleColor.Blue;

            if (MatchKeywords(lowerInput, new[] { "phishing", "scam", "spoofing" }))
                Console.WriteLine("Bot: Phishing is when attackers use fake emails or messages to trick you...");
            else if (MatchKeywords(lowerInput, new[] { "password", "safe password" }))
                Console.WriteLine("Bot: Use strong, unique passwords and enable 2FA!");
            else if (MatchKeywords(lowerInput, new[] { "browse", "surf", "online safety" }))
                Console.WriteLine("Bot: Safe browsing includes checking for HTTPS and using antivirus.");
            else if (MatchKeywords(lowerInput, new[] { "cyber hygiene", "security habits" }))
                Console.WriteLine("Bot: Keep software updated and back up your data.");
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Bot: Sorry, I didn't understand. Ask about 'phishing', 'password safety', etc.");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("────────────────────────────────────────────");
            Console.ResetColor();
        }

        public override void PlayVoiceMessage(string message)
        {
            try
            {
                using SpeechSynthesizer synth = new SpeechSynthesizer();
                synth.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult);
                synth.Speak(message);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Bot: Voice output failed.");
                Console.WriteLine("Error: " + ex.Message);
                Console.ResetColor();
            }
        }

        public override void DisplayLogo()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"
 +----------------------------+
 |  Cyber Awareness Bot       |
 |  ========================= |
 |   [====] [====] [====]     |
 |   Stay Safe Online!        |
 +----------------------------+");
            Console.ResetColor();
        }

        private bool MatchKeywords(string input, string[] keywords)
        {
            foreach (string word in keywords)
                if (input.Contains(word)) return true;
            return false;
        }

        private void TypeEffect(string message, int delay = 30)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(delay);
            }
        }
    }
}
