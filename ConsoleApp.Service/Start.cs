using ConsoleApp.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Service
{
    public static class Start
    {
        public static void Started()
        {
            RestoranService RService = new RestoranService();
            ProductService productService= new ProductService();
            THERE:
            Console.WriteLine("<<MENU>>");
            Console.WriteLine("1-->operation for the resoran");
            Console.WriteLine("2-->operation for the product");
            int select=Convert.ToInt32(Console.ReadLine());
            switch (select)
            {
                case 1:
                    HERE:
                    Console.WriteLine("choose one of theese operations");
                    Console.WriteLine("1-->create restoran");
                    Console.WriteLine("2-->delete restoran");
                    Console.WriteLine("3-->show all the restorans");
                    Console.WriteLine("4-->find the restoran");
                    Console.WriteLine("5-->update restoran");
                    Console.WriteLine("6-->go back to menu");
                    int select2=Convert.ToInt32(Console.ReadLine());

                    switch (select2)
                    {
                        case 1:
                            Console.Clear();
                            RService.Create(); goto HERE;
                        case 2:
                            Console.Clear();
                            RService.GetAll();
                            Console.WriteLine("choose which restoran you wanna delete");
                            int select3=int.Parse(Console.ReadLine());
                            RService.Delete(select3); goto HERE; 
                        case 3:
                            RService.GetAll(); goto HERE;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("enter id of the restoran that you wanna find");
                            int id=int.Parse(Console.ReadLine());
                            RService.Get(id); goto HERE; 
                        case 5:
                            Console.Clear();
                            RService.GetAll();
                            Console.WriteLine("choose whaat restoran you wanna update");
                            int chooice=Convert.ToInt32(Console.ReadLine());
                            RService.Update(chooice); goto HERE; 
                        case 6:
                            Console.Clear();
                            goto THERE;
                    }
                    break;
                case 2:
                    HEREE:
                    Console.WriteLine("choose one of theese operations");
                    Console.WriteLine("1-->create product");
                    Console.WriteLine("2-->delete product");
                    Console.WriteLine("3-->show all the products");
                    Console.WriteLine("4-->find the product");
                    Console.WriteLine("5-->update product");
                    Console.WriteLine("6-->go back to menu");
                    int select5=Convert.ToInt32(Console.ReadLine());
                    switch (select5)
                    {
                        case 1:
                            Console.Clear();
                            productService.Create(); goto HEREE;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("choose the restoran where you wanna delete the product");
                            int choice24=Convert.ToInt32(Console.ReadLine());
                            RService.GetAll();
                            productService.Delete(choice24); goto HEREE;
                        case 3:
                            Console.Clear();
                            productService.GetAll(); goto HEREE;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("enter the id of the restoran where you wanna find");
                            int IDD=Convert.ToInt32(Console.ReadLine());
                            RService.GetAll();
                            productService.Get(IDD); goto HEREE;
                        case 5:
                            Console.Clear();
                            Console.WriteLine("choose the restoran where you wanna update the product");
                            RService.GetAll(); 
                            int  request=Convert.ToInt32(Console.ReadLine());
                            productService.Update(request); goto HEREE;
                        case 6:
                            Console.Clear();
                            goto THERE;
                        default:
                            break;
                    }
                    break;
            }
        }

    }
}
