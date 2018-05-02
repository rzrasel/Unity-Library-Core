using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;

public class SqliteDatabase
{
    private string androidStremingFolder = "jar:file://" + Application.dataPath + "!/assets/UnityDatabase.sqlite3";
#if UNITY_EDITOR
    private readonly string connectionString = "URI=file:" + Application.dataPath + "/StreamingAssets/UnityDatabase.sqlite3";
#elif UNITY_ANDROID
        private readonly string connectionString = "URI=file:" + Application.persistentDataPath + "/UnityDatabase.sqlite3";
#endif
    private static SqliteDatabase instance;
    public static SqliteDatabase GetInstance
    {
        get
        {
            if (instance == null)
                instance = new SqliteDatabase();
            return instance;
        }
    }
    public SqliteDatabase()
    {
#if UNITY_ANDROID
        string filePath = Application.persistentDataPath + "/UnityDatabase.sqlite3";
        if (!File.Exists(filePath))
        {
			//WWW loadDB = new WWW ("jar:file://" + Application.dataPath + "!/assets/" + "ReportCards.sqlite");
            WWW loadDB = new WWW(androidStremingFolder);
            while (!loadDB.isDone)
            {
            }

            File.WriteAllBytes(filePath, loadDB.bytes);
        }
        else
        {

        }
#endif
        Debug.Log("Initialization");
    }
    /*private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }*/
    public void insertData(int argId, string argName)
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();
            using (IDbCommand dbCommand = dbConnection.CreateCommand())
            {
                string sqlQuery = string.Format("INSERT INTO test_db VALUES ('{0}', '{1}'); ", argId, argName);
                sqlQuery = string.Format("INSERT INTO test_db VALUES (" + "null" + ", '{0}'); ", argName);
                Debug.Log("DEBUG_LOG_INSERT_DATA: " + sqlQuery);
                dbCommand.CommandText = sqlQuery;
                dbCommand.ExecuteScalar();
                dbCommand.Dispose();
            }
            dbConnection.Close();
        }
    }
    public void getData()
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();
            using (IDbCommand dbCommand = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT * FROM test_db; ";
                dbCommand.CommandText = sqlQuery;
                using (IDataReader dbReader = dbCommand.ExecuteReader())
                {
                    while (dbReader.Read())
                    {
                        Debug.Log("DEBUG_LOG_DATA: " + dbReader.GetString(1));
                    }
                    dbReader.Close();
                }
                dbCommand.Dispose();
            }
            dbConnection.Close();
        }
    }
}
//https://ornithoptergames.com/how-to-set-up-sqlite-for-unity/
