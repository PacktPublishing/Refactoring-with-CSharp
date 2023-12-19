using System.Data.SqlClient;

namespace Packt.CloudySkiesAir.Chapter8.AntiPatterns {
  public class DisposablePatterns {

    // Usually you won't have a connection string in code, but read it from a config file
    const string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=CloudySkies;Integrated Security=True;";


    public static void UseDisposableResourcesInAUsing1() {
      using (SqlConnection conn = new(connectionString)) {
        conn.Open();

        // other code omitted...

      } // Dispose will always be called here, even on exception
    }

    public static void UseDisposableResourcesInAUsing2() {
      using SqlConnection conn = new(connectionString);
      conn.Open();

      // other code omitted...
    } // Dispose will always be called here, even on exception
  }
}
