namespace Common.BaseException
{
    public static class ErrorMessageConstants
    {
        public const string ItemNotFound = "Following item not found : {0}";
        public const string BasketNotFound = "Following basket not found : {0}";
        public const string OutOfStock = "There is only {0} items";
        public const string CanNotAddItem = "Can not add item to basket";
        public const string CanNotUpdateItem = "Can not update item to basket";
        public const string CanNotRemoveItem = "Can not update remove to basket";
        public const string InvalidQuantity = "Quantity should be greater than 0";
    }
}