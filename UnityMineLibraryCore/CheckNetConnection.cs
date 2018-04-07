using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckNetConnection
{
    private static CheckNetConnection Instance;
    public static CheckNetConnection GetInstance
    {
        get
        {
            if (Instance == null)
                Instance = new CheckNetConnection();
            return Instance;
        }
    }
    public void isConnected(MonoBehaviour argMonoBehaviour, Action<bool> argAction)
    {
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            //argAction(true);
            argMonoBehaviour.StartCoroutine(checkInternetConnection((isConnected) => {
                argAction(isConnected);
            }));
        }
        else
        {
            argAction(false);
        }
    }

    private IEnumerator checkInternetConnection(Action<bool> argAction)
    {
        WWW www = new WWW("http://google.com");
        yield return www;
        if (www.error != null)
        {
            argAction(false);
        }
        else
        {
            argAction(true);
        }
    }
}
/*
private CheckNetConnection checkNetConnection;
private void Start()
{
    checkNetConnection = CheckNetConnection.GetInstance;
    checkNetConnection.isConnected(this, (returnedValue) => {
        if (returnedValue)
        {
            Debug.Log("Internet connected");
        }
        else
        {
            Debug.Log("Error. Check internet connection!");
        }
    });
}
*/
