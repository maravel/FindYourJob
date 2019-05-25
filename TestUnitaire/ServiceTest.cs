using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelDonnees;
using Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using ModelDonnees.Entity;
using System.Linq;

namespace TestUnitaire
{
    [TestClass]
    public class ServiceTest
    {
        #region Employés

        [TestMethod]
        public async Task TestAddEmployeAsync()
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

        #endregion

        #region Offres

        [TestMethod]
        public async Task TestAddOffreAsync()
        {
            Service service = new Service();

            // Arrange
            string nom = "Offre";
            Offre offreTest = new Offre
            {
                Intitule = nom
            };

            List<Offre> offres = await service.GetOffres();
            int nb = offres.Count;

            // Act
            Result res = await service.AddUpdateOffre(offreTest, true);
            offres = await service.GetOffres();

            // Assert
            Assert.IsFalse(res.HasError());
            Assert.AreEqual(nb, offres.Count - 1);

        }

        #endregion

        #region Formations

        [TestMethod]
        public async Task TestAddFormationAsync()
        {
            Service service = new Service();

            // Arrange
            string intitule = "Formation";
            Formation formationTest = new Formation
            {
                Intitule = intitule
            };

            List<Formation> formations = await service.GetFormations();
            int nb = formations.Count;

            // Act
            Result res = await service.AddUpdateFormation(formationTest, true);
            formations = await service.GetFormations();

            // Assert
            Assert.IsFalse(res.HasError());
            Assert.AreEqual(nb, formations.Count - 1);

        }

        #endregion

        #region Postulations

        #endregion

        #region Statuts

        #endregion

        #region Expériences

        [TestMethod]
        public async Task TestAddExperienceAsync()
        {
            Service service = new Service();

            // Arrange
            string nomEmploye = "Mathieu";
            string intitule = "exp 2 ans";

            Employe e = new Employe
            {
                Nom = nomEmploye
            };

            await service.AddUpdateEmploye(e, true);
            List<Employe> es = await service.GetEmployes();
            int id = es.Where(employe => employe.Nom == nomEmploye).FirstOrDefault().Id;

            Experience exp = new Experience
            {
                Intitule = intitule,
                EmployeId = id
            };

            // Act
            Result res = await service.AddUpdateExperience(exp, true);
            es = await service.GetEmployes();
            List<Experience> exps = await service.GetExperiences();
            int nb = exps.Where(ex => ex.Intitule == intitule).Count();
            
            // Assert
            Assert.IsTrue(nb >= 1);
            Assert.IsFalse(res.HasError());
        }

        #endregion

    }
}
