using MySqlConnector;

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
            string script = File.ReadAllText("SQL/UpdatePricelists.sql");
            script = script.Replace("{prefix}", _prefix);

            var statements = script.Split(';')
                                   .Select(s => s.Trim())
                                   .Where(s => !string.IsNullOrWhiteSpace(s)).ToList();

            await using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                foreach (var statement in statements)
                {
                    await using var command = new MySqlCommand(statement, connection);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
