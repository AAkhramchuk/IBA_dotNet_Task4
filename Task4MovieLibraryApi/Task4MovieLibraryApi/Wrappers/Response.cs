namespace Task4MovieLibraryApi.Wrappers
{
    public class Response<T>
    {
        public T? Data { get; set; }
        public bool? Succeeded { get; set; }
        public string[]? Errors { get; set; }
        public string? Message { get; set; }
        public Response()
        {
            Succeeded = true;
            Message = string.Empty;
            Errors = null;
            Data = default;
        }
        public Response(T data)
        {
            Succeeded = true;
            Message = string.Empty;
            Errors = null;
            Data = data;
        }
    }
}
