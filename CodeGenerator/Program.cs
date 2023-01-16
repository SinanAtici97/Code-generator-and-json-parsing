using System;
public class Program
{
    public static bool ControlAlphanumeric(string s)
        {
            foreach ( char c in s )
            {
                if(!(c >= 'A' && c <= 'Z') && !(c>='0' && c<='9')){
                    return false;
                }
            }
            return true;
        }

    public static void Main()
    {
        var chars = "ACDEFGHKLMNPRTXYZ234579";
        var stringChars = new char[8];
        var random = new Random();
        int k = 0;
        
        do 
        {
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            Console.Write(finalString);
            
            k++;


        string str = finalString;
        if (ControlAlphanumeric(str))
        {
            Console.Write(" (Reliable) \n");
        }
        else
        {
            Console.Write(" (Unreliable) \n");
        }


        }
        while(k < 1000); // iteration limit
    }
}
