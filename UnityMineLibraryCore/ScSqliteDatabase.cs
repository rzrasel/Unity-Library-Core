using Mono.Data.Sqlite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;

public class ScSqliteDatabase
{
    private string dbPath = "";
    private IDbConnection dbConnection = null;
    private IDbCommand dbCommand = null;
    private IDataReader dbReader = null;
    public string sqlQuery;
    public string onInit(string argDbPath, string argDbFileName)
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            string androidStremingFolder = "jar:file://" + Application.dataPath + "!/assets/" + argDbFileName;
            dbPath = "URI=file:" + Application.persistentDataPath + argDbFileName;
            string filePath = Application.persistentDataPath + argDbFileName;
            //dbPath = System.IO.Path.Combine(Application.streamingAssetsPath, "db.bytes");
            //dbPath = System.IO.Path.Combine(Application.streamingAssetsPath, argDbPath + argDbFileName);
            if (!File.Exists(filePath))
            {
                WWW reader = new WWW(androidStremingFolder);
                while (!reader.isDone) { }
                //dbPath = "URI=file:" + Application.persistentDataPath + "/db";
                System.IO.File.WriteAllBytes(filePath, reader.bytes);
            }
        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            dbPath = System.IO.Path.Combine(Application.streamingAssetsPath, argDbPath + argDbFileName);
        }
        else
        {
            dbPath = "URI=file:" + System.IO.Path.Combine(Application.streamingAssetsPath, argDbPath + argDbFileName);
        }
        return dbPath;
    }
    public IDbConnection open()
    {
        if (dbConnection == null)
        {
            dbConnection = new SqliteConnection(dbPath);
            dbConnection.Open();
        }
        //dbConnection.Open();
        return dbConnection;
    }
    public void insert(string argTableName, Hashtable argColumnValue)
    {
        sqlQuery = " INSERT INTO " + argTableName;
        string columns = "";
        string values = "";
        int counter = 0;
        foreach (string item in argColumnValue.Keys)
        {
            columns += item;
            string tempValue = argColumnValue[item] + "";
            if (string.IsNullOrEmpty(tempValue))
            {
                values += "null";
            }
            else
            {
                values += "'" + tempValue + "'";
            }
            if (counter < argColumnValue.Count - 1)
            {
                columns += ", ";
                values += ", ";
            }
            //Debug.Log("KEY: " + item + " VALUE: " + argColumnValue[item] + " SIZE: " + argColumnValue.Count);
            counter++;
        }
        sqlQuery = sqlQuery + " (" + columns + ") " + "VALUES (" + values + "); ";
        //Debug.Log(sqlQuery);
        dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = sqlQuery;
        dbCommand.ExecuteScalar();
        dbCommand.Dispose();
    }
    public void update(string argTableName, Hashtable argColumnValue, string argWhereClause)
    {
        sqlQuery = " UPDATE " + argTableName + " SET ";
        string values = "";
        int counter = 0;
        foreach (string item in argColumnValue.Keys)
        {
            string tempValue = argColumnValue[item] + "";
            values += item + " = '" + tempValue + "'";
            if (string.IsNullOrEmpty(tempValue))
            {
                values += item + " = null";
            }
            if (counter < argColumnValue.Count - 1)
            {
                values += ", ";
            }
            counter++;
        }
        sqlQuery = sqlQuery + values;
        if (!string.IsNullOrEmpty(argWhereClause))
        {
            sqlQuery = sqlQuery + " WHERE " + argWhereClause;
        }
        Debug.Log(sqlQuery);
        dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = sqlQuery;
        dbCommand.ExecuteNonQuery();
        //dbCommand.ExecuteScalar();
        dbCommand.Dispose();
    }
    public IDataReader select(string argSqlQuery)
    {
        dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = argSqlQuery;
        dbReader = dbCommand.ExecuteReader();
        return dbReader;
        /*using (IDbCommand dbCommand = dbConnection.CreateCommand())
        {
            string sqlQuery = argSql;
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
        }*/
    }
    public void closeReader()
    {
        dbReader.Close();
        dbReader = null;
    }
    public void closeCommand()
    {
        dbCommand.Dispose();
        dbCommand = null;
    }
    public void close()
    {
        if (dbConnection != null)
        {
            dbConnection.Close();
            dbConnection = null;
        }
    }
}
