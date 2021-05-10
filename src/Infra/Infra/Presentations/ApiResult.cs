using Domain.Validations.Notifications;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Data.Presentations
{
    public static class ApiResult
    {
        public static Result<object> Parse(Result<object> commandResult) => Result<object>.Parse(commandResult);
        public static Result<object> Ok() => Result<object>.Ok();
        public static Result<object> Ok<T>(T data) => Result<object>.Ok(data);
        public static Result<object> Fail(string errorMessage) => Result<object>.Fail(errorMessage);
        public static Result<object> Fail(IEnumerable<string> errorMessages) => Result<object>.Fail(errorMessages);
        public static Result<object> Fail(IEnumerable<Notification> errorMessages) => Result<object>.Fail(errorMessages);
        public static Result<object> Fail<T>(T data, string errorMessage) => Result<object>.Fail(data, errorMessage);
        public static Result<object> Fail<T>(T data, IEnumerable<string> errorMessages) => Result<object>.Fail(data, errorMessages);
    }

    public class Result<T> where T : class
    {
        public IEnumerable<Notification> ErrorMessages { get; }
        public bool Sucess { get; }
        public T Data { get; }
        public bool Failure => !Sucess;

        private static readonly Result<T> OKResult = new Result<T>(true, default(T));
        
        public static Result<T> Ok()
        {
            return OKResult;
        }

        public static Result<T> Ok(T data) => new Result<T>(true, data);
        public static Result<T> Fail(T data, string errorMessage) => new Result<T>(false, data, new Notification("none", errorMessage));
        public static Result<T> Fail(T data, IEnumerable<string> errorMessages) => new Result<T>(false, data, errorMessages.Select(x => new Notification("none", x)).ToArray());
        public static Result<T> Fail(string errorMessage) => new Result<T>(false, default(T), new Notification("none", errorMessage));
        public static Result<T> Fail(IEnumerable<string> errorMessages) => new Result<T>(false, default(T), errorMessages.Select(x => new Notification("none", x)).ToArray());
        public static Result<T> Fail(IEnumerable<Notification> errorMessages) => new Result<T>(false, default(T), errorMessages.ToArray());

        public static Result<T> Parse(Result<object> commandResult) => new Result<T>(commandResult.Sucess, default(T), commandResult.ErrorMessages.ToArray());

        private Result(bool isSucess, T data, params Notification[] errorMessages)
        {
            Data = data;
            Sucess = isSucess;
            ErrorMessages = errorMessages;
        }
    }
}
