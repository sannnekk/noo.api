namespace api.Repositories
{
    public class Criteria : ICriteria
    {
        public int Offset { get; set; }
        public int Limit { get; set; }
    }
}