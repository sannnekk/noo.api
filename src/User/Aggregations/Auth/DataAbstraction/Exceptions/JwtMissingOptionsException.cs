namespace noo.api.Auth.DataAbstraction.Exceptions
{
    public class JwtMissingOptionsException : Exception
    {
        public JwtMissingOptionsException(string message) : base(message) { }
    }
}
