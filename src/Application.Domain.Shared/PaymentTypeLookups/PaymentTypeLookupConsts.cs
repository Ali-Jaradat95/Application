namespace Application.PaymentTypeLookups
{
    public static class PaymentTypeLookupConsts
    {
        private const string DefaultSorting = "{0}Code asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "PaymentTypeLookup." : string.Empty);
        }

    }
}