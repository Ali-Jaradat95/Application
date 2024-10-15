namespace Application.LanguageIsoNameLookups
{
    public static class LanguageIsoNameLookupConsts
    {
        private const string DefaultSorting = "{0}Code asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "LanguageIsoNameLookup." : string.Empty);
        }

    }
}