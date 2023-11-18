namespace noo.api.Auth.Exceptions
{
    public class JwtMissingOptionsException : Exception
    {
        public JwtMissingOptionsException(string message) : base(message) { }        
    }
}
