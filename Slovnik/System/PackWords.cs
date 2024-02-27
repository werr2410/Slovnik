using System.Text.Json;

namespace _Slovnik {
    public class Pack {
        public string Title { get; set; }
        public List<WItem> Words { get; set; } = new();

        public Pack(string Title) => this.Title = Title;

        public bool AppendWord(WItem Word) {
            foreach(WItem item in Words) {
                if(item == Word)
                    return false;
            }

            Words.Add(Word);

            return true;
        }

        public void PrintList() {
            foreach(var item in Words) {
                System.Console.WriteLine(item);
            }
        }
        
        public string Serialize() {
            var options = new JsonSerializerOptions { WriteIndented = true };
            return JsonSerializer.Serialize(this, options);  
        }

        public static Pack? Deserialize(string document) {
            return JsonSerializer.Deserialize<Pack>(document);
        }
    }
}