namespace Application.ThresholdLookups
{
    public static class ThresholdLookupConsts
    {
        private const string DefaultSorting = "{0}Code asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "ThresholdLookup." : string.Empty);
        }

    }
}