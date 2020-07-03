using System;
using BackEnd.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BackEnd.Test
{
    [TestClass]
    public class FileProcessServiceTest
    {
        [TestMethod]
        public void FilecontentShouldReturnListOfCursussen()
        {
            string content = "Titel: C# Programmeren\r\nCursuscode: CNETIN\r\nDuur: 5 dagen\r\nStartdatum: 8/10/2018\r\n\r\nTitel: C# Programmeren\r\nCursuscode: CNETIN\r\nDuur: 5 dagen\r\nStartdatum: 15/10/2018\r\n\r\nTitel: Java Persistence API\r\nCursuscode: JPA\r\nDuur: 2 dagen\r\nStartdatum: 15/10/2018\r\n\r\nTitel: Java Persistence API\r\nCursuscode: JPA\r\nDuur: 2 dagen\r\nStartdatum: 8/10/2018\r\n\r\nTitel: C# Programmeren\r\nCursuscode: CNETIN\r\nDuur: 5 dagen\r\nStartdatum: 8/10/2018\r\n\r\n";

            var list = FileProcessService.MapToCursusInstances(content);

            Assert.AreEqual(5, list.CursusInstanties.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FilecontentShouldNotAddInvalidDatetimeAndThrowError()
        {
            string content = "Titel: C# Programmeren\r\nCursuscode: CNETIN\r\nDuur: 5 dagen\r\nStartdatum: 8-10-2018\r\n\r\nTitel: C# Programmeren\r\nCursuscode: CNETIN\r\nDuur: 5 dagen\r\nStartdatum: 15-10-2018\r\n\r\n";

            FileProcessService.MapToCursusInstances(content);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FilecontentShouldReturnEmptyListOfCursussenAndThrowError()
        {
            string content = "Titel: C# Programmeren\r\nCursuscode: CNETIN\r\nDuur: 5 dagen\r\nStartdatum: 8/10/2018\r\nTitel: C# Programmeren\r\nCursuscode: CNETIN\r\nDuur: 5 dagen\r\nStartdatum: 15/10/2018";

            FileProcessService.MapToCursusInstances(content);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FilecontentShouldHandleEmptyLinesAtTheEndCorrectAndThrowError()
        {
            string content = "Titel: C# Programmeren\r\nCursuscode: CNETIN\r\nDuur: 5 dagen\r\nStartdatum: 8/10/2018\r\nTitel: C# Programmeren\r\nCursuscode: CNETIN\r\nDuur: 5 dagen\r\nStartdatum: 15/10/2018\r\n";

            FileProcessService.MapToCursusInstances(content);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FilecontentShouldThrowError()
        {
            string content = "Titel: C# Programmeren\r\nCursuscode: CNETIN\r\nStartdatum: 8/10/2018\r\n\r\nTitel: C# Programmeren\r\nCursuscode: CNETIN\r\nDuur: 5 dagen\r\nStartdatum: 15/10/2018\r\n\r\n";

            FileProcessService.MapToCursusInstances(content);
        }
    }
}



