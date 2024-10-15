namespace Application.MethodTypeLookups
{
    public static class MethodTypeLookupConsts
    {
        private const string DefaultSorting = "{0}Code asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "MethodTypeLookup." : string.Empty);
        }

    }
}