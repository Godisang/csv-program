
namespace CsvProgram.Services.Model
{
    public class Names
    {
        public string Name { get; set; }
        public int Count { get; set; }

        public override bool Equals(object obj)
        {
            var other = (Names)obj;
            return this.Name == other.Name && this.Count == other.Count;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
