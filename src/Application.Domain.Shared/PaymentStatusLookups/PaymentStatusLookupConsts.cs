namespace Application.PaymentStatusLookups
{
    public static class PaymentStatusLookupConsts
    {
        private const string DefaultSorting = "{0}Code asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "PaymentStatusLookup." : string.Empty);
        }

    }
}