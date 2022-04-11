using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
public class LeapScript : MonoBehaviour
{
    private InputAction tpStart;
    private InputAction tpConfirm;
    private InputAction tpMove;
    
    private Vector3 tpMovement;
 
    private GameObject tpCylinder;

    private XRRig rig;
    
    private bool tpIsMoving;
    [Space][SerializeField] private InputActionAsset myActionAsset;
    
    
    private void Awake() {
            
        rig = FindObjectOfType<XRRig>();
        tpCylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        tpCylinder.transform.localScale = new Vector3(1,0.1f,1);
        tpCylinder.GetComponent<MeshRenderer>().material.color = Color.green;
        tpCylinder.transform.position = new Vector3(rig.transform.position.x, 0.2f, rig.transform.position.z);
        tpCylinder.SetActive(false);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        tpStart= myActionAsset.FindAction("XRI RightHand/TeleportStart");
        tpConfirm = myActionAsset.FindAction("XRI RightHand/Teleport");
        tpMove= myActionAsset.FindAction("XRI RightHand/MoveTeleport");

        HandleInput();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(tpIsMoving && tpCylinder != null && tpCylinder.activeSelf){
            
            tpCylinder.transform.position += tpMovement/2;

        }
    }

    private void HandleInput(){

        tpStart.performed += ctx =>{
            
            //Spawn Circle
            tpCylinder.SetActive(true);

        };
        tpConfirm.performed += ctx =>{

            if(tpCylinder.activeSelf){    
                //Tp to circle
                Vector3 aux = new Vector3(tpCylinder.transform.position.x, rig.transform.position.y, tpCylinder.transform.position.z);
                tpCylinder.transform.position = new Vector3(rig.transform.position.x, 0.2f, rig.transform.position.z);
                tpCylinder.SetActive(false);
            }

        };
        tpMove.performed += ctx =>{
            
            tpIsMoving = true;
            //Movement
            if(tpIsMoving == true && tpCylinder != null && tpCylinder.activeSelf) {
            var aux = ctx.ReadValue<Vector2>();
            tpMovement.x =  aux.x;
            tpMovement.z = aux.y;
            }
        };
        tpStart.canceled += ctx =>{
            
            //DespawnCircle
            tpCylinder.SetActive(false);

        };
        tpMove.canceled += ctx =>{
            
            //DespawnCircle
            tpIsMoving = false;

        };
    
    }


}
