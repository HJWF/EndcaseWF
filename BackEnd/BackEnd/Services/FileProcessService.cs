using System;
using System.Collections.Generic;
using System.Linq;
using BackEnd.Models;

namespace BackEnd.Services
{
    public class FileProcessService
    {
        public static CursusDto MapToCursusInstances(string fileContent)
        {
            var cursusDto = new CursusDto
            {
                CursusInstanties = new List<CursusInstantie>(),
                Cursussen = new List<Cursus>()
            };

            var lines = fileContent.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToArray();

            var splitLines = new List<string>();

            foreach (var line in lines)
            {
                splitLines.Add( line.Substring(line.IndexOf(": ") + 1));
            }

            var emptyLineIndexes = new List<int>();

            for (int i = splitLines.Count -1; i > 0; i--)
            {
                if (splitLines[i].Equals(string.Empty))
                {
                    emptyLineIndexes.Add(i);
                }
            }

            if (emptyLineIndexes.Count == 0 || !splitLines[4].Equals(string.Empty))
            {
                // Invalid input - op index 4 moet een lege regel zijn
                return cursusDto;
            }
            else
            {
                emptyLineIndexes.ForEach(x => splitLines.RemoveAt(x));
            }

            var cursusInstanties = new List<CursusInstantie>();
            var cursusses = new List<Cursus>();
            
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
                            return cursusDto;
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
    }
}