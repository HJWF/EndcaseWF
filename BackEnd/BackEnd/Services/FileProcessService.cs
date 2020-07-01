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
            var cursusDto = new CursusDto
            {
                CursusInstanties = new List<CursusInstantie>(),
                Cursussen = new List<Cursus>()
            };

            var lines = fileContent.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToArray();

            var lastItemEmpty = true;
            while(lastItemEmpty)
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

            for (int i = 0; i < lines.Length; i += 5)
            {
                if (lines[i].Equals(string.Empty) )
                {
                    break;
                }

                if (!lines[i].StartsWith("Titel", StringComparison.OrdinalIgnoreCase) || !lines[i+1].StartsWith("Cursuscode", StringComparison.OrdinalIgnoreCase) 
                    || !lines[i+2].StartsWith("Duur", StringComparison.OrdinalIgnoreCase) || !lines[i+3].StartsWith("Startdatum", StringComparison.OrdinalIgnoreCase))
                {
                    // stuur juiste regel terug
                    throw new ArgumentException(i.ToString());
                }
            }

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
                throw new ArgumentException();
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
                            throw new ArgumentException();
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