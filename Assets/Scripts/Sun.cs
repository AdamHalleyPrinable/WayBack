using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sun : Changer {

	void Start () {
	
	}
	
	void Update () {
	
	}

    protected override void Change()
    {
 	     base.Change();
         GetComponent<Light>().color = Color.blue;
    }

}
