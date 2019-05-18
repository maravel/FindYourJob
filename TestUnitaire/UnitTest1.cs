using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelDonnees;
using Services;
using System.Threading.Tasks;

namespace TestUnitaire
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestCreationEmployeAsync()
        {
            Service service = new Service();

            await service.GetEmployes();
            
        }
    }
}
