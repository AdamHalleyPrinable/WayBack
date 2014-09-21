using UnityEngine;
using System.Collections;

using System.Collections.Generic;

public class Phone : MonoBehaviour {

    public Texture notification0;
    public Texture notification1;
    Texture notification;
    float blinkTicker = 0;
    float blinkDelay = 0.75f;

    public Texture phoneTexture;

    Rect phoneDownPosition;
    Rect phoneUpPosition;
    Rect phoneRect;

    string currentMessage = "";

    bool pending = false;
    bool phoneOut = false;

    float progress = 1f;

    GUIStyle phoneTextStyle = new GUIStyle();

	void Start () {
        notification = notification0;
        phoneDownPosition = new Rect(0, Screen.height, phoneTexture.width, phoneTexture.height);
        phoneUpPosition = new Rect(0, Screen.height/2, phoneTexture.width, phoneTexture.height);
        phoneRect = phoneDownPosition;

        phoneTextStyle.wordWrap = true;
        phoneTextStyle.normal.textColor = Color.white;
        phoneTextStyle.fontSize = 30;
	}
	
	void GetMessage (string message) {
        currentMessage = message;
        GetComponent<AudioSource>().Play();
        pending = true;
	}

    void OnGUI(){

        if (GUI.Button(phoneRect, phoneTexture, GUIStyle.none) && progress > 1.0f)
        {
            phoneOut = false;
            progress = 0;
        }

        progress += 0.01f;

        if (phoneOut)
        {
            phoneRect.position = Vector2.Lerp(phoneDownPosition.position, phoneUpPosition.position, progress);
        }
        else
        {
            phoneRect.position = Vector2.Lerp(phoneUpPosition.position, phoneDownPosition.position, progress);
        }

        if (blinkTicker > blinkDelay){
            if (notification.name == notification0.name)
            {
                notification = notification1;
            }
            else if (notification.name == notification1.name)
            {
                notification = notification0;
            }
            blinkTicker = 0;
        }

        GUI.BeginGroup(phoneRect);
        
        GUI.Label(new Rect(phoneRect.width/6, phoneRect.height/6, phoneRect.width*0.66f, phoneRect.height), currentMessage, phoneTextStyle);
        
        GUI.EndGroup();

        if (pending)
        {
            blinkTicker += Time.deltaTime;
            if (GUI.Button(new Rect(0, Screen.height - notification.height, notification.width, notification.height), notification, GUIStyle.none))
            {
                pending = false;
                phoneOut = true;
                progress = 0;
            }
        }
    }
}
