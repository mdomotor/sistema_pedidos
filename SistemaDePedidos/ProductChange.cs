using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDePedidos
{
    class ProductChange
    {
        public ProductChange() { }
        public string operation;
        public string date;
        public Product product;
        public string opType;
        public int qtt;

        public static string PATH
        {
            get
            {
                return "C:\\Users\\42566937850\\";
            }
        }
        public static string FILE
        {
            get
            {
                return PATH + "Movimentação.txt";
            }
        }

        public static void create(string operation, string date, Product product, string opType, int qtt)
        {
            StreamWriter arq = new StreamWriter(FILE, true, Encoding.UTF8);
            arq.WriteLine(operation + ";" + date + ";" + ";" + product + ";" + opType + ";" + qtt);
            arq.Close();
        }
    }
}
