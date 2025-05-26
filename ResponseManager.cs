using System;
using System.Collections.Generic;

namespace PROG6221POE
{
    public class ResponseManager
    {
        private readonly Dictionary<string, List<string>> _responses;
        private readonly Dictionary<string, List<string>> _followUpTips;
        private readonly Random _random;
        private readonly List<string> _errorResponses;

        public ResponseManager()
        {
            _random = new Random();
            _responses = new Dictionary<string, List<string>>
            {
                { "phishing", new List<string> { "Avoid clicking unknown links.", "Phishing scams can trick users into giving personal information." }},
                { "password", new List<string> { "Use strong passwords!", "Enable two-factor authentication for extra protection." }},
                { "browsing", new List<string> { "Check for HTTPS!", "Be cautious of unknown sites." }},
                { "cyber hygiene", new List<string> { "Update your software!", "Enable automatic security updates." }}
            };

            _followUpTips = new Dictionary<string, List<string>>
            {
                { "phishing", new List<string> { "Always verify the sender before clicking links.", "Never share sensitive information over email or text." }},
                { "password", new List<string> { "Use passphrases instead of short passwords.", "Change your passwords periodically to prevent breaches." }},
                { "browsing", new List<string> { "Use a VPN for secure connections.", "Clear your browser history regularly." }},
                { "cyber hygiene", new List<string> { "Regularly back up your data.", "Be cautious about what you download and install." }}
            };

            _errorResponses = new List<string>
            {
                "I'm sorry, I didn't understand that. Could you ask in a different way?",
                "I didn't catch that. Can you please rephrase your question?",
                "Let's try that again. What would you like to know?"
            };
        }

        public string GetRandomErrorResponse()
        {
            return _errorResponses[_random.Next(_errorResponses.Count)];
        }

        public string GetResponse(string topic)
        {
            if (_responses.TryGetValue(topic, out var responses))
            {
                return responses[_random.Next(responses.Count)];
            }
            return "I don't have information on that topic.";
        }

        public Dictionary<string, List<string>> FollowUpTips => _followUpTips;
    }
}
