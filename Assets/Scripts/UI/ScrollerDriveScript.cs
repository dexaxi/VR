using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScrollerDriveScript : MonoBehaviour
{
    Scrollbar scroller;
    TurnWheel turnWheel;
    public float turnScalar;
    private void Awake() {
        scroller = GetComponent<Scrollbar>();
        turnWheel = FindObjectOfType<TurnWheel>();
    }

    // Update is called once per frame
    void Update()
    {
        turnScalar = NormalizeRot(turnWheel.turnScalar);
        scroller.value =turnScalar;
    }


    private float NormalizeRot(float r){

        return (r+1f/2f);

    }
}
