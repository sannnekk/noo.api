namespace api.Repositories;

public interface ICriteria
{
    public int Offset { get; set; }
    public int Limit { get; set; }
}