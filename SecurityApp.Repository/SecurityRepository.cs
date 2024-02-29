using SecurityApp.Domain;

namespace SecurityApp.Repository
{
    public class SecurityRepository : ISecurityRepository
    {
        public List<Security> GetAll()
        {
            return new List<Security> { new Security { Isin = "ABC123" }, new Security { Isin = "DEF456" } };
        }

        public bool Insert(Security security)
        {
            return true;
        }
    }
}