using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace todo.api_service.Services
{
    public class FileService(IConfiguration config)
    {
        private readonly string filePath = config["TODO_FILE_PATH"] ?? Path.Combine(AppContext.BaseDirectory, "todoFile.txt");

        public string ReadFromFile() {
            string readText = File.ReadAllText(filePath, Encoding.UTF8);

            return readText;
        }

        public void WriteToFile(string content)
        {
            File.AppendAllText(filePath, content + Environment.NewLine, Encoding.UTF8);
        }
    }
}
