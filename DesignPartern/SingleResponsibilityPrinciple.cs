namespace DesignPartern.SOLID
{
    /// <summary>
    /// SRP - Là một lớp điển hình chịu trách nhiệm về một việc và chỉ có một lý do để thay đổi
    /// </summary>
    public class SingleResponsibilityPrinciple
    {
        public class Joural
        {
            private readonly List<string> entries = new List<string>();
            private static int count = 0;
            public int AddEntry(string text)
            {
                entries.Add($"{++count}: {text}");
                return count; //memto
            }

            public void RemoveEntry(int index)
            {
                entries.RemoveAt(index);
            }

            public override string ToString()
            {
                return string.Join(Environment.NewLine, entries);
            }

            public void Save(string fileName)
            {
                File.WriteAllText(fileName, ToString());
            }
            //public static Joural Load(string fileName)
            //{

            //}

            //public void Load(Uri uri)
            //{
            //}
        }

        public class Persistence
        {
            public void SaveToFile(Joural j, string fileName, bool overrite = false)
            {
                if (overrite || !File.Exists(fileName))
                    File.WriteAllText(fileName, j.ToString());
            }
        }
    }
}
