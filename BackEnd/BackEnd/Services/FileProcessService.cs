using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BackEnd.Models;

namespace BackEnd.Services
{
    public class FileProcessService
    {
        public static CursusDto MapToCursusInstances(string fileContent)
        {
            var lines = fileContent.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToArray();

            lines = RemoveLastEmptyLines(lines);

            CheckForTheCorrectFormat(lines);

            List<string> splitLines = SplitTheValuesAfterTheSemicolon(lines);

            List<int> emptyLineIndexes = FindIndexesOfEmptyLines(splitLines);

            if (emptyLineIndexes.Count != 0)
            {
                emptyLineIndexes.ForEach(x => splitLines.RemoveAt(x));
            }

            CursusDto cursusDto = CreateCursussesAndCursusInstantiesAndAssignThemToACursusDto(splitLines);

            return cursusDto;
        }

        private static CursusDto CreateCursussesAndCursusInstantiesAndAssignThemToACursusDto(List<string> splitLines)
        {
            var cursusInstanties = new List<CursusInstantie>();
            var cursusses = new List<Cursus>();
            var cursusDto = new CursusDto
            {
                CursusInstanties = cursusInstanties,
                Cursussen = cursusses
            };

            for (int i = 0; i < splitLines.Count; i += 4)
            {
                var set = splitLines.Skip(i).Take(4).ToList();
                if (set.Count > 1)
                {
                    if (set != null || set.All(x => string.IsNullOrWhiteSpace(x)))
                    {
                        var cursus = new Cursus();
                        var cursusInstantie = new CursusInstantie();
                        cursus.Titel = set[0];
                        cursus.Code = set[1];
                        cursus.Duur = set[2];
                        if (!set[3].Contains("-"))
                        {
                            cursusInstantie.StartDatum = DateTime.Parse(set[3]);
                        }
                        else
                        {
                            throw new ArgumentException((i+3).ToString());
                        }
                        cursusInstantie.Cursus = cursus;
                        cursusInstanties.Add(cursusInstantie);
                        cursusses.Add(cursus);
                    }
                }
            }

            cursusDto.Cursussen = cursusses;
            cursusDto.CursusInstanties = cursusInstanties;
            return cursusDto;
        }

        private static List<int> FindIndexesOfEmptyLines(List<string> splitLines)
        {
            var emptyLineIndexes = new List<int>();

            for (int i = splitLines.Count - 1; i > 0; i--)
            {
                if (splitLines[i].Equals(string.Empty))
                {
                    emptyLineIndexes.Add(i);
                }
            }

            return emptyLineIndexes;
        }

        private static List<string> SplitTheValuesAfterTheSemicolon(string[] lines)
        {
            var splitLines = new List<string>();

            foreach (var line in lines)
            {
                splitLines.Add(line.Substring(line.IndexOf(": ") + 1));
            }

            return splitLines;
        }

        private static void CheckForTheCorrectFormat(string[] lines)
        {
            for (int i = 0; i < lines.Length; i += 5)
            {
                if (lines[i].Equals(string.Empty))
                {
                    break;
                }

                if (!lines[i].StartsWith("Titel", StringComparison.OrdinalIgnoreCase))
                {
                    throw new ArgumentException(i.ToString());
                }
                if (!lines[i + 1].StartsWith("Cursuscode", StringComparison.OrdinalIgnoreCase))
                {
                    throw new ArgumentException((i + 1).ToString());
                }
                if (!lines[i + 2].StartsWith("Duur", StringComparison.OrdinalIgnoreCase))
                {
                    throw new ArgumentException((i + 2).ToString());
                }
                if (!lines[i + 3].StartsWith("Startdatum", StringComparison.OrdinalIgnoreCase))
                {
                    throw new ArgumentException((i + 3).ToString());
                }
            }
        }

        private static string[] RemoveLastEmptyLines(string[] lines)
        {
            var lastItemEmpty = true;
            while (lastItemEmpty)
            {
                if (lines.Last().Equals(string.Empty))
                {
                    Debug.WriteLine(lines.Last());
                    lines = lines.Take(lines.Length - 1).ToArray();
                }
                else
                {
                    lastItemEmpty = false;
                }
            }

            return lines;
        }
    }
}