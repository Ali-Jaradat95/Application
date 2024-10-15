namespace Application.CharSetLookups
{
    public static class CharSetLookupConsts
    {
        private const string DefaultSorting = "{0}Code asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "CharSetLookup." : string.Empty);
        }

    }
}