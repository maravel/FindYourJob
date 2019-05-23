using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelDonnees;
using Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using ModelDonnees.Entity;

namespace TestUnitaire
{
    [TestClass]
    public class ServiceTest
    {
        [TestMethod]
        public async Task TestCreationEmployeAsync()
        {
            Service service = new Service();

            // Arrange
            string nom = "Employe";
            Employe employetest = new Employe
            {
                Nom = nom
            };

            List<Employe> employes = await service.GetEmployes();
            int nb = employes.Count;

            // Act
            Result res = await service.AddUpdateEmploye(employetest, true);
            employes = await service.GetEmployes();

            // Assert
            Assert.IsFalse(res.HasError());
            Assert.AreEqual(nb, employes.Count - 1);

        }
    }
}
