namespace EcommerceLambdaProject;
public interface IDriver
{
    public string Url { get; }
    public void Start(BrowserType browser);
    public void Refresh();
    public void Quit();
    public void GoToUrl(string url);
    public IComponent FindComponent(By locator);
    public IComponent WaitAndFindElementJS(By locator);
    public List<IComponent> FindComponents(By locator);
    public bool ComponentExists(IComponent component);
    public void ExecuteScript(string script, params object[] args);
    public void DeleteAllCookies();
    public void WaitForAjax();

}
