using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingCircle : MonoBehaviour
{
    public bool isClockWise = true;
    private RectTransform rectComponent;
    private float rotateSpeed = 300f;

    private void Start()
    {
        rectComponent = GetComponent<RectTransform>();
    }

    private void Update()
    {
        int direction = -1;
        if(!isClockWise)
        {
            direction = 1;
        }
        rectComponent.Rotate(0f, 0f, direction * rotateSpeed * Time.deltaTime);
    }
}
