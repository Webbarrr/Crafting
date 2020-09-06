using Crafting.Library.Data.Deserialized;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Crafting.Library.Data.DataWrappers
{
    public class DataWrapper<T> where T : IData
    {
        private readonly string _filePath;
        public DataWrapper()
        {
            var split = typeof(T).FullName.Split('.');
            var fileName = split[split.Length -1];

            _filePath = $@"{this.GetFilePath()}\{fileName}.json";

            if (!File.Exists(_filePath))
            {
                File.Create(_filePath).Dispose();
            }
        }

        private string GetFilePath()
        {
            return Path.Combine(Environment.CurrentDirectory,
                "Data", "Serialized");
        }

        public List<T> Get()
        {
            using (var file = File.OpenText(_filePath))
            {
                var serializer = new JsonSerializer();
                return (List<T>)serializer.Deserialize(file, typeof(List<T>));
            }
        }

        public void Set(List<T> list)
        {
            if (list is null)
                throw new ArgumentNullException(nameof(list));

            using (var file = File.CreateText(_filePath))
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(file, list);
            }
        }

        public void OpenRawData()
        {
            Process.Start(_filePath);
            Console.WriteLine(_filePath);
        }


    }
}
