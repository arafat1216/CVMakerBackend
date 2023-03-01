namespace CVMakerApiGateway.Exceptions
{
    public class CourseException : ApplicationException
    {
        public CourseException(string message) : base(message)
        {

        }

        public CourseException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
