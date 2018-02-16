using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WritOrientationHandler : MonoBehaviour
{
    [SerializeField]
    private Constraint constraint = Constraint.Portrait;
    // Use this for initialization
    private void Awake()
    {
        onOrientationHandler();
    }
    private void onOrientationHandler()
    {
        if (constraint == Constraint.Portrait)
        {
            onPortrait();
        }
        else if (constraint == Constraint.Landscape)
        {
            onLandscape();
        }
        else
        {
            onBoth();
        }
    }
    private void onBoth()
    {
        Screen.autorotateToPortrait = true;
        Screen.autorotateToPortraitUpsideDown = true;
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
        Screen.orientation = ScreenOrientation.AutoRotation;
    }
    private void onPortrait()
    {
        /*if (Input.deviceOrientation == DeviceOrientation.Portrait)
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }
        else
        {
            Screen.orientation = ScreenOrientation.PortraitUpsideDown;
        }*/
        Screen.autorotateToPortrait = true;
        Screen.autorotateToPortraitUpsideDown = true;
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;
        Screen.orientation = ScreenOrientation.AutoRotation;
    }
    private void onLandscape()
    {
        /*if (Input.deviceOrientation == DeviceOrientation.LandscapeRight)
        {
            Screen.orientation = ScreenOrientation.LandscapeRight;
        }
        else
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }*/
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
        Screen.orientation = ScreenOrientation.AutoRotation;
    }
    public enum Constraint { Both, Landscape, Portrait }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
