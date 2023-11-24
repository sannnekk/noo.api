namespace noo.api.User.DataAbstraction.Exceptions
{
    public class SecuritySaltMissingException : Exception
    {
        public SecuritySaltMissingException(string message) : base(message) { }      
    }
}
