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

            Assert.AreEqual(new Product(30, "cozonac"), cart.GetProductAtIndex(0));
            Assert.AreEqual(new Product(20, "mamaliga"), cart.GetProductAtIndex(1));
        }

        [TestMethod]
        public void TotalPrice()
        {
            ShoppingCart cart = new ShoppingCart();
            cart.AddProduct(new Product(30, "Cozonac"));
            cart.AddProduct(new Product(20, "Mamaliga"));

            Assert.AreEqual(50, cart.GetTotal());
        }

        [TestMethod]
        public void ProductPrice()
        {
            Assert.AreEqual(30, new Product(30, "cozonac").GetPrice());
        }

        [TestMethod]
        public void ProductName()
        {
            Assert.AreEqual("cozonac", new Product(30, "cozonac").GetName());
        }

        [TestMethod]
        public void GetProduct()
        {
            ShoppingCart cart = new ShoppingCart();
            cart.AddProduct(new Product(30, "Cozonac"));
            cart.AddProduct(new Product(20, "mamaliga"));

            Assert.AreEqual(new Product(20, "mamaliga"), cart.GetProductAtIndex(1));
        }

        [TestMethod]
        public void CartIsEmpty()
        {
            ShoppingCart cart = new ShoppingCart();

            Assert.IsTrue(cart.IsEmpty());
        }

        [TestMethod]
        public void IsLastProduct()
        {
            ShoppingCart cart = new ShoppingCart();
            cart.AddProduct(new Product(30, "Cozonac"));
            cart.AddProduct(new Product(20, "mamaliga"));

            Assert.IsTrue(cart.IsLastProduct(1));
        }

        [TestMethod]
        public void CheapestProduct()
        {
            ShoppingCart cart = new ShoppingCart();
            cart.AddProduct(new Product(30, "Cozonac"));
            cart.AddProduct(new Product(20, "mamaliga"));

            Assert.AreEqual(1 ,cart.FindCheapestProd());
        }

        [TestMethod]
        public void MostExpensiveProduct()
        {
            ShoppingCart cart = new ShoppingCart();
            cart.AddProduct(new Product(30, "Cozonac"));
            cart.AddProduct(new Product(20, "mamaliga"));

            Assert.AreEqual(0, cart.FindMostExpProd());
        }

        [TestMethod]
        public void RemoveProduct()
        {
            ShoppingCart cart = new ShoppingCart();
            cart.AddProduct(new Product(30, "Cozonac"));
            cart.AddProduct(new Product(20, "mamaliga"));
            cart.RemoveProdAtInd(1);

            ShoppingCart cart2 = new ShoppingCart();
            cart2.AddProduct(new Product(30, "Cozonac"));
            
            CollectionAssert.AreEqual(cart2.GetAllProducts(), cart.GetAllProducts());
        }

        [TestMethod]
        public void GetAllProducts()
        {

            ShoppingCart cart = new ShoppingCart();
            cart.AddProduct(new Product(30, "Cozonac"));
            cart.AddProduct(new Product(20, "mamaliga"));

            CollectionAssert.AreEqual(new Product[] { new Product(30, "cozonac"), new Product(20, "mamaliga") }, cart.GetAllProducts());
        }

        [TestMethod]
        public void RemoveMostExpensiveProduct()
        {
            ShoppingCart cart = new ShoppingCart();
            cart.AddProduct(new Product(30, "Cozonac"));
            cart.AddProduct(new Product(20, "mamaliga"));
            cart.RemoveProdAtInd(cart.FindMostExpProd());

            ShoppingCart cart2 = new ShoppingCart();
            cart2.AddProduct(new Product(20, "mamaliga"));

            CollectionAssert.AreEqual(cart2.GetAllProducts(), cart.GetAllProducts());
        }

        [TestMethod]
        public void MeanPrice()
        {

            ShoppingCart cart = new ShoppingCart();
            cart.AddProduct(new Product(30, "Cozonac"));
            cart.AddProduct(new Product(20, "mamaliga"));

            Assert.AreEqual(25, cart.CalculateMeanPrice());
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

            public decimal CalculateMeanPrice()
            {
                return GetTotal() / prods.Length;
            }

            public Product[] GetAllProducts()
            {
                return prods;
            }

            public Product GetProductAtIndex(int index)
            {
                return prods[index];
            }

            public decimal GetTotal()
            {
                decimal total = 0;

                foreach (Product p in prods)
                    total += p.GetPrice();
                return total;
            }

            public bool IsEmpty()
            {
                return prods == null;
            }

            public bool IsLastProduct(int index)
            {
                return index == prods.Length - 1;
            }

            public int FindCheapestProd()
            {
                int indOfChepestProd = 0;
                for(int i=1; i<prods.Length; i++)
                {
                    if (prods[i].GetPrice() < prods[indOfChepestProd].GetPrice())
                        indOfChepestProd = i;
                }
                return indOfChepestProd;
            }

            public int FindMostExpProd()
            {
                int indOfMostExpProd = 0;
                for (int i = 0; i < prods.Length; i++)
                {
                    if (prods[i].GetPrice() > prods[indOfMostExpProd].GetPrice())
                        indOfMostExpProd = i;
                }
                return indOfMostExpProd;
            }

            public void RemoveProdAtInd(int index)
            {
                int ct = 0;
                Product[] newProds = new Product[prods.Length - 1];
                for(int i=0; i<prods.Length; i++)
                {
                    if (i == index)
                        continue;
                    newProds[ct++] = prods[i];
                }
                prods = newProds;
            }

            //public string GetProdsNames()
            //{

            //    string result = "";

            //    if (IsEmpty())
            //        return "Shopping cart empty";

            //    for (int i = 0; i < prods.Length; i++)
            //    {
            //        if (IsLastProduct(i))
            //            result += prods[i].GetName();
            //        else
            //            result += prods[i].GetName() + ',' + ' ';
            //    }

            //    return result;
            //}

        }

        




    }
}
