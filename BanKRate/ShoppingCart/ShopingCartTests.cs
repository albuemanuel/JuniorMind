using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShoppingCart
{
    [TestClass]
    public class ShopingCartTests
    {

        [TestMethod]
        public void AddProduct()
        {
            ShoppingCart cart = new ShoppingCart();
            cart.AddProduct(new Product(30, "Cozonac"));
            cart.AddProduct(new Product(20, "Mamaliga"));

            Assert.AreEqual("cozonac, mamaliga", cart.GetProdsNames());
        }

        struct Product
        {
            decimal price;
            string name;

            public Product(decimal price, string name)
            {
                this.price = price;
                this.name = name.ToLower();
            }

            public decimal GetPrice()
            {
                return price;
            }

            public string GetName()
            {
                return name;
            }
        }

        struct ShoppingCart
        {
            Product[] prods;
            decimal total;

            public void AddProduct(Product prod)
            {
                if (IsEmpty())
                    prods = new Product[] { prod };
                else
                {
                    Array.Resize(ref prods, prods.Length + 1);
                    prods[prods.Length - 1] = prod;
                }

            }

            public decimal GetTotal()
            {
                foreach (Product p in prods)
                    total += p.GetPrice();
                return total;
            }

            bool IsEmpty()
            {
                return prods == null;
            }

            bool IsLastProduct(int index)
            {
                return index == prods.Length - 1;
            }

            public string GetProdsNames()
            {

                string result = "";

                if (IsEmpty())
                    return "Shopping cart empty";

                for (int i = 0; i < prods.Length; i++)
                {
                    if (IsLastProduct(i))
                        result += prods[i].GetName();
                    else
                        result += prods[i].GetName() + ',' + ' ';
                }

                return result;
            }

        }




    }
}
