using SecurityApp.Domain;

namespace SecurityApp.Repository
{
    public interface ISecurityRepository
    {
        List<Security> GetAll();
        bool Insert(Security security);
    }
}
