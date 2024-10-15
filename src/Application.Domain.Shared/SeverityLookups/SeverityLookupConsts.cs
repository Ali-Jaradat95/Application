namespace Application.SeverityLookups
{
    public static class SeverityLookupConsts
    {
        private const string DefaultSorting = "{0}Code asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "SeverityLookup." : string.Empty);
        }

    }
}