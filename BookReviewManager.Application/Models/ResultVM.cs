namespace BookReviewManager.Application.Models
{
    public class ResultVM
    {
        public ResultVM(bool isSuccess = true, string message = "")
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public bool IsSuccess { get; private set; }
        public string Message { get; private set; }
        public static ResultVM Error(string message)
          => new(false, message);
        public static ResultVM Success()
         => new();
    }
    public class ResultVM<T> : ResultVM
    {
        public ResultVM(T? data, bool isSuccess = true, string message = "") : base(isSuccess, message)
        {
            Data = data;

        }
        public T? Data { get; private set; }

        public static ResultVM<T> Success(T data)
            => new(data);
        public static ResultVM<T> Error(string message)
            => new(default, false, message);
    }
}
