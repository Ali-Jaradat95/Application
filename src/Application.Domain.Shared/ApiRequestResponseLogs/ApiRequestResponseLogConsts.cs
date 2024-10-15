namespace Application.ApiRequestResponseLogs
{
    public static class ApiRequestResponseLogConsts
    {
        private const string DefaultSorting = "{0}RequestUrl asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "ApiRequestResponseLog." : string.Empty);
        }

    }
}