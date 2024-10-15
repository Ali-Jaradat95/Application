namespace Application.BillTypeLookups
{
    public static class BillTypeLookupConsts
    {
        private const string DefaultSorting = "{0}Code asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "BillTypeLookup." : string.Empty);
        }

    }
}