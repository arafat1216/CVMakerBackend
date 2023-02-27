namespace CVMakerApiGateway.Exceptions
{
    public class SkillException : ApplicationException
    {
        public SkillException(string message) : base(message)
        {

        }

        public SkillException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
