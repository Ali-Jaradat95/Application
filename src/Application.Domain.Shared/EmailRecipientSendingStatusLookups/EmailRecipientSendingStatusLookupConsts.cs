namespace Application.EmailRecipientSendingStatusLookups
{
    public static class EmailRecipientSendingStatusLookupConsts
    {
        private const string DefaultSorting = "{0}Code asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "EmailRecipientSendingStatusLookup." : string.Empty);
        }

    }
}