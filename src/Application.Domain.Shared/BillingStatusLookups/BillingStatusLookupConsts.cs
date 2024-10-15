namespace Application.BillingStatusLookups
{
    public static class BillingStatusLookupConsts
    {
        private const string DefaultSorting = "{0}Code asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "BillingStatusLookup." : string.Empty);
        }

    }
}