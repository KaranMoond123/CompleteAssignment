namespace CompleteAssignment.Dtos;

public class PageResult<T>
{
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
    public int TotalRecords { get; set; }
    public List<T> Data { get; set; }
}
