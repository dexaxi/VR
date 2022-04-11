using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimationScript : MonoBehaviour
{

    Animator handAnimator;

    private void Awake() {
        handAnimator = GetComponent<Animator>();
    }

    
   public  void   GripPress()       
     {
        handAnimator.SetFloat("Grip", 1);   
        
      }
    public void GripReleased(){

        handAnimator.SetFloat("Grip", 0);   

    }

}
