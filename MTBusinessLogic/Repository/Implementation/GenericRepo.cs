using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;

using MTBusinessLogic.Repository.Interface;

using NPoco;

namespace MTBusinessLogic.Repository.Implementation
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private IConfiguration _configuration;
        private string? _connectionString;

        public GenericRepo(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("admin");
        }

        public IDatabase connection
        {
            get
            {
                return new NPoco.Database(_connectionString, NPoco.DatabaseType.SqlServer2008, System.Data.SqlClient.SqlClientFactory.Instance);
            }
        }
        public async Task<T> GetByStringAysnc(string searchWord)
        {
            return await connection.SingleOrDefaultAsync<T>("WHERE title = @0", searchWord);
        }

        
        public async Task<object> InsertAsync(T entityToInsert)
        {
            var result = await connection.InsertAsync(entityToInsert);
            return result != null;
        }

        public async Task<Page<T>> GetAllByPagination(int page, int pageSize)
        {
           return await connection.PageAsync<T>(page, pageSize, "SELECT * FROM Song");
        }
        
    }
}
