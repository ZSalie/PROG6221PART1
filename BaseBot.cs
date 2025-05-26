namespace PROG6221POE
{
    public abstract class BaseBot
    {
        public string UserName { get; set; }

        public abstract void GreetUser();
        public abstract void Respond(string input);
        public abstract void PlayVoiceMessage(string message);
        public abstract void DisplayLogo();
    }
}
