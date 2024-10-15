namespace Application.MessageEncodingLookups
{
    public static class MessageEncodingLookupConsts
    {
        private const string DefaultSorting = "{0}Code asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "MessageEncodingLookup." : string.Empty);
        }

    }
}