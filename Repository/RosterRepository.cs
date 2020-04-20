using EY.CabinCrew.Core;
using EY.CabinCrew.Model.Entities;
using Microsoft.Extensions.Logging;
using LoggerFactory = EY.CabinCrew.Logging.LoggerFactory;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EY.CabinCrew.Repositories
{
    public class RosterRepository : IRepository<Roster>
    {
        private static ILogger<RosterRepository> Logger = LoggerFactory.CreateLogger<RosterRepository>();

        private static Lazy<ConcurrentDictionary<int, Roster>> rosters = new Lazy<ConcurrentDictionary<int, Roster>>(() =>
        {
            Dictionary<int, Roster> dict = new Dictionary<int, Roster>();
            DirectoryInfo dir = new DirectoryInfo("./Resources");
            foreach (FileInfo file in dir.GetFiles("*.json", SearchOption.TopDirectoryOnly))
            {
                Logger.LogInformation(file.FullName);
                string json = File.ReadAllText(file.FullName, Encoding.UTF8);
                Roster roster = JsonConvert.DeserializeObject<Roster>(json);
                if (int.TryParse(Path.GetFileNameWithoutExtension(file.Name), out int id))
                    dict[id] = roster;
            }

            return new ConcurrentDictionary<int, Roster>(dict);
        }, LazyThreadSafetyMode.PublicationOnly);

        public static ConcurrentDictionary<int, Roster> Rosters => rosters.Value;

        static RosterRepository()
        {
            Console.WriteLine(Rosters.Count);
        }

        public async Task<Roster> Find(Func<Roster, bool> predicate)
        {
            return await Task.Run(() =>
            {
                KeyValuePair<int, Roster> roster = Rosters.FirstOrDefault(kvp => predicate(kvp.Value));
                if (roster.Equals(default(KeyValuePair<int, Roster>)))
                    return Rosters[1];
                return roster.Value;
                //int fileNumber = new Random().Next(1, 6);
            });
        }

        public Task<List<Roster>> FindAll(Func<Roster, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
