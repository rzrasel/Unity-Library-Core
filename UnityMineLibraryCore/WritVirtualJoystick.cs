using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WritVirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image joystickArea;
    private Image joystickPoint;
    //private Vector3 inputVector;
    public Vector3 inputDirection;
    // Use this for initialization
    void Start()
    {
        joystickArea = GetComponent<Image>();
        joystickPoint = transform.GetChild(0).GetComponent<Image>();
    }

    public static WritVirtualJoystick Instance
    {
        get { return GameObject.FindObjectOfType<WritVirtualJoystick>(); }
    }
    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }
    public virtual void OnPointerUp(PointerEventData ped)
    {
        inputDirection = Vector3.zero;
        joystickPoint.rectTransform.anchoredPosition = Vector3.zero;
    }
    public virtual void OnDrag(PointerEventData ped)
    {
        //if (GameManager.Instance.GameState == GameManager.State.Pause) return;
        Vector2 position;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickArea.rectTransform, ped.position, ped.pressEventCamera, out position))
        {
            //Debug.Log ("Hi! how are you!");
            //Debug.Log("ORIGINAL POS : " + position + " SIZE : " + joystickArea.rectTransform.sizeDelta);
            position.x = (position.x / (joystickArea.rectTransform.sizeDelta.x / 2));
            position.y = (position.y / (joystickArea.rectTransform.sizeDelta.y / 2));
            //	Debug.Log ("MODIFIED POS : "+pos);
            inputDirection = new Vector3(position.x, 0, position.y);
            //inputDirection = new Vector3(position.x, position.y, 0);
            inputDirection = (inputDirection.magnitude > 1.0f) ? inputDirection.normalized : inputDirection;
            //	Debug.Log ("INPUT VECTOR : "+inputVector);

            joystickPoint.rectTransform.anchoredPosition = new Vector3(inputDirection.x * (joystickArea.rectTransform.sizeDelta.x / 2), inputDirection.z * (joystickArea.rectTransform.sizeDelta.y / 2));
            inputDirection = new Vector3(position.x, position.y, 0f);
        }
    }
    public float Horizontal()
    {
        return inputDirection.x;
    }
    public float Vertical()
    {
        return inputDirection.z;
    }
    public bool IsJoyStickUse()
    {
        //Debug.Log("IS USE "+_isUse);
        //return _isUse;
        return false;
    }
}
//http://www.theappguruz.com/blog/beginners-guide-learn-to-make-simple-virtual-joystick-in-unity