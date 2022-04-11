using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HoverBoard : MonoBehaviour
{
   
    //Editor Variables
    [SerializeField ]private float mult;
    [SerializeField] private float moveForce;
    [SerializeField]private float turnTorque;
    
    //Other Variables
    private float initialMoveForce;
    [SerializeField] public bool grounded;
    private float initialTorqueForce;
    private float gravity;

    //References
    Rigidbody hb;
    TurnWheel tw;

    DifficultyScript settings;
    ScoreScript scoreScript;
    void Start()
    {
        settings = FindObjectOfType<DifficultyScript>();
        scoreScript= FindObjectOfType<ScoreScript>();
        hb = GetComponent<Rigidbody>();
        tw = FindObjectOfType<TurnWheel>();
        initialMoveForce = moveForce;
        initialTorqueForce = turnTorque;
        gravity = 100;
    }

    public Transform[] anchors = new Transform[4];
    public RaycastHit[] hits = new RaycastHit[4];

    void FixedUpdate()
    {
        float speed = 0.5f;
        switch (settings.difficulty){

            case 0:  speed = 0.25f;
            break;
            case 1:  speed = 0.5f;
            break;
            case 2:  speed = 1f;
            break;


        }
        if(!grounded && moveForce > 0) {

            //turnTorque = initialTorqueForce / 3;
            moveForce += moveForce/1000;
            hb.AddForce(new Vector3(0,-gravity,0), ForceMode.Impulse);
            } 
        else {
            turnTorque = initialTorqueForce;
            moveForce = initialMoveForce;
            }
        
        for (int i = 0; i < 4; i++) ApplyF(anchors[i], hits[i]);
        
        hb.AddForce( ( speed+ tw.speedScalar) * moveForce * transform.forward);
        hb.AddTorque(tw.turnScalar * turnTorque * transform.up);

       
    }

    void ApplyF(Transform anchor, RaycastHit hit)
    {
        if (Physics.Raycast(anchor.position, -anchor.up, out hit))
        {
            float force = 0;
            force = Mathf.Abs(1 / (hit.point.y - anchor.position.y));
            hb.AddForceAtPosition(transform.up * force * mult * 0.25f, anchor.position, ForceMode.Acceleration);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "ground") grounded = true; 
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "ground") grounded = false; 
    }

    public void Die(){
        
        SceneManager.LoadScene(3);
        settings.score = scoreScript.score;


    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "death") Die();
    }
}
