using System.ComponentModel;

namespace Common.BaseException
{
    public enum ErrorCode
    {
        InvalidOperation = 10,
        ItemNotFound = 20,
        BasketNotFound = 30,
        OutOfStock = 40,

        [Description("UnhandledError")] UnhandledError = 500,
    }
}