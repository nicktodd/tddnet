namespace SpeakingClock
{
    public interface ISubscriber
    {
        void ReceiveMessage(string message);
    }
}