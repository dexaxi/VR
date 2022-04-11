using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class TurnWheel : MonoBehaviour
{
   [SerializeField] [Range(-0.5f, 2)]public float speedScalar;
   [SerializeField] [Range(-1,1)]public float turnScalar;
   [SerializeField] public float maxPosXRot;
   [SerializeField] public float minPosXRot;
    public float currentPosXRot;
    public GameObject wheel;
    
    public float Xrot;
    public float Yrot;
    bool fuckedUp;
    public GameObject car;


 
    void Update()
    {   

        currentPosXRot = wheel.transform.rotation.y;
        turnScalar = -currentPosXRot;
        speedScalar = Yrot;
        transform.parent = car.transform;
    }
    
 
}
