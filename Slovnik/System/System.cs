using System.Text.Json;

namespace _Slovnik {
    public class WordSystem {
        public static string DIRNAME = "PACKS";
        private static string DIRECTORY => Path.Combine("..\\Slovnik", DIRNAME);

        public static List<string> PACKS {
            get {
                if(!Directory.Exists(DIRECTORY)) {
                    Directory.CreateDirectory(DIRECTORY);

                    return new List<string>();
                }

                var files = Directory.GetFiles(DIRECTORY);
                var packs = new List<string>();

                foreach(string file in files) {
                    // check on json file
                    string[] strings = file.Split('.');

                    if(strings.Length > 1 && strings[strings.Length - 1] == "json") {
                        var PathPart = file.Split('\\');

                        // delete other part path but filename
                        packs.Add(PathPart[PathPart.Length - 1]);
                    }
                }
                
                return packs;
            }
        } 

        public static Pack? GetPackByName(string filename) {
            if(!Directory.Exists(DIRECTORY)) Directory.CreateDirectory(DIRECTORY);
            var file = new FileInfo(Path.Combine(DIRECTORY, filename));
            
            if(!file.Exists) return null;
            
            // Deserialize json 
            using FileStream stream = file.OpenRead();
            return JsonSerializer.Deserialize<Pack>(stream);
        } 

        public static void InsertPackByName(Pack pack) {
            if(!Directory.Exists(DIRECTORY)) Directory.CreateDirectory(DIRECTORY);
            string path = Path.Combine(DIRECTORY, pack.Title + ".json");

            // will recreate file, if it exists
            if(File.Exists(path)) File.Delete(path);
            using (File.Create(path)) { }

            // write file
            File.WriteAllText(path, pack.Serialize());
        }   
    
        public static bool AppendWordInPack(WItem word, string filename) {
            var pack = GetPackByName(filename);

            if(pack is null) return false;

            if(pack.AppendWord(word) == false) 
                return false;
            else
                InsertPackByName(pack);

            return true;
        }
    
    }
}