using ConsoleApp.Service.IService;
using ConssoleApp.Core.Enum;
using ConssoleApp.Core.Model;
using CosoleApp.Data.Repositeries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Service.Services
{
    public class ProductService : IProductService
    {
       static  RestoranRepo repo=new RestoranRepo();
        public async void Create()
        {
            Product product= new Product();
            Console.WriteLine("enter the name of product");
        AGAIN3:
            string name = Console.ReadLine();
            if (Helper.Check(name))
                product.name = name;
            else
                goto AGAIN3;
            Console.WriteLine("enter the price");
            double.TryParse(Console.ReadLine(), out double price);
            product.price = price;
            Console.WriteLine("choose the category of this product");
            Console.WriteLine("1-->"+CategoryProduct.FastFood);
            Console.WriteLine("2-->"+CategoryProduct.Salty);
            Console.WriteLine("3-->"+CategoryProduct.Desert);
            int.TryParse(Console.ReadLine(),out int select);

            switch (select)
            {
                case 1:
                    product.categoryy = CategoryProduct.FastFood;break;
                case 2:
                    product.categoryy = CategoryProduct.Salty;break;
                case 3:
                    product.categoryy= CategoryProduct.Desert;break;

                default:
                    Console.WriteLine("there are only three choices");
                    break;
            }
            Console.WriteLine("which restoran you wanna add this product?");
            foreach (var item in repo.GetAll())
            {
                Console.WriteLine($"name-->{item.name} id-->{item.ID}");
            }
            int.TryParse(Console.ReadLine(), out int sselect4);
            Restoran restoran2 = await repo.GetAsync(R => R.ID == sselect4);
            if (restoran2 == null)
            {
                Console.WriteLine("there is not such a restoran");
                return;
            }
            restoran2.products.Add(product);
        }

        public async void Delete(int id)
        {
            Restoran restoran=await repo.GetAsync(D=> D.ID == id);
            Console.WriteLine("which product you wanna delete?");
            foreach (var item in restoran.products)
            {
                Console.WriteLine($"name-->{item.name} id-->{item.ID}");
            }
            int.TryParse(Console.ReadLine(),out int sselect5);
            for (int i = 0; i < restoran.products.Count; i++)
            {
                if (restoran.products[i].ID == sselect5)
                {
                    restoran.products.Remove(restoran.products[i]);
                }
            }
        }

        public async void Get(int id)
        {
            Console.WriteLine("which restoran you wannaa find the product from?");
            for (int i = 0; i < repo.GetAll().Count; i++)
            {
                Console.WriteLine($"name-->{repo.GetAll()[i].name}  id-->{repo.GetAll()[i].ID}");
            }
            int.TryParse (Console.ReadLine(),out int sselect6);
            Restoran restoran=await repo.GetAsync(K=> K.ID == id);
            if (restoran == null)
            {
                Console.WriteLine("there is not such a restoran");
                return;
            }
            Console.WriteLine("enter id of the product that you wanna find");
            int.TryParse(Console.ReadLine(),out int sselect7);
            foreach (var item in restoran.products)
            {
                if (item.ID == sselect7)
                {
                    Console.WriteLine($"name-->{item.name}  price-->{item.price}  category-->{item.categoryy} id-->{item.categoryy}");
                }
            }
        }

        public void GetAll()
        {
            Console.WriteLine("form which reestoran you wanna see the products?");
            foreach (var item in repo.GetAll())
            {
                Console.WriteLine($"name-->{item.name} id-->{item.ID}");
            }
            int.TryParse(Console.ReadLine(),out int sselect8);
            foreach (var item in repo.GetAll())
            {
                if (item.ID == sselect8)
                {
                    for (int i = 0; i < item.products.Count; i++)
                    {
                        Console.WriteLine($"name-->{item.products[i].name}  category-->{item.products[i].categoryy} id-->{item.products[i].ID}");
                    }
                }
            }
        }

        public async void Update(int id)
        {
            Restoran restoran=await repo.GetAsync (Z=> Z.ID == id);
            if(restoran == null)
            {
                Console.WriteLine("there is not such a restoran");
                return;
            }
            Console.WriteLine("choose the product that you wanna update");
            foreach (var item in restoran.products)
            {
                Console.WriteLine($"name-->{item.name}  id-->{item.ID}");
            }
            int.TryParse(Console.ReadLine(),out int sselect9);
            foreach (var item in restoran.products)
            {
                if (item.ID == sselect9)
                {
                    Console.WriteLine("what do you wanna change about the product?");
                    Console.WriteLine("1-->name");
                    Console.WriteLine("2-->price");
                    Console.WriteLine("3-->category");
                    int.TryParse(Console.ReadLine(),out int sselect10);
                    switch (sselect10)
                    {
                        case 1:
                            Console.WriteLine("enter the new name");
                        AGAIN7:
                            string name = Console.ReadLine();
                            if (Helper.Check(name))
                                item.name = name;
                            else
                                goto AGAIN7; break;
                        case 2:
                            Console.WriteLine("enter the new price");
                            double NewPrice=double.Parse(Console.ReadLine());
                           item.price = NewPrice; break;
                        case 3:
                            Console.WriteLine("choose the new category");
                            Console.WriteLine("1-->"+CategoryProduct.FastFood);
                            Console.WriteLine("2-->"+CategoryProduct.Salty);
                            Console.WriteLine("3-->"+CategoryProduct.Desert);
                            int.TryParse(Console.ReadLine(),out int sselect11);
                            switch (sselect11)
                            {
                                case 1:
                                    if(item.categoryy==CategoryProduct.FastFood)
                                        Console.WriteLine("its category is alredy fastfood");
                                    else
                                        item.categoryy = CategoryProduct.FastFood; break;
                                case 2:
                                    if (item.categoryy == CategoryProduct.Salty)
                                        Console.WriteLine("its category is alredy Salty");
                                    else
                                        item.categoryy = CategoryProduct.Salty; break;
                                case 3:
                                    if (item.categoryy == CategoryProduct.Desert)
                                        Console.WriteLine("its category is alredy Desert");
                                    else
                                        item.categoryy = CategoryProduct.Desert; break;
                            }
                            break;
                        default:
                            Console.WriteLine("there are only 3 choices");
                            break;
                    }
                }
            }
        }
    }
}
