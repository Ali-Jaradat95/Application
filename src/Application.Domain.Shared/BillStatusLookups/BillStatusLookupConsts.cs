namespace Application.BillStatusLookups
{
    public static class BillStatusLookupConsts
    {
        private const string DefaultSorting = "{0}Code asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "BillStatusLookup." : string.Empty);
        }

    }
}