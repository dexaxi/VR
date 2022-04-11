using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float amplitude = 0.5f;
    public float frequency = 1f;
    bool canMove;
    public float speed;
    float step;
    // Position Storage Variables
    public bool isDead;
    public bool isHitting;
    public HoverBoard player;
    Rigidbody myRb;
    HealthScript hs;
 
    // Use this for initialization
    void Start () {
        hs = FindObjectOfType<HealthScript>();
        myRb = GetComponent<Rigidbody>();
        canMove =false;
        StartCoroutine(StartR());
        StartCoroutine(AI());
        isHitting = false;
    }
     
    // Update is called once per frame
    void Update () {
         player = FindObjectOfType<HoverBoard>();

        step = speed * Time.deltaTime;
        StartCoroutine(AI());
        if(isHitting) StartCoroutine(Hitting()); else hs.health += 0.05f;

        if(hs.health == 0)player.Die();
    }

    public IEnumerator Hitting(){
        
        isHitting = false;
        yield return new WaitForSeconds(1f); 
        hs.health -= 0.1f;        

    }
    
    private IEnumerator StartR(){
    yield return new WaitForSeconds(3f);
    canMove = true;

    }
    private IEnumerator AI(){

        yield return new WaitForSeconds(3f);
        if(canMove) transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x + Random.Range(-15,15),player.transform.position.y,player.transform.position.z + Random.Range(-15,15)), step);
        
        if(Vector3.Distance(transform.position, player.transform.position) < 20f){
            
           if(canMove) transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x + Random.Range(-60, -30),player.transform.position.y+ 30,player.transform.position.z + Random.Range(15, 30)), step);
            isHitting = true;
        }

    

    }
    
    public void Hit(){
        canMove = false;
        isHitting=false;
        myRb.AddForce((-Vector3.forward ) *5000);
        myRb.useGravity = true;
        myRb.mass = 200;
        StartCoroutine(Die());

    }

    public IEnumerator Die(){
        Instantiate(GameAssets.i.particles[1], this.transform.position, this.transform.rotation, this.transform);
        SoundManager.PlaySound(SoundManager.Sound.EXPLOSION,0.5f);
        yield return new WaitForSeconds(2f); 
        isDead = true;

    }
    

    
}
