namespace CVMakerApiGateway.Exceptions
{
    public class ProfileException : ApplicationException
    {
        public ProfileException(string message) : base(message)
        {

        }

        public ProfileException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
