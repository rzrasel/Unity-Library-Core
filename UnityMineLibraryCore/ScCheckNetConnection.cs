using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScCheckNetConnection
{
    private static ScCheckNetConnection Instance;
    public static ScCheckNetConnection GetInstance
    {
        get
        {
            if (Instance == null)
                Instance = new ScCheckNetConnection();
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
    //-----------------------------------------
    private void onCheckAction()
    {
        onFirst((returnedValue) => {
            Debug.Log(returnedValue);
        });
    }
    private void onFirst(Action<string> argAction)
    {
        /*StartCoroutine(onSecond((returnValue) => {
            argAction("Returned value from first: " + returnValue);
        }));*/
    }
    private IEnumerator onSecond(Action<string> argAction)
    {
        argAction("Befor returned value from second");
        yield return new WaitForSeconds(10f);
        argAction("After returned value from second");
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
