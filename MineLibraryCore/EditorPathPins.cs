using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class EditorPathPins : MonoBehaviour
{
    public Color pathColor;
    public Color pointTextColor;
    public List<Transform> pathObjects = new List<Transform>();
    private Transform[] pathArray;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnDrawGizmos()
    {
        /*ColorUtility.TryParseHtmlString("#e4e5df", out pathColor);
        ColorUtility.TryParseHtmlString("#e4e5df", out pointTextColor);*/
        ColorUtility.TryParseHtmlString("#606060", out pathColor);
        ColorUtility.TryParseHtmlString("#606060", out pointTextColor);
        Gizmos.color = pathColor;
        pathArray = GetComponentsInChildren<Transform>();
        pathObjects.Clear();
        int counter = 0;
        foreach (Transform pathObj in pathArray)
        {
            if (pathObj != this.transform)
            {
                counter++;
                pathObj.name = "Unit Point: " + counter;
                pathObjects.Add(pathObj);
            }
        }
        for (int i = 0; i < pathObjects.Count; i++)
        {
            Vector3 position = pathObjects[i].position;
            if (i > 0)
            {
                Vector3 previous = pathObjects[i - 1].position;
                Gizmos.DrawLine(previous, position);
                Gizmos.DrawWireSphere(position, 0.1f);
            }
            else
            {
                Gizmos.DrawWireSphere(position, 0.1f);
            }
            //UnityEditor.Handles.color = pathColor;
            GUIStyle style = new GUIStyle();
            style.normal.textColor = pointTextColor;
            //UnityEditor.Handles.Label(position, pathObjects[i].gameObject.name + " (" + (i + 1) + ")", style);
#if UNITY_EDITOR
            UnityEditor.Handles.Label(position, "Pin-" + (i + 1), style);
#endif
        }
    }
}
