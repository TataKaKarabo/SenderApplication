using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Internal;
using SenderApplication;

namespace SenderAppTestProject
{
    [TestClass]
    public class SenderApplicationTests
    {
        [TestMethod]
        public void SenderMessageReturnTrue()
        {
            var factory = new FactoryConfig();
            bool results = factory.SendMessage("Ziggy");
            Assert.IsTrue(results, "Message Sent Succeffuly");
        }
        [TestMethod]
        public void SenderMessageReturnFalse()
        {
            var factory = new FactoryConfig();
            bool results = factory.SendMessage(string.Empty);
            Assert.IsFalse(results, "Message Cannot be empty");
        }
    }
}
