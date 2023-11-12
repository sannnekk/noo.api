namespace noo.api.Core.DataAbstraction;

public struct Pagination
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? Sort { get; set; } = null;
    public bool IsDescending { get; set; } = false;

    public Pagination() { }

}