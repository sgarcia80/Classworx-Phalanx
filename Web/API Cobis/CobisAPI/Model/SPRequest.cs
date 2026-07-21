namespace CobisAPI.Model
{
    public class SpRequest
    {
        public string SpName { get; set; }
        public List<SpParam> @params { get; set; }
    }

    public class SpParam
    {
        public string name { get; set; }
        public int dataType { get; set; }
        public string value { get; set; }
        public int ioType { get; set; }
    }
}
