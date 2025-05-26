namespace PROG6221POE
{
    public class CyberBotBot
    {
        private readonly string _userName;
        private readonly Dictionary<string, int> _mentionedTopics; // To store topics and their mention counts
        private string _lastTopic = null;
        private bool _waitingForFollowUp = false;

        public CyberBotBot(string userName)
        {
            _userName = userName;
            _mentionedTopics = new Dictionary<string, int>(); // Initialize the dictionary
        }

        public void Respond(string input, ResponseManager responseManager)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n────────────────────────────────────────────");
            Console.ForegroundColor = ConsoleColor.Blue;

            // Check for follow-up responses
            if (_waitingForFollowUp)
            {
                if (input.Equals("yes", StringComparison.OrdinalIgnoreCase))
                {
                    ProvideFollowUpTips(responseManager);
                    _waitingForFollowUp = false; // Reset waiting status
                    return;
                }
                else if (input.Equals("no", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Bot: Alright! If you have any other questions, feel free to ask.");
                    _waitingForFollowUp = false; // Reset waiting status
                    return;
                }
            }

            // Analyze sentiment
            string sentimentResponse = AnalyzeSentiment(input);
            if (sentimentResponse != null)
            {
                Console.WriteLine(sentimentResponse);
            }
            else
            {
                // Get topic from input
                string topic = GetTopicFromInput(input);
                if (topic != null)
                {
                    _lastTopic = topic;

                    // Track topic mention count
                    if (_mentionedTopics.ContainsKey(topic))
                    {
                        _mentionedTopics[topic]++; // Increment mention count

                        if (_mentionedTopics[topic] == 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"Bot: I noticed you've mentioned '{topic}' a few times. It seems important to you!");
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        _mentionedTopics[topic] = 1; // Initialize mention count
                    }

                    Console.WriteLine($"Bot: {responseManager.GetResponse(topic)}");
                    Console.WriteLine($"Bot: Would you like more details about {topic}? (yes/no)");
                    _waitingForFollowUp = true;
                }
                else
                {
                    Console.WriteLine(responseManager.GetRandomErrorResponse());
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("────────────────────────────────────────────");
            Console.ResetColor();
        }

        private void ProvideFollowUpTips(ResponseManager responseManager)
        {
            if (_lastTopic != null && responseManager.FollowUpTips.TryGetValue(_lastTopic, out var tips))
            {
                Console.WriteLine("Bot: Here are some additional tips:");
                foreach (var tip in tips)
                {
                    Console.WriteLine($"- {tip}");
                }
            }
            else
            {
                Console.WriteLine("Bot: I don't have any more tips on that topic.");
            }

            // Memory recall for topics mentioned
            if (_mentionedTopics.Count > 0)
            {
                Console.WriteLine($"Bot: I see you've mentioned {FormatMentionedTopics()} a few times. Would you like more tips on any of these? (yes/no)");
            }
        }

        private string FormatMentionedTopics()
        {
            List<string> topics = new List<string>();
            foreach (var topic in _mentionedTopics)
            {
                topics.Add($"{topic.Key} ({topic.Value})");
            }
            return string.Join(", ", topics);
        }

        private string GetTopicFromInput(string input)
        {
            var keywords = new Dictionary<string, string[]>
            {
                { "phishing", new[] { "phishing", "scam", "spoofing", "fraud", "fake email" } },
                { "password", new[] { "password", "safe password", "credential security", "login safety", "strong password" } },
                { "browsing", new[] { "browsing", "safe browsing", "online surfing", "malware prevention", "secure browsing" } },
                { "cyber hygiene", new[] { "cyber hygiene", "security habits", "digital safety", "best practices", "computer security" } }
            };

            foreach (var pair in keywords)
            {
                foreach (var keyword in pair.Value)
                {
                    if (input.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                        return pair.Key;
                }
            }

            return null;
        }

        private string AnalyzeSentiment(string input)
        {
            if (input.Contains("worried", StringComparison.OrdinalIgnoreCase) ||
                input.Contains("worries", StringComparison.OrdinalIgnoreCase) ||
                input.Contains("nervous", StringComparison.OrdinalIgnoreCase) ||
                input.Contains("anxious", StringComparison.OrdinalIgnoreCase))
            {
                return "Bot: I understand that cybersecurity can feel overwhelming. Let's go through some safe browsing tips.";
            }
            if (input.Contains("confused", StringComparison.OrdinalIgnoreCase) ||
                input.Contains("annoyed", StringComparison.OrdinalIgnoreCase) ||
                input.Contains("frustrated", StringComparison.OrdinalIgnoreCase) ||
                input.Contains("stressed", StringComparison.OrdinalIgnoreCase))
            {
                return "Bot: I see you're frustrated. Let me simplify things for you.";
            }
            if (input.Contains("tell me more", StringComparison.OrdinalIgnoreCase) ||
                input.Contains("explain", StringComparison.OrdinalIgnoreCase) ||
                input.Contains("curious", StringComparison.OrdinalIgnoreCase) ||
                input.Contains("interested", StringComparison.OrdinalIgnoreCase))
            {
                return "Bot: Great curiosity! Let's explore deeper cybersecurity strategies.";
            }
            if (input.Contains("urgent", StringComparison.OrdinalIgnoreCase) ||
                input.Contains("scared", StringComparison.OrdinalIgnoreCase) ||
                input.Contains("panic", StringComparison.OrdinalIgnoreCase) ||
                input.Contains("fear", StringComparison.OrdinalIgnoreCase))
            {
                return "Bot: This seems critical! I'll give you the best security tips available.";
            }
            if (input.Contains("cool", StringComparison.OrdinalIgnoreCase) ||
                input.Contains("awesome", StringComparison.OrdinalIgnoreCase) ||
                input.Contains("exciting", StringComparison.OrdinalIgnoreCase) ||
                input.Contains("amazing", StringComparison.OrdinalIgnoreCase))
            {
                return "Bot: Cybersecurity is fascinating! Let's explore it together.";
            }

            return null;
        }
    }
}
