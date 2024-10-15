namespace Application.MadfoatcomResponses
{
    public static class MadfoatcomResponseConsts
    {
        private const string DefaultSorting = "{0}BillerCode asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "MadfoatcomResponse." : string.Empty);
        }

    }
}