namespace Application.PaymentSourceLookups
{
    public static class PaymentSourceLookupConsts
    {
        private const string DefaultSorting = "{0}Code asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "PaymentSourceLookup." : string.Empty);
        }

    }
}