using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelDonnees;
using Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using ModelDonnees.Entity;
using System.Linq;
using Dto.Dto;

namespace TestUnitaire
{
    [TestClass]
    public class ServiceTest
    {
        #region Employés

        [TestMethod]
        public async Task TestAddEmployeAsync()
        {
            IService service = new Service();

            // Arrange
            string nom = "Employe";
            Employe employetest = new Employe
            {
                Nom = nom
            };

            List<EmployeDto> employes = await service.GetEmployes();
            int nb = employes.Count;

            // Act
            Result res = await service.AddUpdateEmploye(employetest, true);
            employes = await service.GetEmployes();

            // Assert
            Assert.IsFalse(res.HasError());
            Assert.AreEqual(nb, employes.Count - 1);

        }

        [TestMethod]
        public async Task TestUpdateEmployeAsync()
        {
            IService service = new Service();

            // Arrange
            string nom = "Employe";
            string newNom = "New";
            Employe employetest = new Employe
            {
                Nom = nom
            };

            Result res = await service.AddUpdateEmploye(employetest, true);

            // Act
            employetest.Nom = newNom;
            res = await service.AddUpdateEmploye(employetest, false);
            List<EmployeDto> employes = await service.GetEmployes(employetest.Id);
            EmployeDto employe = employes.SingleOrDefault();


            // Assert
            Assert.IsFalse(res.HasError());
            Assert.AreEqual(newNom, employe.Nom);

        }

        [TestMethod]
        public async Task TestGetEmployesAsync()
        {
            IService service = new Service();

            // Arrange
            string nom = "Employe";
            Employe employetest = new Employe
            {
                Nom = nom
            };
            
            List<EmployeDto> employes = await service.GetEmployes();
            int defaultCount = employes.Count;

            await service.AddUpdateEmploye(employetest, true);

            // Act
            employes = await service.GetEmployes();

            // Assert
            Assert.AreEqual(defaultCount, employes.Count - 1);
        }

        [TestMethod]
        public async Task TestGetEmployeAsync()
        {
            IService service = new Service();

            // Arrange
            string nom = "Employe";
            Employe employetest = new Employe
            {
                Nom = nom
            };

             await service.AddUpdateEmploye(employetest, true);

            // Act
            List<EmployeDto> employes = await service.GetEmployes(employetest.Id);
            EmployeDto employe = employes.SingleOrDefault();

            // Assert
            Assert.AreEqual(employe.Nom, employetest.Nom);

        }

        [TestMethod]
        public async Task TestRemoveEmployeAsync()
        {
            IService service = new Service();

            // Arrange
            string nom = "Employe";
            Employe employetest = new Employe
            {
                Nom = nom
            };

            await service.AddUpdateEmploye(employetest, true);
            List<EmployeDto> employes = await service.GetEmployes();
            int nb = employes.Count;

            // Act
            Result res = await service.RemoveEmploye(employetest.Id);
            employes = await service.GetEmployes();

            // Assert
            Assert.IsFalse(res.HasError());
            Assert.AreEqual(nb - 1, employes.Count);

        }

        #endregion

        #region Offres

        [TestMethod]
        public async Task TestAddOffreAsync()
        {
            IService service = new Service();

            // Arrange
            string libelle = "Statut";
            string intitule = "intitule";

            Statut s = new Statut
            {
                Libelle = libelle
            };

            await service.AddUpdateStatut(s, true);
            List<StatutDto> es = await service.GetStatuts();
            int id = es.Where(statut => statut.Libelle == libelle).FirstOrDefault().Id;

            OffreDto offreTest = new OffreDto
            {
                Intitule = intitule,
                StatutId = id
            };

            // Act
            Result res = await service.AddUpdateOffre(offreTest, true);

            List<OffreDto> offres = await service.GetOffres();
            int nb = offres.Where(ex => ex.Intitule == intitule).Count();

            // Assert
            Assert.IsTrue(nb >= 1);
            Assert.IsFalse(res.HasError());
        }

        #endregion

        #region Formations

        [TestMethod]
        public async Task TestAddFormationAsync()
        {
            IService service = new Service();

            // Arrange
            string nomEmploye = "Mathieu";
            string intitule = "exp 2 ans";

            Employe e = new Employe
            {
                Nom = nomEmploye
            };

            await service.AddUpdateEmploye(e, true);
            List<EmployeDto> es = await service.GetEmployes();
            int id = es.Where(employe => employe.Nom == nomEmploye).FirstOrDefault().Id;

            FormationDto formationTest = new FormationDto
            {
                Intitule = intitule,
                EmployeId = id
            };

            // Act
            Result res = await service.AddUpdateFormation(formationTest, true);

            List<FormationDto> formations = await service.GetFormations();
            int nb = formations.Where(ex => ex.Intitule == intitule).Count();

            // Assert
            Assert.IsTrue(nb >= 1);
            Assert.IsFalse(res.HasError());
        }

        #endregion

        #region Postulations

        [TestMethod]
        public async Task TestAddPostulationAsync()
        {
            IService service = new Service();

            // Arrange
            string libelle = "StatutTest";
            int statut = 0;
            string nomEmploye = "MathieuTest";
            string intitule = "OffreTest";

            Employe e = new Employe
            {
                Nom = nomEmploye
            };

            await service.AddUpdateEmploye(e, true);
            List<EmployeDto> es = await service.GetEmployes();
            int employeId = es.Where(employe => employe.Nom == nomEmploye).FirstOrDefault().Id;

            Statut s = new Statut
            {
                Libelle = libelle
            };

            await service.AddUpdateStatut(s, true);
            List<StatutDto> ss = await service.GetStatuts();
            int statutId = ss.Where(sa => sa.Libelle == libelle).FirstOrDefault().Id;

            OffreDto o = new OffreDto
            {
                Intitule = intitule,
                StatutId = statutId
            };

            await service.AddUpdateOffre(o, true);
            List<OffreDto> os = await service.GetOffres();
            int offreId = os.Where(sa => sa.Intitule == intitule).FirstOrDefault().Id;

            PostulationDto postulationTest = new PostulationDto
            {
                StatutId = statutId,
                OffreId = offreId,
                EmployeId = employeId
            };

            // Act
            Result res = await service.AddUpdatePostulation(postulationTest, true);

            List<PostulationDto> postulations = await service.GetPostulations();
            int nb = postulations.Where(p => p.StatutId == statut).Count();

            await service.RemoveEmploye(employeId);
            await service.RemoveOffre(offreId);
            await service.RemoveStatut(statutId);

            // Assert
            Assert.IsTrue(nb >= 1);
            Assert.IsFalse(res.HasError());
        }

        #endregion

        #region Statuts

        [TestMethod]
        public async Task TestAddStatutAsync()
        {
            Service service = new Service();

            // Arrange
            string libelle = "Statut";
            Statut statutTest = new Statut
            {
                Libelle = libelle
            };

            List<StatutDto> statuts = await service.GetStatuts();
            int nb = statuts.Count;

            // Act
            Result res = await service.AddUpdateStatut(statutTest, true);
            statuts = await service.GetStatuts();

            // Assert
            Assert.IsFalse(res.HasError());
            Assert.AreEqual(nb, statuts.Count - 1);

        }

        #endregion

        #region Expériences

        [TestMethod]
        public async Task TestAddExperienceAsync()
        {
            IService service = new Service();

            // Arrange
            string nomEmploye = "Mathieu";
            string intitule = "exp 2 ans";

            Employe e = new Employe
            {
                Nom = nomEmploye
            };

            await service.AddUpdateEmploye(e, true);
            List<EmployeDto> es = await service.GetEmployes();
            int id = es.Where(employe => employe.Nom == nomEmploye).FirstOrDefault().Id;

            Experience exp = new Experience
            {
                Intitule = intitule,
                EmployeId = id
            };

            // Act
            Result res = await service.AddUpdateExperience(exp, true);

            List<ExperienceDto> exps = await service.GetExperiences();
            int nb = exps.Where(ex => ex.Intitule == intitule).Count();
            
            // Assert
            Assert.IsTrue(nb >= 1);
            Assert.IsFalse(res.HasError());
        }

        #endregion

    }
}
