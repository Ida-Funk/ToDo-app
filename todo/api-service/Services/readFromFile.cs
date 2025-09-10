using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todo.api_service.Services
{
    public class FileService
    {
        String filePath = "todoFile.txt";

        public string ReadFromFile() {
            string readText = File.ReadAllText(filePath);

            return readText;
        }

        public void writeToFile(string content)
        {
            File.AppendText(filePath);
        }
    }
}
