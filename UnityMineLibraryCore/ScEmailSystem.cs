using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScEmailSystem : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //sendEMailToSingleRecipient();
    }
	
	// Update is called once per frame
	void Update () {
	}
    public void sendEMailToSingleRecipient()
    {
        string email_string = "argrasel@gmail.com";
        string email = email_string;
        string subject_string = "Your subject text";
        //email body
        string body_string = "Your body text";
        string subject = WWW.EscapeURL(subject_string);
        string body = WWW.EscapeURL(body_string);
        //Open the native default app
        Application.OpenURL("mailto:" + email + "?subject=" + subject + "&body=" + body);

    }
}
