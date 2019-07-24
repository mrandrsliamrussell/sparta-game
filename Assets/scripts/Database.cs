using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Mono.Data.Sqlite;
using System.IO;
using UnityEngine;


public class Database : MonoBehaviour
{
   
    
    void Start()
    {

        string conn = "URI=file:" + Application.dataPath + "/SpartaGameDatabase.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT * " + "FROM GameScores";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            int value = reader.GetInt32(1);
            string name = reader.GetString(0);
           

            Debug.Log("value= " + value + "  name =" + name );
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
