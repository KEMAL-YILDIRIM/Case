using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Case.MVC.Hubs
{
    public class DatabaseListener
    {

        readonly static string _connectionString = ConfigurationManager.ConnectionStrings["Case"].ConnectionString;

        SqlConnection connection = new SqlConnection(_connectionString);
        public DatabaseListener()
        {
            connection.Open();
        }

        ~DatabaseListener()
        {
            connection.Close();
        }


        public void Listener()
        {
            string commandText = @"SELECT [Id], [RssLink], [ContentXml] FROM [dbo].[RssPage]";

            using (var command = new SqlCommand(commandText, connection))
            {
                command.Notification = null;

                SqlDependency dependency = new SqlDependency(command);
                dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                //while conn is open reader check the db and notify changes
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
            }
        }


        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Type == SqlNotificationType.Change)
            {
                NotificationHub.SendMessages(e.Info.ToString());
            }
        }

    }
}