using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using YamlDotNet.Core;
using YamlDotNet.Serialization;

namespace RDM_Mapfre_API.Infrastructure.Modules
{
    public static class YamlReader
    {
        private static Dictionary<object, object> YamlDictionary;

        /// <summary>
        /// Acces to config.yaml and read the object that finds in the section with the key
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="paht"></param>
        /// <returns></returns>
        public static object ReadYml(string section, string key, string path = "")
        {
            if (string.IsNullOrEmpty(path))
                path = $"{AppDomain.CurrentDomain.BaseDirectory}AppRoutes.yaml";

            if (File.Exists(path))
            {
                using (var reader = File.OpenText(path))
                {
                    var deserializer = new Deserializer();
                    if (YamlDictionary == null)
                    {
                        YamlDictionary = deserializer.Deserialize<Dictionary<object, object>>(reader);
                    }
                    if (YamlDictionary.Any(r => r.Key.ToString().Equals(section)))
                    {
                        var branch = YamlDictionary.Single(r => r.Key.ToString().Equals(section));

                        if (((Dictionary<object, object>)branch.Value).Any(r => r.Key.ToString().Equals(key)))
                        {
                            var leaf = ((Dictionary<object, object>)branch.Value).Single(r => r.Key.ToString().Equals(key)).Value;
                            return leaf;
                        }
                        else
                        {
                            throw new YamlException($"Key: '{key}' not found in section {section} at file {path}");
                        }
                    }
                    else
                    {
                        throw new YamlException($"Section: '{section}' not found at file {path}");
                    }
                }
            }
            else
            {
                throw new YamlException($"File: '{path}' not found");
            }
        }
    }
}
