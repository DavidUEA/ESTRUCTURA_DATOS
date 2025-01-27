using System;
using System.Collections.Generic;
public class FormulaBalanceada
{
    public static bool VerificarBalance(string formula)
    {
        Stack<char> pila = new Stack<char>();
        foreach (char c in formula)
        {
            if (c == '(' || c == '{' || c == '[')
            {
                pila.Push(c);
            }
            else if (c == ')' || c == '}' || c == ']')
            {
                if (pila.Count == 0) return false;
                char apertura = pila.Pop();
                if (!EsParejaCorrecta(apertura, c)) return false;
            }
        }
        return pila.Count == 0;
    }
 private static bool EsParejaCorrecta(char apertura, char cierre)
 {
    return (apertura == '(' && cierre == ')') ||
        (apertura == '{' && cierre == '}') ||
        (apertura == '[' && cierre == ']');
 }
public static void Main()
 {
    string formula = "{7+(8*5)-[(9-7)+(4+1)]}";
    Console.WriteLine("Formula balanceada: " + VerificarBalance(formula));
 }
}