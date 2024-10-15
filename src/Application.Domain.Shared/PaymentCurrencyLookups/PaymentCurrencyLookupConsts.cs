namespace Application.PaymentCurrencyLookups
{
    public static class PaymentCurrencyLookupConsts
    {
        private const string DefaultSorting = "{0}Code asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "PaymentCurrencyLookup." : string.Empty);
        }

    }
}