using System.Security.Claims;
using static DynaReport.Enumerations.TypeEnum;

namespace DynaReport.Utilities;
public static class CoreUtility
{
    const string defaultClientProfileVal = "";
    const string defaultVal = "";
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="claimsPrincipal"></param>
    /// <returns></returns>
    public static string GetUserId(this ClaimsPrincipal? claimsPrincipal)
    {
        if (claimsPrincipal == null || !claimsPrincipal.Claims.Any()) return defaultVal;
        var value = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier);
        return value != null ? value.Value : defaultVal;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="hasValue"></param>
    /// <param name="values"></param>
    /// <returns></returns>
    public static LangEnum CurrentLang()
    {
        if (HttpContextAccessorUtility.Current()?.Request.Headers.ContainsKey("X-Lang-Header") ?? false)
        {
            var values = HttpContextAccessorUtility.Current()?.Request.Headers["X-Lang-Header"] ?? string.Empty;
            if (values != "")
                return (LangEnum)int.Parse(values!);
        }
        return LangEnum.Ar;
    }
    public static T GetSettings<T>(this IConfiguration configuration, string className)
    {
        var getSection = configuration.GetSection(className);
        return getSection.Get<T>()!;
    }
}
