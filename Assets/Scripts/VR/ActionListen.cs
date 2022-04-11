using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class ActionListen : MonoBehaviour
{

    private InputAction myAction;
    [Space][SerializeField] private InputActionAsset myActionAsset;
    // Start is called before the first frame update
    void Start()
    {
        myAction = myActionAsset.FindAction("XRI LeftHand/MyAction");
    }

    // Update is called once per frame
    void Update()
    {
        if(myAction.triggered){

            Debug.Log("PUSLADO");

        }
    }
}
