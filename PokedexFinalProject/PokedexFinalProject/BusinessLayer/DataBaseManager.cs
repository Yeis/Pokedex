using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.SqlServer.Management.Smo;
using System.IO;
using MySql.Data.MySqlClient;

namespace PokedexFinalProject
{
	public class DataBaseManager
	{
        public string BackupSQL()
        {
            Server myServer = new Server(@"(local)");
            myServer.ConnectionContext.LoginSecure = true;
            myServer.ConnectionContext.Connect();
            var db = new Database(myServer,"pokedex");
            Backup buFull = new Backup();
            buFull.Action = BackupActionType.Database;
            buFull.Database = db.Name;
            BackupDeviceItem BDI = new BackupDeviceItem();
            BDI.DeviceType = DeviceType.File;
            string dbTime = db.Name + "-" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day
                + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;
            BDI.Name = @".\" + dbTime + ".bak";

            buFull.Devices.Add(BDI);

            buFull.BackupSetName = db.Name + " Backup";
            buFull.BackupSetDescription = db.Name + " - Full Backup";

            buFull.SqlBackup(myServer);

            if (myServer.ConnectionContext.IsOpen)
                myServer.ConnectionContext.Disconnect();

            return myServer.BackupDirectory;
        }

        public string BackupMySQL()
        {
            string constring = "server=localhost;user=root;pwd=Yeis1234;database=pokemon;";
            string dbTime = "pokedex" + "-" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day
               + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;
          
            string file = "C:\\"+dbTime+".sql";
            using (MySqlConnection conn = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        mb.ExportToFile(file);
                        conn.Close();
                    }
                }
            }
            return file;
        }
	}
}