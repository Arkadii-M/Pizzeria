namespace API.Models
{
    public class Pagination<T> where T : class  //general pagination
    {
        public Pagination(int pageIndex, int pageSize, int count, IReadOnlyList<T> data)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Count = count;
            Data = data;
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; } //implement after the filters of types (pizza, drinks, desserts...)
        public IReadOnlyList<T> Data { get; set; } //Data to return

    }
}
