namespace Application.PaymentMethodLookups
{
    public static class PaymentMethodLookupConsts
    {
        private const string DefaultSorting = "{0}Code asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "PaymentMethodLookup." : string.Empty);
        }

    }
}