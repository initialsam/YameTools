using System;
using System.Collections.Generic;
using System.Text;

namespace YameTools
{
    public abstract class GenericResultDto<T>
    {
        protected bool _isSuccess;
        public bool IsSuccess => _isSuccess;

        public bool IsFail => _isSuccess == false;

        protected string _errorMessage;
        public string ErrorMessage => _errorMessage;

        protected T _value;
        public T Result => _value;
    }

    public sealed class SuccessResultDto<T> : GenericResultDto<T>
    {
        public SuccessResultDto(T value = default, string errorMessage = default)
        {
            _isSuccess = true;
            _value = value;
            _errorMessage = errorMessage;
        }
    }

    public sealed class FailResultDto<T> : GenericResultDto<T>
    {
        public FailResultDto(string errorMessage = default, T value = default)
        {
            _isSuccess = false;
            _errorMessage = errorMessage;
            _value = value;
        }
    }
}
