using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSLR
{
    public static class Metodos
    {
        public static bool isNumber(string cadena) 
        {
            foreach (char a in cadena) 
            {
                if (!Char.IsNumber(a)) 
                {
                    return false;
                }
            }
            return true;
        }

        public static (string, string[][])[] myArray()
        {
            return Form1.gramatica1;
        }


        public static bool isUpper(string cadena)
        {
            if (cadena == "") { return false; }
            foreach (char a in cadena)
            {
                if (a == '(' || a == ')' || a == '*' || a == '\\' || a == '-' || a == '/') { return false; }
                if (!Char.IsUpper(a) && !Char.IsPunctuation(a)) { return false; }
            }
            return true;
        }

        public static string[][] findProd(string produccion)
        {
            if (produccion == "" || produccion == null)
            {
                Console.WriteLine("La produccion a buscar es vacia o null");
                return null;
            }

            (string, string[][])[] array = myArray();

            string[][] myProd = null;


            foreach (var a in array)
            {
                //Console.WriteLine($"EN LA PROD: {a.Item1}");
                if (a.Item1 == produccion)
                {
                    myProd = a.Item2;
                    //Console.WriteLine($"SE ENCUENTRA {produccion}");
                }
            }


            if (myProd == null)
            {
                Console.WriteLine($"No se encontro la produccion: {produccion}");

            }
            return myProd;
        }
        public static List<(string, string[])> findFollowProd(string produccion)
        {
            if (produccion == "" || produccion == null)
            {
                Console.WriteLine("La produccion a buscar es vacia o null");
                return null;
            }

            (string, string[][])[] array = myArray();

            List<(string, string[])> prd = new List<(string, string[])>();

            foreach (var p in array)
            {
                foreach (string[] ors in p.Item2)
                {
                    foreach (string s in ors)
                    {
                        if (s == produccion)//&& p.Item1 != produccion)
                        {
                            prd.Add((p.Item1, ors));
                            Console.WriteLine($"{p.Item1} =>" + "{" + String.Join(" , ", ors) + "}");
                        }
                    }
                }
            }
            return prd;
        }

        public static List<string> siguientes(string nombreProd)
        {
            List<string> temp = new List<string>();
            if (isUpper(nombreProd))
            {
                List<(string, string[])> prodsFollow = findFollowProd(nombreProd);

                if (nombreProd == myArray()[0].Item1) //Si es la primera produccion
                {
                    temp.Add("$");
                }

                if (prodsFollow.Count() > 0)
                {

                    foreach (var a in prodsFollow)
                    {
                        if (a.Item2.Last() == nombreProd && a.Item1 != nombreProd)
                        {
                            temp.AddRange(siguientes(a.Item1));
                        }
                        else
                        {
                            int i = a.Item2.ToList().FindIndex(x => x == nombreProd);
                            i++;

                            if (i < a.Item2.Length)
                            {
                                List<string> primBeta = primeros(a.Item2[i]);
                                if (!primBeta.Contains(""))
                                {
                                    temp.AddRange(primBeta);
                                    temp = temp.Distinct().ToList();
                                }
                                else
                                {
                                    while (i < a.Item2.Length && primeros(a.Item2[i]).Contains(""))
                                    {
                                        List<string> primYSinLmbda = primeros(a.Item2[i]);
                                        primYSinLmbda.RemoveAll(x => x == "");

                                        temp.AddRange(primYSinLmbda);

                                        i++;
                                        if (i == a.Item2.Length)
                                        {
                                            temp.AddRange(siguientes(a.Item1));
                                        }


                                    }
                                    if (i < a.Item2.Length)
                                    {
                                        temp.AddRange(primeros(a.Item2[i]));
                                    }
                                    temp = temp.Distinct().ToList();
                                }
                            }




                        }
                    }
                }
                temp = temp.Distinct().ToList();
                return temp;
            }
            else
            {
                Console.WriteLine("EL NOMBRE PROD DE FOLLOW ES MINUSCULA");
                return null;
            }
        }


        public static List<string> primeros(string nombreProd)
        {
            List<string> temp = new List<string>();
            if (isUpper(nombreProd))
            {
                string[][] miProd = findProd(nombreProd);

                foreach (string[] yn in miProd)
                {

                    int i = 0;

                    if (!isUpper(yn[i]))
                    {
                        if (yn[i] == "")
                        {
                            temp.Add("");
                        }
                        else
                        {
                            temp.Add(yn[i]);
                        }

                    }
                    else
                    {
                        if (yn[i] != nombreProd)
                        {
                            List<string> primerosY = primeros(yn[i]);


                            while (i < yn.Length && primeros(yn[i]).Contains(""))
                            {
                                List<string> primYSinLmbda = primeros(yn[i]);
                                primYSinLmbda.RemoveAll(x => x == "");

                                temp.AddRange(primYSinLmbda);
                                //temp = temp.Distinct().ToList();

                                i++;

                            }

                            if (i == yn.Length)
                            {
                                i--;
                                Console.WriteLine($"i: {i}");
                            }
                            temp.AddRange(primeros(yn[i]));
                            temp = temp.Distinct().ToList();
                        }
                        else 
                        {
                            Console.WriteLine("=====RECURSION INFINITA======");
                            temp.Clear();
                            temp.Add("RECURSION INFINITA");
                        }
                        
                    }
                }
                return temp;
            }
            else
            {
                Console.WriteLine($"EL NOMBRE ES MINUSCULA: {nombreProd}");
                if (nombreProd == "")
                {
                    temp.Add("");
                }
                else
                {
                    temp.Add(nombreProd);
                }
                return temp;
            }




        }

    }
}
