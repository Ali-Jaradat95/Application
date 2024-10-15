namespace Application.ProcessStatusLookups
{
    public static class ProcessStatusLookupConsts
    {
        private const string DefaultSorting = "{0}Code asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "ProcessStatusLookup." : string.Empty);
        }

    }
}