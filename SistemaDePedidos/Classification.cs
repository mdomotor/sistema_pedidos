using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDePedidos
{
    class Classification
    {
        public Classification() { }
        public string code;
        public string description;

        public static string PATH
        {
            get
            {
                return "C:\\Users\\40795448805\\";
            }
        }
        public static string FILE
        {
            get
            {
                return PATH + "Classificacoes.txt";
            }
        }
        

        public static Classification find(string code)
        {
            Classification classification = new Classification();
            StreamReader sr = new StreamReader(FILE, Encoding.UTF8);

            string row = null;
            while ((row = sr.ReadLine()) != null)
            {
                string[] columns = row.Split(';');

                if (columns[0] == code) {
                    classification.code = code;
                    classification.description = columns[1];
                    break;
                }
            }
            
            return classification;
        }
    }
}
