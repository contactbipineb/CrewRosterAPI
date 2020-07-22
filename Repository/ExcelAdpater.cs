using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using EY.CabinCrew.Core;

namespace EY.CabinCrew.Repositories
{
    public static class ExcelAdpater
    {
        public static IList<TEntity> Read<TEntity>(string filepath, string seperator)
         where TEntity : class, IConvertable, new()
        {
            List<TEntity> entries = new List<TEntity>();
            string[] lines = File.ReadAllLines(filepath, Encoding.UTF8);

            foreach (string line in lines)
            {
                string[] arr = line.Split(seperator).Select(str => str.ToLower()).ToArray();
                TEntity entity = new TEntity();
                entity.Convert(arr);
                entries.Add(entity);
            }

            //logger.LogDebug("Mappings loaded:\n {0}", entries);
            return entries;
        }



    }
}
