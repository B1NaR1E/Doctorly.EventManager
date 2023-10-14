namespace Doctorly.EventManager.Api.DTOs
{
    public abstract class ResponseBase<T> : ResponseBase
    {
        public T Response { get; set; }
    }

    public abstract class ResponseBase
    {
        public bool Successfull { get; set; }
        public string Message { get; set; }
    }
}
