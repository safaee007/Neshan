using Neshan.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neshan.Domain.Contracts
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> Add(T model);
    }
}
