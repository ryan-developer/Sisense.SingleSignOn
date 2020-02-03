namespace Sisense.SingleSignOn
{
    public class SisenseJwtRequest
    {
        public string EmailAddress { get; set; }

        public string ReturnUrl { get; set; }

        public string ReturnToUrl { get; set; }

        public string SharedSecret { get; set; }
    }
}
