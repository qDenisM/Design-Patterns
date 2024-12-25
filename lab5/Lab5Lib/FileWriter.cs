using System.IO;
using System.Reflection.Metadata;

namespace Lab5Lib
{
    public class FileWriter : IWriter
    {
        private string filename;

        public string FileName => this.filename;

        public FileWriter(string? filename = null)
        {
            this.filename = filename ?? Constant.FileName;
        }

        public string? Save(string? message)
        {
            if (message == null) return null;

            File.WriteAllText(this.filename, message);
            return this.filename;
        }
    }
}
