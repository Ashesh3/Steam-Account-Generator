namespace SampleModule.Models
{
    public class MailConfig
    {
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public string Host { get; set; } = "";
        public int Port { get; set; } = 995;
        public bool UseSsh { get; set; } = true;
    }
}
