using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using Valve.VR;

public class HandScript : MonoBehaviour
{
    [SerializeField] InputActionReference actionGrip;
    [SerializeField] InputActionReference actionTrigger;
    [SerializeField] InputActionReference accelerate;
    [SerializeField] InputActionReference reverse;
    private Animator handAnimator;       
    private TurnWheel tw;       
   private void    Awake() {
        actionGrip.action.performed += GripPress;
        actionGrip.action.canceled += GripReleased;
        actionTrigger.action.performed += TriggerPress;
        actionTrigger.action.canceled += TriggerReleased;
        accelerate.action.performed += AcceleratePressed;
        accelerate.action.canceled += AccelerateReleased;
        reverse.action.performed += DeceleratePressed;
        reverse.action.canceled += DecelerateReleased;
        handAnimator = GetComponent<Animator>();   
           }       
        
    private void Start() {
      tw = FindObjectOfType<TurnWheel>(); 
           }

    private void Update() {
      
    }
     private void   GripPress(InputAction.CallbackContext obj)       
     {
        handAnimator.SetFloat("Grip", obj.ReadValue<float>());   
        
      }
    private void GripReleased(InputAction.CallbackContext obj){

        handAnimator.SetFloat("Grip", -obj.ReadValue<float>());   

    }

     private void   TriggerPress(InputAction.CallbackContext obj)       
     {
        handAnimator.SetFloat("Trigger", obj.ReadValue<float>());   
        
      }
    private void TriggerReleased(InputAction.CallbackContext obj){

        handAnimator.SetFloat("Trigger", -obj.ReadValue<float>());   

    }
     private void   AcceleratePressed(InputAction.CallbackContext obj)       
     {
        tw.Yrot = obj.ReadValue<float>();   
        
      }
    private void AccelerateReleased(InputAction.CallbackContext obj){

        tw.Yrot = obj.ReadValue<float>();   

    }
     private void   DeceleratePressed(InputAction.CallbackContext obj)       
     {
        tw.Yrot = -obj.ReadValue<float>();   
        
      }
    private void DecelerateReleased(InputAction.CallbackContext obj){

        tw.Yrot = -obj.ReadValue<float>();   

    }


}
