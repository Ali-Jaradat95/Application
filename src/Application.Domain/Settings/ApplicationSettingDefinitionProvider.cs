using Volo.Abp.Settings;

namespace Application.Settings;

public class ApplicationSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(ApplicationSettings.MySetting1));
    }
}
