using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScCircularLoading : MonoBehaviour
{
    public bool isClockWise = true;
    public RectTransform loadingImage;
    public float timeStep;
    public float anglePerStep;
    [SerializeField]
    private float startTime;
    private float timeDuration;
    // Use this for initialization
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        timeDuration = Time.time - startTime;
        if (timeDuration >= timeStep)
        {
            int direction = -1;
            if (!isClockWise)
            {
                direction = 1;
            }
            Vector3 angleRotation = loadingImage.localEulerAngles;
            angleRotation.z += direction * anglePerStep;
            loadingImage.localEulerAngles = angleRotation;
            startTime = Time.time;
            //Debug.Log("Intered: " + angleRotation.z);
        }
    }
}
