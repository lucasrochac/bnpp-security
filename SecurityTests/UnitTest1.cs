using Moq;
using SecurityApp.Repository;
using SecurityAPP.Service;
using Microsoft.Extensions.Logging;

namespace SecurityTests
{
    public class Tests
    {
        private ISecurityService _service;
        private ISecurityRepository _repository;
        private ILogger _logger;


        public Tests()
        {
            var repository = new Mock<ISecurityRepository>();
            var logger = new Mock<ILogger>();

            _service = new SecurityService(repository.Object, logger.Object);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void BasicSuccefullTest()
        {
            var list = new List<string>() { "123456789ABC", "987654321CBA" };
            var sucess = _service.ProcessSecurityIsins(list);
            
            Assert.That(list.Count == sucess.Count);
        }

        [Test]
        public void InvalidIsinErrorTest()
        {
            var list = new List<string>() { "123456789ABC", "98765" };
            Assert.Throws<InvalidOperationException>(() => { _service.ProcessSecurityIsins(list); });
        }
    }
}