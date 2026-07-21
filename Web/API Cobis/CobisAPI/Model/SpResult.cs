namespace CobisAPI.Model
{
    public class SpResult
    {
        public int resultSetListSize { get; set; }
        public int returnCode { get; set; }
        public int errorListSize { get; set; }
        public List<string> resultSets { get; set; }
        public bool dataMessageLoaded { get; set; }
        public List<Message> messages { get; set; }

        public List<string> @params { get; set; }
        public List<string> errors { get; set; }
        public int messageListSize { get; set; }

    }

    public class Message
    {
        public string messageText { get; set; }
        public int messageNumber { get; set; }
        public int type { get; set; }
    }
}
