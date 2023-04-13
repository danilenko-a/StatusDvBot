namespace StatusDvBot.Models
{
    internal readonly struct Result<T>
    {
        public static Result<T> Empty = new Result<T>();

        private readonly T _value;

        public T Value => HasValue ? _value : throw new InvalidOperationException("Нельзя получить значение, когда оно отсутствует");

        public bool HasValue { get; }

        public Result(T value)
        {
            HasValue = true;
            _value = value;
        }

        public static implicit operator Result<T>(T value) => new Result<T>(value);

        public static implicit operator bool(Result<T> result) => result.HasValue;
    }

    internal static class Result
    {
        public static Result<T> Empty<T>() => Result<T>.Empty;

        public static Result<T> New<T>(T value) => new Result<T>(value);
    }
}
