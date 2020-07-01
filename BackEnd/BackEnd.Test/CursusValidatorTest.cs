using System;
using System.Collections.Generic;
using System.Linq;
using BackEnd.DAL;
using BackEnd.Models;
using BackEnd.Services;
using BackEnd.Test.Builders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BackEnd.Test
{
    [TestClass]
    public class CursusValidatorTest
    {
        private CursusValidator _sut;
        private Mock<ICursusRepository> _cursusRepositoryMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _cursusRepositoryMock = new Mock<ICursusRepository>();
            _sut = new CursusValidator(_cursusRepositoryMock.Object);
        }

        [TestMethod]
        public void DoesCursusInstantieExistReturnsTrueIfCursusInstanceAlreadyExist()
        {
            var cursusMock = CursusBuilder.New().WithTitel("Pakkende titel").WithCode("PK").WithDuur("2 dagen").Build();
            _cursusRepositoryMock.Setup(x => x.GetCursusById(It.IsAny<int>())).Returns(cursusMock);

            var cursus = CursusBuilder.New().WithTitel("Pakkende titel").WithCode("PK").WithDuur("2 dagen").Build();

            var result = _sut.DoesCursusNotExist(cursus);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DoesCursusInstantieExistReturnsFalseIfCursusInstanceDoesNotExist()
        {
            IEnumerable<Cursus> cursussesMock = null;
            _cursusRepositoryMock.Setup(x => x.GetCursussen()).Returns(cursussesMock);

            Cursus cursusInstantie = CursusBuilder.New().WithTitel("Pakkende titel").WithCode("PK").WithDuur("2 dagen").Build();

            var result = _sut.DoesCursusNotExist(cursusInstantie);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void DoesCursusInstantiesExistReturnsTrueIfCursusInstanceAlreadyExist()
        {
            IEnumerable<Cursus> cursussesMock = new List<Cursus>
            {
                CursusBuilder.New().WithTitel("Pakkende titel").WithCode("PK").WithDuur("2 dagen").Build()
            };
            _cursusRepositoryMock.Setup(x => x.GetCursussen()).Returns(cursussesMock);

            var cursusInstanties = new List<Cursus>
            {
                CursusBuilder.New().WithTitel("Pakkende titel 1").WithCode("PK1").WithDuur("2 dagen").Build(),
                CursusBuilder.New().WithTitel("Pakkende titel 2").WithCode("PK2").WithDuur("3 dagen").Build(),
                CursusBuilder.New().WithTitel("Pakkende titel 3").WithCode("PK3").WithDuur("4 dagen").Build(),
                CursusBuilder.New().WithTitel("Pakkende titel 4").WithCode("PK4").WithDuur("5 dagen").Build()
            };

            var result = _sut.DoesCursusExist(cursusInstanties);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DoesCursusInstantiesExistReturnsFalseIfCursusInstanceDoesNotExist()
        {
            IEnumerable<Cursus> cursussesMock = null;
            _cursusRepositoryMock.Setup(x => x.GetCursussen()).Returns(cursussesMock);

            var cursusInstanties = new List<Cursus>
            {
                CursusBuilder.New().WithTitel("Pakkende titel 1").WithCode("PK1").WithDuur("2 dagen").Build(),
                CursusBuilder.New().WithTitel("Pakkende titel 2").WithCode("PK2").WithDuur("3 dagen").Build(),
                CursusBuilder.New().WithTitel("Pakkende titel 3").WithCode("PK3").WithDuur("4 dagen").Build(),
                CursusBuilder.New().WithTitel("Pakkende titel 4").WithCode("PK4").WithDuur("5 dagen").Build()
            };

            var result = _sut.DoesCursusExist(cursusInstanties);

            Assert.IsFalse(result);
        }
    }
}
