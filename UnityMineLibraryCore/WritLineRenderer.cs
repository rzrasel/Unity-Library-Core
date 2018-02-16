using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WritLineRenderer : MonoBehaviour {
    [SerializeField]
    private LineRenderer lineRenderer;
    public List<Vector3> linePoints;
    [SerializeField]
    //private int testPointCount;
    // Use this for initialization
    public void onStartDraw(Vector3 argMousePosition)
    {
        if (linePoints == null)
        {
            linePoints = new List<Vector3>();
            onDrawLine(argMousePosition);
            return;
        }
        else
        {
            /*if (Vector3.Distance(linePoints[linePoints.Count - 1], argMousePosition) > 0.1f)
            {
                onDrawLine(argMousePosition);
            }*/
            onDrawLine(argMousePosition);
        }
    }
    public void onStopDraw()
    {
        linePoints.Clear();
    }
    private void onDrawLine(Vector3 argMousePosition)
    {
        linePoints.Add(argMousePosition);
        //testPointCount = linePoints.Count;
        lineRenderer.positionCount = linePoints.Count;
        lineRenderer.SetPosition(linePoints.Count - 1, argMousePosition);
    }
}
