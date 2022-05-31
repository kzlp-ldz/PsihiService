using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Core;

namespace TestPsihi
{
    [TestClass]
    public class PsihiTest
    {
        [TestMethod]
        public void GetUserTest()
        {
            var user1 = new User()
            {
                id_user = 1,
                login = "admin",
                password = "admin",
            };
            var user2 = DataManag.GetUser(1);
            Assert.AreEqual(user1.id_user, user2.id_user);
            Assert.AreEqual(user1.login, user2.login);
            Assert.AreEqual(user1.password, user2.password);
        }
        [TestMethod]
        public void AddProblemTest()
        {
            var problem1 = new Problems()
            {
                name = "Эгоизм",
            };
            DataManag.AddProblem(problem1);
            var problem2 = DataManag.GetProblem(20);
            Assert.AreEqual(problem1.name, problem2.name);
        }
        [TestMethod]
        public void UpdateProblemTest()
        {
            var problem1 = new Problems()
            {
                name = "Лицемерие",
            };
            DataManag.UpdateProblems(20, problem1);
            var problem2 = DataManag.GetProblem(20);
            Assert.AreEqual(problem1.name, problem2.name);
        }
        [TestMethod]
        public void DeleteProblemTest()
        {
            DataManag.RemoveProblem(20);
            var problem = DataManag.GetProblem(20);
            Assert.AreEqual(problem.IsDeleted, true);
        }
    }
}
