namespace Application.OperationTypeLookups
{
    public static class OperationTypeLookupConsts
    {
        private const string DefaultSorting = "{0}Code asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "OperationTypeLookup." : string.Empty);
        }

    }
}