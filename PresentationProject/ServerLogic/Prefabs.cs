using System.Net;

namespace ServerLogic
{
    public class Response
    {
        public HttpStatusCode statusCode { get; set; }
        public object content { get; set; }
    }
    public class User
    {
        public string name { get; set; } = String.Empty;
        public string email { get; set; } = String.Empty;
        public DateTime birthDate { get; set; } = DateTime.Now;
    }

}
