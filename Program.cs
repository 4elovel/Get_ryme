using System.Net;
using System.Text.RegularExpressions;
using System.Text;

internal class Program
{
    public static string getBetween(string strSource, string strStart, string strEnd)
    {
        if (strSource.Contains(strStart) && strSource.Contains(strEnd))
        {
            int Start;
            int End;
            Start = strSource.IndexOf(strStart, 0) + strStart.Length;
            End = strSource.IndexOf(strEnd, Start);
            return strSource.Substring(Start, End - Start);
        }
        return "";
    }
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://rymy.in.ua/pro_sajt");
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader stream = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
        string supp = stream.ReadToEnd();
        stream.Close();

        Regex regex = new Regex("\\\"\\S+\\.css+\\\"");
        MatchCollection matches = regex.Matches(supp);
        Console.WriteLine("Файли з розширенням css:");
        Console.WriteLine();
        if (matches.Count > 0)
        {
            foreach (Match match in matches)
                Console.WriteLine(match.Value);
        }
        Console.WriteLine();
        Console.WriteLine($"загальна кількість рим в українській мові - {getBetween(supp, "<li>Загальна кількість зареєстрованих рим: <i>", "</i></li>")}");
    }
}