namespace Anbima.Application.Services
{
    public class ResultService
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public ICollection<ErrorValidation> Errors { get; set; }

        public static ResultService Fail(string message) => new ResultService { IsSuccess = false, Message = message };
        public static ResultService<T> Fail<T>(string message) => new ResultService<T> { IsSuccess = false, Message = message };

        public static ResultService Ok(string message) => new ResultService { IsSuccess = false, Message = message };
        public static ResultService<T> Ok<T>(T data) => new ResultService<T> { IsSuccess = false, Data = data };

    }
    public class ResultService<T> : ResultService
    {
        public T Data { get; set; }
    }
}
