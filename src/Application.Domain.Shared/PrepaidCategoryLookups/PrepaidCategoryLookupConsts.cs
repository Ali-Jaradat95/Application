namespace Application.PrepaidCategoryLookups
{
    public static class PrepaidCategoryLookupConsts
    {
        private const string DefaultSorting = "{0}Code asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "PrepaidCategoryLookup." : string.Empty);
        }

    }
}