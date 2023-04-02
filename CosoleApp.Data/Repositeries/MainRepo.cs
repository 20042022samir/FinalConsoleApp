using ConssoleApp.Core.InterfaceRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosoleApp.Data.Repositeries
{
    public class MainRepo<W> : ImainRepo<W>
    {
        public static List<W> depo=new List<W>();
        public async Task CreateAsync(W data)
        {
            depo.Add(data);
        }

        public async Task DeleteAsync(W data)
        {
            depo.Remove(data);
        }

        public List<W> GetAll()
        {
            return depo;
        }

        public async Task<W> GetAsync(Func<W, bool> expression)
        {
            W info = depo.FirstOrDefault(expression);
            return info;
        }
    }
}
