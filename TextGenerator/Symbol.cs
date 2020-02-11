using System;
using System.Collections.Generic;
using System.Linq;
using TextGenerator;

public static class Symbols
{
    public const string ValidSymbol = "абвгдёежзийклмнопрстуфхцчшщъыьэюя" +
                                            "АБВГДЕЖЗИКЛМНОПРСТУФХЧШЭЮЯ" + ". ,!?";
    public static readonly List<char> Chars;

    static Symbols()
    {
        var lst = ValidSymbol.ToList();
        lst.Sort();
        Chars = lst;

    }

    public static long Add(this long l, char c)
    {
        return l | c.ToLong();
    }

    public static long ToLong(this char c)
    {
        var i = Chars.BinarySearch(c);
        if(i < -1)
            System.Console.WriteLine("xuinya");
        return 1L << i;
    }

    private static readonly Random r = new Random();
    public static T RandomElem<T>(this IList<T> lst){
        return lst[r.Next(0, lst.Count)];
    }

    private static readonly List<char> cs = new List<char>(64);
    public static char RandomElem(this long l){
        
        cs.Clear();
        
        for(var i = 0; i < 64; i++){
            
            if(((1L << i) & l) != 0) 
                cs.Add(Chars[i]);
        }

        return cs.RandomElem();
    }

    public static SubString LastSubs(this string s)
    {
        return new SubString(s.Length - K.Value, s);
    }

    public static IEnumerable<char> ToChars(this long l){
        
        for(var i = 0; i < 64; i++){
            
            if(((1 << i) & l) != 0) 
                yield return Chars[i - 1];
        }
        
    }

}