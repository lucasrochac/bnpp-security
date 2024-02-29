using SecurityApp.Domain;

namespace SecurityAPP.Service
{
    public interface ISecurityService
    {
        List<Security> GetList();
        List<Security> ProcessSecurityIsins (List<string> isins);
    }
}
