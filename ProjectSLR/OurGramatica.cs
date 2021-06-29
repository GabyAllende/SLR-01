using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSLR
{
    class OurGramatica
    {
        public static List<(string, List<string>)> sim2 = new List<(string, List<string>)>()
        {

           ("A", new List<string>(){"begin","B","H","end"}),
           ("B", new List<string>(){"D",";","C"}),
           ("C", new List<string>(){"D",";","C"}),
           ("C", new List<string>(){"e"}),
           ("D", new List<string>(){"E","F"}),
           ("E", new List<string>(){"zap"}),
           ("E", new List<string>(){"smash"}),
           ("E", new List<string>(){"sting"}),
           ("E", new List<string>(){"boom"}),
           ("E", new List<string>(){"crash"}),
           ("F", new List<string>(){"identificador","G"}),
           ("G", new List<string>(){",","F"}),
           ("G", new List<string>(){"e"}),
           ("H", new List<string>(){"J",";","I"}),
           ("I", new List<string>(){"J",";","I"}),
           ("I", new List<string>(){"e"}),
           ("J", new List<string>(){"K"}),
           ("J", new List<string>(){"Q"}),
           ("J", new List<string>(){"BB"}),
           ("J", new List<string>(){"Y"}),
           ("J", new List<string>(){"R"}),
           ("K", new List<string>(){"if","[","M","]","{","H","L"}),
           ("L", new List<string>(){"}"}),
           ("L", new List<string>(){"else","{","H","}"}),
           ("M", new List<string>(){"O","N","O"}),
           ("M", new List<string>(){"M","W","M"}),
           ("M", new List<string>(){"CC"}),
           ("N", new List<string>(){"="}),
           ("N", new List<string>(){"<="}),
           ("N", new List<string>(){">="}),
           ("N", new List<string>(){"<"}),
           ("N", new List<string>(){">"}),
           ("N", new List<string>(){"!"}),
           ("O", new List<string>(){"identificador"}),
           ("O", new List<string>(){"P"}),
           ("P", new List<string>(){"num_entero"}),
           ("P", new List<string>(){"num_real"}),
           ("Q", new List<string>(){"wham", "[","M","]","{","H","}"}),
           ("R", new List<string>(){"identificador","->","S"}),
           ("R", new List<string>(){ "identificador", "->","V"}),
           ("R", new List<string>(){ "identificador", "->","M"}),
           ("S", new List<string>(){"[","S","U","S","]","T"}),
           ("S", new List<string>(){ "identificador", "T"}),
           ("S", new List<string>(){"P","T"}),
           ("T", new List<string>(){"U","S","T"}),
           ("T", new List<string>(){"e"}),
           ("U", new List<string>(){"+"}),
           ("U", new List<string>(){"-"}),
           ("U", new List<string>(){"*"}),
           ("U", new List<string>(){"/"}),
           ("V", new List<string>(){"[","V","II","V","]"}),
           ("V", new List<string>(){"identificador"}),
           ("V", new List<string>(){"sting"}),
           ("V", new List<string>(){"crash"}),
           ("W", new List<string>(){"xor"}),
           ("W", new List<string>(){"and"}),
           ("W", new List<string>(){"not"}),
           ("W", new List<string>(){"or"}),
           ("Y", new List<string>(){"waw","[", "identificador", "]","{","Z","}"}),
           ("Z", new List<string>(){"puerta","AA",":","H","break",";","Z"}),
           ("Z", new List<string>(){"default",":","H","break",";"}),
           ("AA", new List<string>(){"P"}),
           ("AA", new List<string>(){"CC"}),
           ("AA", new List<string>(){"val_crash"}),
           ("AA", new List<string>(){"val_sting"}),
           ("BB", new List<string>(){"fush","[","D","R",";","M",";","R","S","]","{","H","}"}),
           ("CC", new List<string>(){"true"}),
           ("CC", new List<string>(){"false"})
        };
    }
}
