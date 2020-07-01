using System;
using System.Collections.Generic;
using BackEnd.DAL;
using BackEnd.Models;
using BackEnd.Services;
using BackEnd.Test.Builders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BackEnd.Test
{
    [TestClass]
    public class CursusInstantieValidatorTest
    {
        private CursusInstantieValidator _sut;
        private Mock<ICursusRepository> _cursusRepositoryMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _cursusRepositoryMock = new Mock<ICursusRepository>();
            _sut = new CursusInstantieValidator(_cursusRepositoryMock.Object);
        }

        [TestMethod]
        public void DoesCursusInstantieExistReturnsTrueIfCursusInstanceAlreadyExist()
        {
            CursusInstantie cursusInstantieMock = CursusInstantieBuilder.New().Build();
            _cursusRepositoryMock.Setup(x => x.GetCursusInstantieById(It.IsAny<int>())).Returns(cursusInstantieMock);

            var cursusInstantie = CursusInstantieBuilder.New().Build();

            var result = _sut.DoesNotCursusInstantieExist(cursusInstantie);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DoesCursusInstantieExistReturnsFalseIfCursusInstanceDoesNotExist()
        {
            IEnumerable<CursusInstantie> cursusInstantieMock = null;
            _cursusRepositoryMock.Setup(x => x.GetCursusInstanties()).Returns(cursusInstantieMock);

            CursusInstantie cursusInstantie = CursusInstantieBuilder.New().Build();

            var result = _sut.DoesNotCursusInstantieExist(cursusInstantie);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void DoesCursusInstantiesExistReturnsTrueIfCursusInstanceAlreadyExist()
        {
            CursusInstantie cursusInstantieMock = CursusInstantieBuilder.New().WithStartDate(new DateTime(2020, 02, 02)).Build();

            _cursusRepositoryMock.Setup(x => x.GetCursusInstantieById(It.IsAny<int>())).Returns(cursusInstantieMock);

            var cursusInstanties = new List<CursusInstantie>
            {
                CursusInstantieBuilder.New().WithStartDate(new DateTime(2020,02,02)).Build(),
                CursusInstantieBuilder.New().WithStartDate(new DateTime(2020,03,03)).Build(),
                CursusInstantieBuilder.New().WithStartDate(new DateTime(2020,04,04)).Build(),
                CursusInstantieBuilder.New().WithStartDate(new DateTime(2020,04,04)).Build(),
                CursusInstantieBuilder.New().WithStartDate(new DateTime(2020,04,04)).Build()
            };

            var result = _sut.DoesCursusInstantiesExist(cursusInstanties);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DoesCursusInstantiesExistReturnsFalseIfCursusInstanceDoesNotExist()
        {
            IEnumerable<CursusInstantie> cursusInstantieMock = null;
            _cursusRepositoryMock.Setup(x => x.GetCursusInstanties()).Returns(cursusInstantieMock);

            var cursusInstanties = new List<CursusInstantie>
            {
                CursusInstantieBuilder.New().WithStartDate(new DateTime(2020,02,02)).Build(),
                CursusInstantieBuilder.New().WithStartDate(new DateTime(2020,03,03)).Build(),
                CursusInstantieBuilder.New().WithStartDate(new DateTime(2020,04,04)).Build(),
                CursusInstantieBuilder.New().WithStartDate(new DateTime(2020,05,05)).Build(),
                CursusInstantieBuilder.New().WithStartDate(new DateTime(2020,06,06)).Build()
            };

            var result = _sut.DoesCursusInstantiesExist(cursusInstanties);

            Assert.IsFalse(result);
        }
    }
}
