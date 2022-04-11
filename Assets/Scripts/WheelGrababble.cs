using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelGrababble : MonoBehaviour
{

    private TurnWheel turnWheel;
    float normalizedQuaternion; 

    // Start is called before the first frame update
    void Start()
    {
        turnWheel = FindObjectOfType<TurnWheel>();
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(0, turnWheel.transform.rotation.y, 0);
    }
}
