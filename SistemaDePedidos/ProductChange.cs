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
                return "C:\\Users\\40795448805\\";
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
            string operationType;
            if (opType == "Entrada") operationType = "E";
            else operationType = "S";

            StreamWriter arq = new StreamWriter(FILE, true, Encoding.UTF8);
            arq.WriteLine(operation + ";" + date + ";" + product.code + ";" + product.classification.code + ";" + operationType + ";" + qtt);
            arq.Close();
        }

        public static ProductChange[] all()
        {
            ProductChange[] productChanges = new ProductChange[count()];
            ProductChange productChange;
            StreamReader sr = new StreamReader(FILE, Encoding.UTF8);

            string row = null;
            int position = 0;
            while ((row = sr.ReadLine()) != null)
            {
                string[] columns = row.Split(';');
                productChange = new ProductChange();
                productChange.operation = columns[0];
                productChange.date = columns[1];
                productChange.product= Product.find(columns[2]);
                productChange.opType = columns[4];
                productChange.qtt = Convert.ToInt32(columns[5]);

                productChanges[position] = productChange;
                position++;
            }
            sr.Close();

            return productChanges;
        }

        public static int count()
        {
            StreamReader sr = new StreamReader(FILE, Encoding.UTF8);
            int count = 0;

            while (sr.ReadLine() != null)
            {
                count++;
            }

            sr.Close();
            return count;
        }
    }
}
