namespace Application.OrangeBillPaymentNotificationConfigurations
{
    public static class OrangeBillPaymentNotificationConfigurationConsts
    {
        private const string DefaultSorting = "{0}ServiceTypeName asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "OrangeBillPaymentNotificationConfiguration." : string.Empty);
        }

    }
}