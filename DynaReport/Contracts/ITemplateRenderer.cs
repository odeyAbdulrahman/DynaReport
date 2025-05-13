namespace DynaReport.Contracts
{
    public interface ITemplateRenderer
    {
        Task<string> RenderViewToStringAsync<TModel>(string viewPath, TModel model);
    }
}
