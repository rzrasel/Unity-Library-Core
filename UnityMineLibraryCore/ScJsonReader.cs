using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Questions
{
    public string id;
    public string question;
    public string answer1;
    public string answer2;
}

[System.Serializable]
public class QuestionList
{
    public List<Questions> list;
}
public class ScJsonReader : MonoBehaviour
{
    private string url = "http://mysafeinfo.com/api/data?list=englishmonarchs&format=json";
    public string key, iv;
    public string data = "Hi test";
    //private ScEncryption encryption;
    // Use this for initialization
    void Start()
    {
        ScEncryption.GenerateKeyIV(out key, out iv);
        data = ScEncryption.Encrypt(data, key, iv);
        key = "hbvkorRxqifryP512zNeJIsWVZpbFWe28xcrxehyj2E=";
        iv = "FII8jQMJ0rAIU0kNSYc+i0CfCoukuKwgwRdv4N24RLc=";
        data = "r/gr22+VD5+d2DK4FjF96lTV6jKx9t4btHUx6XUTEns=";
        data = ScEncryption.Decrypt(data, key, iv);
        StartCoroutine(onReadJsonData());
    }

    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator onReadJsonData()
    {
        Debug.Log("CALLED: onReadJsonData");
        WWW www = new WWW(url);
        yield return www;
        if (www.error == null)
        {
            string jsonTextData = www.text;
            Debug.Log("SERVER_DATA: " + jsonTextData);
            //JSONObject json = JSONObject.Parse(jsonStrData);
            /*JObject jsonObject = new JObject();
            Object joResponse = JObject.Parse(jsonTextData);
            JArray array = JArray.Parse(a);*/
            //List<Item> items = JsonConvert.DeserializeObject<List<Item>>(json);
            //List<Item> items = JsonUtility.FromJson<List<Item>> (jsonTextData);
            string tempJson = "{\"list\":[{\"id\":\"1\",\"question\":\"lorem Ipsome \",\"answer1\":\"yes\",\"answer2\":\"no\"},{\"id\":\"2\",\"question\":\"lorem Ipsome Sit dore iman\",\"answer1\":\"si\",\"answer2\":\"ne\"}]}";
            //CartasData data = JsonUtility.FromJson<CartasData>(jsonTextData);
            QuestionList result = JsonUtility.FromJson<QuestionList>(tempJson);
            Debug.Log("LIST_LENGTH: " + result.list.Count);
            //https://www.gamedev.net/forums/topic/694857-unitywebrequest-result-cant-be-deserialized-to-json/

        }
        else
        {
            Debug.Log("ERROR: " + www.error);
        }
    }
    //-----------------------------------------------
    /*[System.Serializable]
    public class Questions
    {
        public string id;
        public string question;
        public string answer1;
        public string answer2;
    }

    [System.Serializable]
    public class QuestionList
    {
        public List<Questions> list;
    }*/
    //-----------------------------------------------
    [System.Serializable]
    public class Item
    {
        public string nm { get; set; }
        public string cty { get; set; }
        public string hse { get; set; }
        public int yrs { get; set; }
    }
    [System.Serializable]
    public class CartasData
    {
        public List<Item> MyItems;
    }
    //-----------------------------------------------
    private void GetTheScores()
    {
        /*UnityWebRequest GetCommand = UnityWebRequest.Get(url);
        UnityWebRequestAsyncOperation operation = GetCommand.SendWebRequest();

        if (!operation.webRequest.isNetworkError)
        {
            ResultsContainer rez = JsonUtility.FromJson<ResultsContainer>(operation.webRequest.downloadHandler.text);
            Debug.Log("Text: " + operation.webRequest.downloadHandler.text);
        }*/
        //[{"id":1,"name":"Player1"},{"id":2,"name":"Player2"}]
    }
    [System.Serializable]
    public class ResultScript
    {
        public int id;
        public string name;
    }
    [System.Serializable]
    public class ResultsContainer
    {
        public ResultScript[] results;
    }
    //rez.results=JsonUtility.FromJson<ResultsContainer>(myJsonString);
    //{"results":[{"id":1,"name":"Player1"},{"id":2,"name":"Player2"}]}
    //-----------------------------------------------
}
