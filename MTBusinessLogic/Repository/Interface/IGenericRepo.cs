using NPoco;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MTBusinessLogic.Repository.Interface
{
    public interface IGenericRepo<T> where T : class
    {
        Task<object> InsertAsync(T entityToInsert);
        Task<Page<T>> GetAllByPagination(int page, int pageSize);
        Task<T> GetByStringAysnc(string searchWord);
    }
}
