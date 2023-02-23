namespace CVMakerApiGateway.Exceptions
{
    public class SummaryException : ApplicationException
    {
        public SummaryException(string message) : base(message)
        {

        }

        public SummaryException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
