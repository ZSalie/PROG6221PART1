using System;
using System.Speech.Synthesis;

namespace PROG6221POE
{
    public class VoiceGreeting : IDisposable
    {
        private readonly SpeechSynthesizer _synth;

        public VoiceGreeting()
        {
            _synth = new SpeechSynthesizer();
            _synth.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult);
        }

        public void PlayWelcomeMessage()
        {
            try
            {
                _synth.Speak("Hello! Welcome to the Cybersecurity Awareness Bot. I'm here to help you stay safe online.");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Bot: Voice greeting failed. Error: " + ex.Message);
                Console.ResetColor();
            }
        }

        public void PlayVoiceMessage(string message)
        {
            try
            {
                _synth.Speak(message);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Bot: Voice playback failed. Error: " + ex.Message);
                Console.ResetColor();
            }
        }

        public void Dispose()
        {
            _synth.Dispose();
        }
    }
}
