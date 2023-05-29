using System.Data.SQLite;
using System.Linq;
using Dapper;
using Wallet.Models;

namespace Wallet.Repository
{
    public class AccountRepository : IAccountRepository 
    {
        private readonly string _connectionString;
        private const string _tableName = "Accounts";

        public AccountRepository(StartOptions startOptions)
        {
            _connectionString = startOptions.Values;
        }

        private string TableName
        {
            get { return _tableName; }
        }

        public Account Create(Account entity)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            var transaction = connection.BeginTransaction();

            connection.Execute("INSERT INTO " + TableName + "(UserUrl, Type, Created) VALUES(@userUrl, @type, @created);",
                new { entity.UserUrl, entity.Type, entity.Created });

            int rowId = connection.QuerySingleOrDefault<int>("SELECT last_insert_rowid();");

            transaction.Commit();

            return Get(rowId);
        }

        public int Delete(int id)
        {
            using var connection = new SQLiteConnection(_connectionString);
            return connection.Execute("DELETE FROM " + TableName + " WHERE Id = @id;", new { id });
        }

        public Account Get(int id)
        {
            var connection = new SQLiteConnection(_connectionString);
            return connection.QuerySingleOrDefault<Account>("SELECT FROM " + TableName + "WHERE Id = @id", new { id });
        }

        public Account Update(Account entity)
        {
            using var connection = new SQLiteConnection(_connectionString);

            connection.Execute("UPDATE " + TableName + " SET UserUrl = @userUrl, Type = @type WHERE Id = @id;",
                new { entity.UserUrl, entity.Type, entity.Id });

            return Get(entity.Id);
        }

        private object GetByUrl(string userUrl)
        {
            using var connection = new SQLiteConnection(_connectionString);
            return connection.QuerySingleOrDefault<Account>("SELECT * FROM " + TableName + " WHERE UserUrl = @userUrl;",
                new { userUrl });
        }
    }
}
