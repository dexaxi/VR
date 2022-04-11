using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Valve.VR;

public class SteamVRBasedController : XRBaseController
{

    public SteamVR_Input_Sources input_Source = SteamVR_Input_Sources.Any;
    public SteamVR_Action_Pose poseAction = null;

    public SteamVR_Action_Boolean selectAction = null;
    public SteamVR_Action_Boolean activateAction = null;
    public SteamVR_Action_Boolean interfaceAction = null;

   private void Start() {
       SteamVR.Initialize();
   }

    protected override void UpdateTrackingInput(XRControllerState controllerState)
    {
        if(controllerState!=null){
            Vector3 position = poseAction[input_Source].localPosition;
            controllerState.position = position;

            Quaternion rotation = poseAction[input_Source].localRotation;
            controllerState.rotation = rotation;
        }
    }

    protected override void UpdateInput(XRControllerState controllerState){
        controllerState.ResetFrameDependentStates();

        SetInteractionState(ref controllerState.selectInteractionState, selectAction[input_Source]);
        SetInteractionState(ref controllerState.activateInteractionState, activateAction[input_Source]);
        SetInteractionState(ref controllerState.uiPressInteractionState, interfaceAction[input_Source]);
        

    }

    private void SetInteractionState(ref InteractionState interactionState, SteamVR_Action_Boolean_Source action){
        interactionState.activatedThisFrame = action.stateDown;
        interactionState.deactivatedThisFrame = action.stateUp;
        interactionState.active = action.state;

        

    }


   
}
