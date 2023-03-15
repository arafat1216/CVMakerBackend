namespace CVMakerApiGateway.Exceptions
{
    public class WorkExperienceException : ApplicationException
    {
        public WorkExperienceException(string message) : base(message)
        {

        }
        public WorkExperienceException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
