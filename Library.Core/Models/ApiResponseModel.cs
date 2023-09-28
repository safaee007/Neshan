namespace Library.Core.Models
{
    public class ResponseModel<T>
    {
        public T Items { get; set; }
        public long Count { get; set; }
    }

    public class ResponseModel<T, T2>
    {
        public T Items { get; set; }
        public T2 Parents { get; set; }
        public long Count { get; set; }
    }
}
