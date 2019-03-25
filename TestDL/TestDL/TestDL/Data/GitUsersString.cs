using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TestDL.Data
{
    public class GitUsersString
    {
        public static RootObject root;
        public static List<Item> users = new List<Item>();

        public static async Task SetGitUsersStringAsync()
        {
            try
            {
                Assembly assembly = IntrospectionExtensions.GetTypeInfo(typeof(GitUsersString)).Assembly;
                Stream stream = assembly.GetManifestResourceStream("TestDL.Data.GitUsers.json");
                using (StreamReader r = new StreamReader(stream))
                {
                    var json = await r.ReadToEndAsync();
                    root = JsonConvert.DeserializeObject<RootObject>(json);
                    root.items.ForEach((obj) => users.Add(new Item { login = obj.login }));
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}
