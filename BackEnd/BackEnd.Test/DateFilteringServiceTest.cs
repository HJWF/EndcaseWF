using System;
using System.Collections.Generic;
using System.Linq;
using BackEnd.Models;
using BackEnd.Services;
using BackEnd.Test.Builders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BackEnd.Test
{
    [TestClass]
    public class DateFilteringServiceTest
    {
        private DateTime _date = new DateTime(2020, 7, 2);

        [TestMethod]
        public void FilterOnWeekShouldReturnTheCorrectCursusses()
        {
            var cursusInstanties = new List<CursusInstantie>
            {
                CursusInstantieBuilder.New().WithStartDate(_date).Build()
            };
            var yearWeek = 202027;

            var result = DateFilteringService.FilterOnWeek(cursusInstanties, yearWeek);

            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void FilterOnWeekShouldOnlyReturnTheCursussenForSpecificWeekNumber()
        {
            var cursusInstanties = new List<CursusInstantie>
            {
                CursusInstantieBuilder.New().WithStartDate(_date).Build(),
                CursusInstantieBuilder.New().WithStartDate(_date.AddDays(30)).Build(),
                CursusInstantieBuilder.New().WithStartDate(_date.AddDays(-30)).Build(),
                CursusInstantieBuilder.New().WithStartDate(_date.AddDays(2)).Build(),
            };
            var yearWeek = 202027;

            var result = DateFilteringService.FilterOnWeek(cursusInstanties, yearWeek);

            Assert.AreEqual(2, result.Count());
        }
    }
}
