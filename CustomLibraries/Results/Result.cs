namespace CustomLibraries.Results
{
    public class Result<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
    }
}
