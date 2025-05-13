using DynaReport.Utilities;
using Microsoft.AspNetCore.Mvc;
using static DynaReport.Enumerations.TypeEnum;

namespace DynaReport.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{

    #region Helpers
    [ApiExplorerSettings(IgnoreApi = true)]
    public LangEnum CurrentLang()
    {
        return CoreUtility.CurrentLang()!;
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    protected string CurrentUser()
    {
        return User.GetUserId();
    }
    #endregion
}
