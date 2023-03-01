namespace CVMakerApiGateway.Exceptions
{
    public class ProjectException : ApplicationException
    {
        public ProjectException(string message) : base(message)
        {

        }

        public ProjectException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
