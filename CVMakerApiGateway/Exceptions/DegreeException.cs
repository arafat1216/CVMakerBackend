namespace CVMakerApiGateway.Exceptions
{
    public class DegreeException : ApplicationException
    {
        public DegreeException(string message) : base(message)
        {

        }

        public DegreeException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
