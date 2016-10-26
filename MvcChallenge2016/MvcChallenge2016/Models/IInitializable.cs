using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcChallenge2016.Models
{
    public interface IInitializable<T, T2>
    {
        void Initialize(T dbContext);
        void Load(T2 modelClass);
        void Set(T2 modelClass);
    }
}
