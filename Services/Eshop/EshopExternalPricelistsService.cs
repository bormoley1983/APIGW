using MySqlConnector;
using System.Data.Common;
using System.Transactions;

namespace APIGW.Services.Eshop
{
    public class EshopExternalPricelistsService : ServiceBase
    {
        private readonly string _connectionString;
        private readonly string _prefix;

        public EshopExternalPricelistsService(
            ILogger<EshopExternalPricelistsService> logger,
            IConfiguration configuration)
            : base(logger)
        {
            _connectionString = configuration.GetConnectionString("MySqlEshop1Db")
                ?? throw new InvalidOperationException("Connection string 'MySqlEshop1Db' not found.");
            _prefix = configuration["Eshops:Eshop1:Prefix"]
                ?? throw new InvalidOperationException("Prefix for 'Eshop1' not found.");
        }

        public async Task UpdateAsync()
        {
            Logger.LogInformation("Starting pricelist update process");

            try
            {
                string script = File.ReadAllText("SQL/UpdatePricelists.sql");
                script = script.Replace("{prefix}", _prefix);

                var statements = script.Split(';')
                                       .Select(s => s.Trim())
                                       .Where(s => !string.IsNullOrWhiteSpace(s)).ToList();

                await using var connection = new MySqlConnection(_connectionString);
                await connection.OpenAsync();
                await using var transaction = await connection.BeginTransactionAsync();

                try
                {
                    foreach (var statement in statements)
                    {
                        Logger.LogDebug("Executing SQL statement: {Statement}", statement);

                        await using var command = new MySqlCommand(statement, connection, transaction);
                        await command.ExecuteNonQueryAsync();
                    }
                    await transaction.CommitAsync();
                    Logger.LogInformation("Pricelist update completed successfully");

                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    Logger.LogError("Transaction rolled back due to error");
                    throw;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Failed to update pricelists");
                throw;
            }
        }
    }
}
