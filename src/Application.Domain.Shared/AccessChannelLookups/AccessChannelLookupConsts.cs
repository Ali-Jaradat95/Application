namespace Application.AccessChannelLookups
{
    public static class AccessChannelLookupConsts
    {
        private const string DefaultSorting = "{0}Code asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "AccessChannelLookup." : string.Empty);
        }

    }
}