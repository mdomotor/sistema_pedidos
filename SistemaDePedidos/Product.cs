using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDePedidos
{
    class Product
    {
        public Product() { }
        public string code;
        public string description;
        public Classification classification;
        public int stock;

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
                return PATH + "Produtos.txt";
            }
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

        public static Product[] all()
        {
            Product[] products = new Product[count()];
            Product product;
            StreamReader sr = new StreamReader(FILE, Encoding.UTF8);

            string row = null;
            int position = 0;
            while ((row = sr.ReadLine()) != null)
            {
                string[] columns = row.Split(';');
                product = new Product();
                product.code = columns[0];
                product.description = columns[1];
                product.classification = columns[2];
                product.stock = Convert.ToInt32(columns[3]);

                products[position] = product;
                position++;
            }
            sr.Close();

            return products;
        }
    }
}
