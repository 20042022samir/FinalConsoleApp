using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConssoleApp.Core.InterfaceRepo
{
    public interface ImainRepo<W>
    {
        public Task CreateAsync(W data);

        public Task DeleteAsync(W data);

        public List<W> GetAll();

        public Task<W> GetAsync(Func<W,bool> expression);


    }
}
