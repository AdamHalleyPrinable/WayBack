using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Changer : MonoBehaviour {
    bool changed = false;

    virtual protected void Change()
    {
        changed = true;
        print("is this what base.change() does?");
    }
}
