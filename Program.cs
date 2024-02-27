using _Slovnik;

var Bot = new TelegramBot();
System.Console.WriteLine("start");
await Bot.Start();

// var profesie = new Pack("Profesie");

// profesie.AppendWord(new WItem("čašnik", "официант"));
// profesie.AppendWord(new WItem("casnik2", "официант2"));
// profesie.AppendWord(new WItem("casnik1", "официант1"));

// for(int i = 0; i < 10; i++) {
//     WordSystem.InsertPackByName(profesie);

//     profesie.Title = "profesie" + i;
// }
// try {
//     System.Console.WriteLine(WordSystem.AppendWordInPack(new WItem("new", "new"), "Profesie.json").ToString());
// } catch {
//     Console.WriteLine("Execption");
// }

// foreach(var item in WordSystem.PACKS) {
//     var getted = WordSystem.GetPackByName(item);
    
//     Console.WriteLine($"-------{item}-------");

//     if(getted is null) Console.WriteLine("Item is null");
//     else getted.PrintList();
// } 

