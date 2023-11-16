namespace noo.api.Core.DataAbstraction;

public struct Pagination
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? Sort { get; set; } = null;
    public bool IsDescending { get; set; } = false;

    public Pagination() { }

    public Pagination(int page, int pageSize, string? sort, bool isDescending = false)
    {
        Page = page;
        PageSize = pageSize;
        Sort = sort;
        IsDescending = isDescending;
    }

    public IQueryable<Model> Apply<Model>(IQueryable<Model> query)
    {
        var offset = (Page - 1) * PageSize;

        if (Sort != null)
        {
            var property = typeof(Model).GetProperty(Sort);
            if (property != null)
            {
                query = IsDescending
                    ? query.OrderByDescending(model => property.GetValue(model))
                    : query.OrderBy(model => property.GetValue(model));
            }
        }

        return query.Skip(offset).Take(PageSize);
    }
}