using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTemplateSolution01.Service
{
    public interface ICrudDao<T>
    {
        //definir las firmas
        void create(T o);
        void update(T o);
        void delete(T o);
        T findForId(int o);
        List<T> readAll();

    }
}
