using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Common.BaseException
{
    [Serializable]
    public class BasketException : Exception
    {
        public BasketException()
        {
        }

        public BasketException(ErrorCode errorCode, string message) : base(message)
        {
            ErrorContainer = new ErrorContainer(errorCode, message);
        }

        public BasketException(ErrorCode errorCode, Exception innerException) : this(errorCode, innerException.Message)
        { }

        public BasketException(ErrorCode errorCode, string message, Exception innerException) : base(message, innerException)
        {
            ErrorContainer = new ErrorContainer(errorCode, message);
        }

        protected BasketException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            ErrorContainer = info.GetValue("Error", typeof(ErrorContainer)) as ErrorContainer;
        }

        public ErrorContainer ErrorContainer { get; set; }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (null == info)
            {
                throw new ArgumentNullException(nameof(info));
            }

            info.AddValue("Error", ErrorContainer, typeof(ErrorContainer));

            base.GetObjectData(info, context);
        }
    }

    public class ErrorContainer : IEquatable<ErrorContainer>
    {
        [JsonConstructor]
        protected ErrorContainer()
        {

        }

        /// <summary>
        /// Default Error Code = UnhandledError
        /// </summary>
        /// <param name="errorMessage">Error Message</param>
        public ErrorContainer(string errorMessage) : this(ErrorCode.UnhandledError, errorMessage)
        {
        }

        public ErrorContainer(ErrorCode errorCode, string errorMessage)
        {
            Code = errorCode;
            Message = errorMessage;
        }

        public ErrorCode Code { get; set; }

        public string Message { get; set; }

        public bool Equals(ErrorContainer other)
        {
            return this.Code == other.Code && this.Message == other.Message;
        }
    }
}
