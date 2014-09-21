using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : Changer {

    public float moveSpeed;

	void Start () {
	    
	}
	
	void Update () {
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Change();
            GameObject.Find("Phone").SendMessage("GetMessage", "Hey, we still good for drinks later?");
        }
	}

    protected override void Change()
    {
        base.Change();
        //Swap to miserable image
        //maybe slow walk speed
        moveSpeed *= 0.85f;
    }

	void OnGUI () {
	
	}
}
