using System.Text.Json.Serialization;

namespace _Slovnik {
    
     [Serializable]
    public class WItem { 
        public string Word { get; set; }
        public string Translate { get; set; }

        public WItem(string Word, string Translate) {
            this.Word = Word;
            this.Translate = Translate;
        }

        public bool IsCorrectTranslate(string Translate) => this.Translate == Translate;
        public bool IsCorrectWord(string Word) => this.Word == Word;

        public override string ToString()
        {
            return $"{Word} - {Translate}";
        }
    }  
}