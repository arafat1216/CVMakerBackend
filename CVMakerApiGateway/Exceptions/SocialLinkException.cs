namespace CVMakerApiGateway.Exceptions
{
    public class SocialLinkException : ApplicationException
    {
        public SocialLinkException(string message) : base(message)
        {

        }

        public SocialLinkException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
