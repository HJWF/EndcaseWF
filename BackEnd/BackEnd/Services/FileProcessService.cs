using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using BackEnd.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BackEnd.Services
{
    public class FileProcessService
    {
        public static List<CursusInstantie> MapToCursusInstances(string fileContent)
        {
            var lines = fileContent.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            var splitLines = new List<string>();

            foreach (var line in lines)
            {
                splitLines.Add( line.Substring(line.IndexOf(": ") + 1));
            }

            var cursusInstanties = new List<CursusInstantie>();
            var cursusses = new List<Cursus>();
            
            for (int i = 0; i < splitLines.Count; i += 4)
            {
                var set = splitLines.Skip(i).Take(4).ToList();

                if (set != null || set.All(x => string.IsNullOrWhiteSpace(x)))
                {
                    var cursus = new Cursus();
                    var cursusInstantie = new CursusInstantie();
                    cursus.Id = i + 1000;
                    cursus.Titel = set[0];
                    cursus.Code = set[1];
                    cursus.Duur = set[2];
                    cursusInstantie.Id = i + 10000;
                    cursusInstantie.StartDatum = set[3];
                    cursusInstantie.Cursus = cursus;
                    cursusInstanties.Add(cursusInstantie);
                    cursusses.Add(cursus);
                }
            }

            return cursusInstanties;
        }

        /*
        this.splitContent = content.split('\n').map(function (el) { return el.split(': ').join('\n').split(/\r ?\n / g); });

        let counter = 0;
        let jsonoOjects = { }
        let jsonObject = { }
        for (let i = 0; i< this.splitContent.length; i++) {
            if (this.splitContent[i].length > 1) {
            jsonObject[this.splitContent[i][0]] = this.splitContent[i][1]
                jsonoOjects[counter] = jsonObject;
        }
            else
            {
            counter++;
        }
        }
        return jsonoOjects;
        */
    }
}