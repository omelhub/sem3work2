using Dapper;
using Model2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer;

internal class DapperRepository<T> : IRepository<T> where T : class, IDomainObject
{
    static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DbConnection;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    IDbConnection db = new SqlConnection(connectionString);

    public IEnumerable<T> GetAll()
    {
        return db.Query<T>("SELECT * FROM Students").ToList();
    }

    public T GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Create(T obj)
    {
        var sqlQuery = "INSERT INTO Students (Name, [Group], Speciality) VALUES(@Name, @Group, @Speciality); SELECT CAST(SCOPE_IDENTITY() as int)";
        int Id = db.Query<int>(sqlQuery, obj).FirstOrDefault();
        obj.Id = Id;
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public void Save()
    {
        throw new NotImplementedException();
    }
}

