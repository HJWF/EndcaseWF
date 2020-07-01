using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BackEnd.Controllers;
using BackEnd.DAL;
using Moq;
using System.Linq;
using BackEnd.Models;
using BackEnd.Test.Builders;

namespace BackEnd.Test
{
    [TestClass]
    public class CursusControllerTest
    {
        private CursusController _sut;
        private Mock<ICursusRepository> _cursusInstantieRepositoryMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _cursusInstantieRepositoryMock = new Mock<ICursusRepository>();
            _sut = new CursusController(_cursusInstantieRepositoryMock.Object);
        }

        [TestMethod]
        public void GetCursussenInstantiesShouldReturnAQueryableOfCursusInstanties()
        {
            var cursusInstantiesQueryable = new List<CursusInstantie>
            {
                CursusInstantieBuilder.New().WithStartDate(new DateTime(2020,02,02)).Build(),
                CursusInstantieBuilder.New().WithStartDate(new DateTime(2020,03,03)).Build(),
                CursusInstantieBuilder.New().WithStartDate(new DateTime(2020,04,04)).Build(),
                CursusInstantieBuilder.New().WithStartDate(new DateTime(2020,04,04)).Build(),
                CursusInstantieBuilder.New().WithStartDate(new DateTime(2020,04,04)).Build()
            };
            _cursusInstantieRepositoryMock.Setup(x => x.GetCursusInstanties()).Returns(cursusInstantiesQueryable);

            var cursusInstanties = _sut.GetCursussenInstanties();

            Assert.IsNotNull(cursusInstanties);
            Assert.IsTrue(cursusInstanties.Count() == 5);
        }

        [TestMethod]
        public void PostCursusInstantieShouldAddCursusInstanties()
        {
            // Niet te testen omdat ik gebruik maak van de HttpContext.Current:
            // Web API has been built to support unit testing by allowing you to mock various context objects. However, by using HttpContext.Current you are using "old-style" System.Web code 
            // that uses the HttpContext class which makes it impossible to unit test your code.
        }
    }
}
