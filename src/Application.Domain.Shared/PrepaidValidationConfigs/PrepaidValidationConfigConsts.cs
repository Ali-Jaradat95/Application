namespace Application.PrepaidValidationConfigs
{
    public static class PrepaidValidationConfigConsts
    {
        private const string DefaultSorting = "{0}ServiceType asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "PrepaidValidationConfig." : string.Empty);
        }

    }
}