namespace FlintechTest.Server.Models
{
    public class RequestParam
    {
        public string Url { get; set; }

        public string ContentType { get; set; }

        public Dictionary<string, string> CustomHeader { get; set; }
    }
}
