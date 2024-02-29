using Microsoft.Extensions.Logging;
using SecurityApp.Domain;
using SecurityApp.Repository;

namespace SecurityAPP.Service
{
    public class SecurityService : ISecurityService
    {
        private static ISecurityRepository _repository;
        private static ILogger _logger;

        public SecurityService(
            ISecurityRepository repository,
            ILogger logger) 
        {
            _logger = logger;
            _repository = repository;
        }

        public List<Security> GetList()
        {
            return _repository.GetAll();
        }  

        public List<Security> ProcessSecurityIsins(List<string> isins)
        {
            var sucess = new List<Security>();

            foreach(var i in isins) 
            {
                var price = GetSecurityPrice(i);

                Security security = new Security()
                {
                    Isin = i,
                    Price = price
                };

                var success  = CreateSecurity(security);
                
                if (!success)
                {
                    _logger.LogError(string.Format("Error processing Isin: {0}",i));
                }
                else
                {
                    sucess.Add(security);
                }
            }

            return sucess;
        }

        private bool CreateSecurity(Security security)
        {
            if (security.IsValid())
            {
                return _repository.Insert(security);
            }
            else 
            {
                throw new InvalidOperationException(string.Format("Invalid Isin: {0}", security.Isin));
            }
        }

        private decimal GetSecurityPrice(string isin) 
        {
            var random = new Random();
            return (decimal)random.NextDouble();
        }

    }
}