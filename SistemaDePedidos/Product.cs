﻿using System;
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
                return "C:\\Users\\40795448805\\";
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
                product.classification = Classification.find(columns[2]);
                product.stock = Convert.ToInt32(columns[3]);

                products[position] = product;
                position++;
            }
            sr.Close();

            return products;
        }

        public static Product findByDescription(string description)
        {
            Product product = new Product();
            StreamReader sr = new StreamReader(FILE, Encoding.UTF8);

            string row = null;
            while ((row = sr.ReadLine()) != null)
            {
                string[] columns = row.Split(';');

                if (columns[1] == description)
                {
                    product.code = columns[0];
                    product.description = description;
                    product.classification = Classification.find(columns[2]);
                    product.stock = Convert.ToInt32(columns[3]);
                    break;
                }
            }

            return product;
        }

        public static Product find(string code)
        {
            Product product = new Product();
            StreamReader sr = new StreamReader(FILE, Encoding.UTF8);

            string row = null;
            while ((row = sr.ReadLine()) != null)
            {
                string[] columns = row.Split(';');

                if (columns[0] == code)
                {
                    product.code = code;
                    product.description = columns[1];
                    product.classification = Classification.find(columns[2]);
                    product.stock = Convert.ToInt32(columns[3]);
                    break;
                }
            }

            return product;
        }
    }
}