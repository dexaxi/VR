using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnWheel : MonoBehaviour
{
   [SerializeField] [Range(-0.5f, 2)]public float speedScalar;
   [SerializeField] [Range(-1,1)]public float turnScalar;
   [SerializeField] public float maxPosXRot;
   [SerializeField] public float minPosXRot;
    public float currentPosXRot;
    
    public float Xrot;
    public float Yrot;
    
  
    

    
    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {   
        currentPosXRot = Input.GetAxis("Horizontal");
        Xrot = Mathf.Clamp(currentPosXRot,minPosXRot, maxPosXRot);
        transform.Rotate(0,Xrot,0); 
        turnScalar = Xrot;

        Yrot = Input.GetAxis("Vertical");
        speedScalar = Yrot;
    }

}
