namespace Application.MadfoatcomRequests
{
    public static class MadfoatcomRequestConsts
    {
        private const string DefaultSorting = "{0}BillerCode asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "MadfoatcomRequest." : string.Empty);
        }

    }
}