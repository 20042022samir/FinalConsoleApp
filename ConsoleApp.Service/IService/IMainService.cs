using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Service.IService
{
    public interface IMainService
    {
        public void Create();

        public void Get(int id);

        public void GetAll();

        public void Delete(int id);

        public void Update(int id);

    }
}
