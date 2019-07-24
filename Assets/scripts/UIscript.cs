using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Data;
using System.Linq;
using Mono.Data.Sqlite;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIscript : MonoBehaviour
{
    
    public Text p1input;
    public Text p2input;
    public Button StartGame;
    public Text listText;
    Text GameWinner;
    int WinningScore;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        ShowHighscores();
        StartGame.onClick.AddListener(TaskOnClick);
        
    }
    void TaskOnClick()
    {
        SceneManager.LoadScene(1);
    }

    void ShowHighscores()
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
           // int rand = reader.GetInt32(2);

            listText.text += $"{name}  {value}\n";
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;

    }
    void SaveWinner()
    {
        string conn = "URI=file:" + Application.dataPath + "/SpartaGameDatabase.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = $"INSERT INTO GameScores (Winner, Moves) VALUES({GameWinner}, {WinningScore})";
        dbcmd.CommandText = sqlQuery;
      
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
