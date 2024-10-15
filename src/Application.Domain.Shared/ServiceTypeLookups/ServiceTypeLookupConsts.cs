namespace Application.ServiceTypeLookups
{
    public static class ServiceTypeLookupConsts
    {
        private const string DefaultSorting = "{0}Code asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "ServiceTypeLookup." : string.Empty);
        }

    }
}