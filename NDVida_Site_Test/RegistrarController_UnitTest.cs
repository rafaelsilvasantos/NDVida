using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDVida_Site.Controllers;

namespace NDVida_Site_Test
{
    [TestClass]
    public class RegistrarController_UnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            RegistrarController c = new RegistrarController();

            c.Index(new NDVida_Site.Models.RegistrarViewModel());
        }
    }
}
