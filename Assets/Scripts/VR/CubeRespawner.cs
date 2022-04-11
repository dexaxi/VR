using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CubeRespawner : MonoBehaviour
{
    private InputAction respawnCube;
    public GameObject myCube;
    private Vector3 cubeInitialTransform;

    [Space][SerializeField] private InputActionAsset myActionAsset;
    
    private void Awake() {
        
        cubeInitialTransform = myCube.transform.position; 

    }

    // Start is called before the first frame update
    void Start()
    {
        respawnCube = myActionAsset.FindAction("XRI LeftHand/MyAction");
    }

    // Update is called once per frame
    void Update()
    {
        if(respawnCube.triggered){

            myCube.transform.position = cubeInitialTransform;
            
        }
    }
}
