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
    public Button StartGame, Test;
    public Text listText;
    public GameObject gameHolder;
    bool foundObject = false;
    public static string p1text, p2text;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
     
    }
    void Start()
    {
        ShowHighscores();
        StartGame.onClick.AddListener(TaskOnClick);
        Test.onClick.AddListener(TestSave);
       
       
    }
    void TestSave()
    {
        SaveWinner(p1text, 300);
        ShowHighscores();
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
        string sqlQuery = "SELECT * " + "FROM GameScores ORDER BY Moves";
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
    public static void SaveWinner(string GameWinner, int WinningScore)
    {
        // Create Database
        string conn = "URI=file:" + Application.dataPath + "/SpartaGameDatabase.db"; //Path to database.

        // Open connection to database
        IDbConnection dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();

        // Create command on connection
        IDbCommand dbcmd = dbconn.CreateCommand();

        // Create insert statement on sql insert string
        string sqlInsert = "INSERT INTO GameScores (Winner,Moves) VALUES (@newName,@newScore);";

        //Create new sqlite command
        SqliteCommand command = new SqliteCommand();
        dbcmd.Parameters.Add(new SqliteParameter("@newName", GameWinner));     //gives @currentdate sqlite parrameter data from current date variable
        dbcmd.Parameters.Add(new SqliteParameter("@newScore", WinningScore));     //gives @currenttime sqlite parrameter data from current time variable

        // Set dbcmd.CommandText to be equal to the insert statement
        dbcmd.CommandText = sqlInsert;

        IDataReader reader;

        reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {
            int value = reader.GetInt32(1);
            string name = reader.GetString(0);
            Debug.Log("name = " + name + " and value= " + value);
        }

        dbconn.Close();
    
    }
    // Update is called once per frame
    void Update()
    {
        UIscript.p1text = p1input.text;
        UIscript.p2text = p2input.text;
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Scene0" && foundObject == false)
        {
          gameHolder =  GameObject.Find("GamePlayObject");
           
           
            foundObject = true;

        }
    }
}
