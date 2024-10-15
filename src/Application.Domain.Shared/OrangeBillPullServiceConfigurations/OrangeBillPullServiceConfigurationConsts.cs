namespace Application.OrangeBillPullServiceConfigurations
{
    public static class OrangeBillPullServiceConfigurationConsts
    {
        private const string DefaultSorting = "{0}ServiceTypeId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "OrangeBillPullServiceConfiguration." : string.Empty);
        }

    }
}