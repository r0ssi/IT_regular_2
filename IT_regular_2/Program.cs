using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IT_regular_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задача 1. Создать регулярное выражение, которому соответствовали бы " +
                "любые ошибочные написания заданного слова малина, чтобы иметь возможность отыскивать" +
                " это слово в документе, не полагаясь на грамотность автора. Предполагается, что на месте " +
                "любой гласной буквы может использоваться символ a или о.");
           
            string data1 = "молина";
            string data2 = "малино";
            string data3 = "молино";
          
            Regex firstReg = new Regex("м[ао]лин[ао]"); // создаем регуляр с двуграммой [ао] в двух слогах
          
            Console.WriteLine(firstReg.IsMatch(data1)); // t
            Console.WriteLine(firstReg.IsMatch(data2)); // t
            Console.WriteLine(firstReg.IsMatch(data3)); // t

            Console.WriteLine("\nЗадача 2. Создать регулярное выражение, которому соответствовала бы единственная восьмеричная цифра.");
          
            string data4 = "1";
            string data5 = "7"; 
            string data6 = "C"; // 12 в шестнадцатеричной
          
            Regex eightReg = new Regex(@"[0-7]"); // 0-7 так как исчисление с 0 до 7
         
            Console.WriteLine(eightReg.IsMatch(data4)); // t
            Console.WriteLine(eightReg.IsMatch(data5)); // t
            Console.WriteLine(eightReg.IsMatch(data6)); // f


            Console.WriteLine("\nЗадача 3. Создать регулярное выражение, которому соответствовал бы единственный символ, \nне являющийся восьмеричной цифрой.");
          
            Regex noneightReg = new Regex(@"[^0-7]");
          
            Console.WriteLine(noneightReg.IsMatch(data4)); // f
            Console.WriteLine(noneightReg.IsMatch(data5)); // f
            Console.WriteLine(noneightReg.IsMatch(data6)); // t

            Console.WriteLine("\nЗадача 4. Создать регулярное выражение, которому должно соответствовать слово МАЛИНА, только если оно находится в самом начале испытуемого текста.");
           
            string data7 = "малина";
            string data8 = "малина поспела";
            string data9 = "поспела малина";
            string data10 = "такая красная малина";
            
            Regex amalinaReg = new Regex(@"\Aмалина");
            
            Console.WriteLine(amalinaReg.IsMatch(data7)); // t
            Console.WriteLine(amalinaReg.IsMatch(data8)); // t
            Console.WriteLine(amalinaReg.IsMatch(data9)); // f
            Console.WriteLine(amalinaReg.IsMatch(data10)); // f

            Console.WriteLine("\nЗадача 5. Создать регулярное выражение, которому должно соответствовать слово МАЛИНА, только если оно находится в самом конце испытуемого текста.");
          
            Regex zmalinaReg = new Regex(@"малина\Z");
           
            Console.WriteLine(zmalinaReg.IsMatch(data7)); // t 
            Console.WriteLine(zmalinaReg.IsMatch(data8)); // f
            Console.WriteLine(zmalinaReg.IsMatch(data9)); // t
            Console.WriteLine(zmalinaReg.IsMatch(data10)); // t

            Console.WriteLine("\nЗадача 6. Создать регулярное выражение, которому должно соответствовать слово МАЛИНА, только если оно находится в самом начале строки.");
          
            Regex nemalinaReg = new Regex(@"^малина");
         
            Console.WriteLine(nemalinaReg.IsMatch(data7)); // t
            Console.WriteLine(nemalinaReg.IsMatch(data8)); // t
            Console.WriteLine(nemalinaReg.IsMatch(data9)); // f
            Console.WriteLine(nemalinaReg.IsMatch(data10)); // f

            Console.WriteLine("\nЗадача 7. Создать регулярное выражение, которому должно соответствовать слово МАЛИНА, только если оно находится в самом конце строки.");
            Regex endmalinaReg = new Regex(@"малина$");
            Console.WriteLine(endmalinaReg.IsMatch(data7)); // t
            Console.WriteLine(endmalinaReg.IsMatch(data8)); // f
            Console.WriteLine(endmalinaReg.IsMatch(data9)); // t
            Console.WriteLine(endmalinaReg.IsMatch(data10)); // t

            Console.WriteLine("\nЗадача 8. Создать регулярное выражение, которому соответствовало бы слово ВЕС в тексте, но которое не находило бы соответствие внутри слов (например, весы, весовщик).");
            
            string data11 = "вес";
            string data12 = "весы";
            string data13 = "весельчак";
            string data14 = "у него тяжелый вес";
            
            Regex vesReg = new Regex(@"\bвес\b");
            
            Console.WriteLine(vesReg.IsMatch(data11)); // t
            Console.WriteLine(vesReg.IsMatch(data12)); // f
            Console.WriteLine(vesReg.IsMatch(data13)); // f
            Console.WriteLine(vesReg.IsMatch(data14)); // t

            Console.WriteLine("\nЗадача 9. Создать регулярное выражение, которому соответствовало бы символ слова ВЕС в тексте, но которое не находило бы соответствие слова ВЕС.");
            Regex nevesReg = new Regex(@"\Bвес\B");
            
            // Тут формулировку задачи не совсем понял. Якоря \B перед и после слова "вес" заставляют метод IsMatch искать регуляр только, если
            // перед и после "вес" есть символы. Например: IsMatch("разВЕСовка") = True, но IsMatch("тяжелоВЕС") = False. 
            // Таким образом, чтобы IsMatch("тяжеловес") возвращало True, нужно убрать якорь \B после слова (т. е. Regex nevesReg = new Regex(@"\Bвес");)
            // С весельчаком ситуация такая же, но якорь убираем не после слова, а перед, т. е. Regex nevesReg = new Regex(@"вес\B");
            
            string data15 = "тяжеловесы";
            string data16 = "развесовка";
            string data17 = "развес";
            string data18 = "весельчак";

            Console.WriteLine(nevesReg.IsMatch(data15)); // t
            Console.WriteLine(nevesReg.IsMatch(data16)); // t
            Console.WriteLine(nevesReg.IsMatch(data17)); // f
            Console.WriteLine(nevesReg.IsMatch(data18)); // f

            Console.WriteLine("\nЗадача 10. Создать регулярное выражение, которому соответствовало бы вхождение одной из последовательностей вес, каша, компот в тексте.");
            
            Regex trioReg = new Regex(@"вес|каша|компот", RegexOptions.IgnoreCase);
           
            string data19 = "Я не представляю, как вместить в одном предложении слова вес, каша и компот";
            string data20 = "Сегодня на завтрак каша и компот";
            string data21 = "Вес - сила в физике";

            Console.WriteLine("Предложение 1: " + trioReg.IsMatch(data19)); // t
            MatchCollection matchesdata19 = trioReg.Matches(data19); 
            Console.WriteLine(matchesdata19.Count); // 3
            foreach (Match m in matchesdata19)
                Console.WriteLine(m.Value); // вес каша компот

            Console.WriteLine("Предложение 2: " + trioReg.IsMatch(data20)); // t
            MatchCollection matchesdata20 = trioReg.Matches(data20);
            Console.WriteLine(matchesdata20.Count); // 2
            foreach (Match m in matchesdata20)
                Console.WriteLine(m.Value); // каша компот

            Console.WriteLine("Предложение 3: " + trioReg.IsMatch(data20)); // t
            MatchCollection matchesdata21 = trioReg.Matches(data21);
            Console.WriteLine(matchesdata21.Count); // 1
            foreach (Match m in matchesdata21)
                Console.WriteLine(m.Value); // вес


            Console.WriteLine("\nЗадача 11. Создать регулярное выражение, которому соответствовало бы вхождению вес, каша, компот в тексте как целых слов.");
           
            string data22 = "Что за ерунда: вес, компот и каша? Напишу вес второй раз.";
            string data23 = "Теперь чуть изменю: весы, каша и компотик.";

            Regex triobReg = new Regex(@"\b(вес|компот|каша)\b"); // ограничение на слово, "весы" = false

            Console.WriteLine("Предложение 1: " + triobReg.IsMatch(data22)); //t
            MatchCollection matchesdata22 = triobReg.Matches(data22); 
            Console.WriteLine(matchesdata22.Count); // 4
            foreach (Match m in matchesdata22)
                Console.WriteLine(m.Value); // вес компот каша вес

            Console.WriteLine("Предложение 2: " + triobReg.IsMatch(data23)); // t
            MatchCollection matchesdata23 = triobReg.Matches(data23); 
            Console.WriteLine(matchesdata23.Count); // 1
            foreach (Match m in matchesdata23)
                Console.WriteLine(m.Value); // каша

            Console.WriteLine("\nЗадача 12. Создать регулярное выражение, которому соответствовали бы любые даты в формате dd\\mm\\yyyy, и сохраняющее по отдельности год, месяц и день. " +
                "Цель состоит в том, чтобы облегчить работу с отдельными значениями в программном коде, обрабатывающем совпадение. " +
                "Введем ограничение, что все даты, присутствующие в испытуемом тексте, корректны. " +
                "Регулярное выражение не должно исключать такие даты, как 9999-99-99, так как они вообще не будут появляться в испытуемом тексте.");
            
            // Поскольку в 4-ом варианте разделитель - это бэкслеш, то писать их нужно с экранированием

            Regex dmyReg = new Regex(@"\b(\d\d)\\(\d\d)\\(\d\d\d\d)\b"); // маска дд \\ мм \\ гггг
            string date1 = "10\\10\\2010"; // корректный ввод
            string date2 = "10/10\\2010"; // некорректный ввод
            
            Console.WriteLine(dmyReg.IsMatch(date1)); // t
            Console.WriteLine(dmyReg.IsMatch(date2)); // f
            

            Console.WriteLine("\nЗадача 13. Создать регулярное выражение, совпадающее с «магическими» датами в формате yyyy\\mm\\dd. " +
                "Магической считается дата, когда последние две цифры года, месяц и день являются одним и тем же числом. " +
                "Например, магической считается дата 2008\\08\\08. Введем ограничение, что все даты, присутствующие в испытуемом тексте, корректны. " +
                "Регулярное выражение не должно исключать такие даты, как 9999\\99\\99, так как они вообще не будут появляться в испытуемом тексте. Требуется отыскать только магические даты.");

            string date3 = "11\\11\\2025";
            string date4 = "11\\11\\2011";
            string date5 = "11\\10\\2011";
            
            // string date6 = "11\\11\\1111"; // test date

            Regex magicRegex = new Regex(@"\b(\d\d)\\\1\\\d\d\1\b");

            // маска = \b (дд = \d\d) \ (мм = \1) \ (гггг = \d\d - это тысяче/столетие, \1 - это десятилетие и год) \b
            // скобки в числе дня нужны для поиска повторяющихся экземпляров, т.е. будут искаться символы, совпадающие со значением (\d\d)

            Console.WriteLine(magicRegex.IsMatch(date3)); // f
            Console.WriteLine(magicRegex.IsMatch(date4)); // t
            Console.WriteLine(magicRegex.IsMatch(date5)); // f

            //Console.WriteLine(magicRegex.IsMatch(date6));

            Console.WriteLine("\nЗадача 14. Создать регулярное выражение, которому соответствовали бы любые даты в формате yyyy\\mm\\dd и сохраняющее по отдельности год, месяц и день. " +
                "Цель состоит в том, чтобы облегчить работу с отдельными значениями в программном коде, обрабатывающем совпадение. " +
                "Введем ограничение, что все даты, присутствующие в испытуемом тексте, корректны. " +
                "Содействуя достижению этой цели, необходимо присвоить сохраняемым фрагментам текста описательные имена «year», «month» и «day».");
            
            Regex typemagicRegex = new Regex(@"\b(?<magic>\d\d)\\\k<magic>\\\d\d(\k<magic>)\b");
            
            Console.WriteLine(typemagicRegex.IsMatch(date3)); // f
            Console.WriteLine(typemagicRegex.IsMatch(date4)); // t
            Console.WriteLine(typemagicRegex.IsMatch(date5)); // f
            string[] names = typemagicRegex.GetGroupNames(); // 0 1
            foreach (string n in names)
                Console.WriteLine(n); // magic


            Console.WriteLine("\nЗадача 15. Создать другое регулярное выражение, совпадающее с «магическими» датами в формате yyyy\\mm\\dd. " +
                "Магической считается дата, когда последние две цифры года, месяц и день являются одним и тем же числом. Например, магической считается дата 2012\\12\\12." +
                " Необходимо сохранить магическое число (12 в примере) и пометить его именем «magic».");

            Regex markmagicRegex = new Regex(@"\b(?<magic>\d\d)\\\k<magic>\\\d\d(\k<magic>)\b");
            Console.WriteLine(markmagicRegex.IsMatch(date3)); // f
            Console.WriteLine(markmagicRegex.IsMatch(date4)); // t
            Console.WriteLine(markmagicRegex.IsMatch(date5)); // f
            string[] marks = markmagicRegex.GetGroupNames(); // 0 1
            foreach (string m in marks)
                Console.WriteLine(m); // magic

            Console.ReadKey();

        }
    }
}
