using ConsoleApp.Service.IService;
using ConssoleApp.Core.Enum;
using ConssoleApp.Core.InterfaceRepo;
using ConssoleApp.Core.Model;
using CosoleApp.Data.Repositeries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Service.Services
{
    public class RestoranService : IRestoranService
    {
        public static RestoranRepo repo=new RestoranRepo();
        public void Create()
        {
            Restoran restoran= new Restoran();
            Console.WriteLine("enter the name of the restoran");
        HERE:
            string name = Console.ReadLine();
            if (Helper.Check(name))
                restoran.name = name;
            else
                goto HERE;
            Console.WriteLine("Choose the category of the restoran");
            Console.WriteLine((int)CategoryRestoran.Chinesee+"-->"+CategoryRestoran.Chinesee);
            Console.WriteLine((int)CategoryRestoran.Turkish+"-->"+CategoryRestoran.Turkish);
            Console.WriteLine((int)CategoryRestoran.Italian+"-->"+CategoryRestoran.Italian);
            int.TryParse(Console.ReadLine(), out int select);

            switch (select)
            {
                case 1:
                    restoran.Category=CategoryRestoran.Chinesee; break;
                case 2:
                    restoran.Category= CategoryRestoran.Turkish; break;
                case 3:
                    restoran.Category = CategoryRestoran.Italian; break;
                default:
                    Console.WriteLine("There are only three choices");
                    break;
            }
            repo.CreateAsync(restoran);

        }

        public async void Delete(int id)
        {
            Restoran restoran = await repo.GetAsync(x => x.ID == id);
            if (restoran == null)
            {
                Console.WriteLine("there is not a restoram with such an id enter again");
                return;
            }
            repo.DeleteAsync(restoran);
        }

        public async void Get(int id)
        {   
            Restoran restoran=await repo.GetAsync(w=>w.ID == id);
            if (restoran == null)
            {
                Console.WriteLine("there is not any restoran with such an id");
                return;
            }
            Console.WriteLine($"name-->{restoran.name} created time-->{restoran.CreatedTme} Id-->{restoran.ID} category-->{restoran.Category}");
        }

        public async void GetAll()
        {
            foreach (var item in repo.GetAll())
            {
                Console.WriteLine($"name-->{item.name} created time-->{item.CreatedTme} Id-->{item.ID} category-->{item.Category}");
            }
        }

        public async void Update(int id)
        {
            Restoran restoran = await repo.GetAsync(x=>x.ID == id);
            if (restoran == null)
            {
                Console.WriteLine("there is not any restoran with such an id");
                return;
            }
            Console.WriteLine("what do you wanna change about restoran?");
            Console.WriteLine("1-->name");
            Console.WriteLine("2-->category");
            int.TryParse(Console.ReadLine(), out int choice);

            switch (choice)
            {
                case 1:
                    Console.WriteLine("enter the new naame");
                AGAIN2:
                    string NewName = Console.ReadLine();
                    if (Helper.Check(NewName))
                        restoran.name = NewName;
                    else
                        goto AGAIN2; break;
                case 2:
                    Console.WriteLine("enter the new category");
                    Console.WriteLine("1-->"+CategoryRestoran.Italian);
                    Console.WriteLine("2-->"+CategoryRestoran.Chinesee);
                    Console.WriteLine("3-->"+CategoryRestoran.Turkish);
                    int.TryParse(Console.ReadLine(), out int select2);

                    switch (select2)
                    {
                        case 1:
                            if (restoran.Category == CategoryRestoran.Italian)
                                Console.WriteLine("its category is already italian");
                            else
                                restoran.Category = CategoryRestoran.Italian; break;
                        case 2:
                            if (restoran.Category == CategoryRestoran.Chinesee)
                                Console.WriteLine("its category is already chinesee");
                            else
                                restoran.Category = CategoryRestoran.Chinesee; break;
                        case 3:
                            if (restoran.Category == CategoryRestoran.Turkish)
                                Console.WriteLine("its category is already turkish");
                            else
                                restoran.Category = CategoryRestoran.Turkish; break;
                        default:
                            Console.WriteLine("there are only three choices");
                            break;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
