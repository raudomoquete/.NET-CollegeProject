namespace College.Application.Common
{
    public class Result<T>
    {
        private Result(T value, bool isSuccess, Error error) 
        {
            if (isSuccess && error != Error.None ||
                !isSuccess && error == Error.None) 
            { 
                throw new ArgumentException("Invalid error Configuration", nameof(error));
            }

            Value = value;
            IsSuccess = isSuccess;
            Error = error;
        }

        public T Value { get; }

        /// <summary>
        /// Indica si la operación fue exitosa.
        /// </summary>
        public bool IsSuccess { get; }

        public bool IsFailure => !IsSuccess;

        public Error Error { get; }

        // Crear un resultado exitoso
        public static Result<T> Success(T value) => new(value, true, Error.None);

        // Crear un resultado fallido
        public static Result<T> Failure(Error error) => new(default(T), false, error);
    }
}
