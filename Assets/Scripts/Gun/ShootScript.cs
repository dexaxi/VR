using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{

    public GameObject gunHand;
    public void Shoot(){
        SoundManager.PlaySound(SoundManager.Sound.GUNSHOT,0.3f);
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit)){

            Debug.Log(hit.transform.name);
             Debug.DrawLine (transform.position, hit.point,Color.red);
            if(hit.transform.gameObject.tag == "enemy") {
                Debug.Log("Die");
                hit.transform.gameObject.GetComponent<EnemyBehaviour>().Hit();
            }
        }
        

    }
    Collider[] colliders;

    private void Awake() {

        colliders = FindObjectsOfType<Collider>();

        for(int i = 0; i < colliders.Length; i++){    
            Physics.IgnoreCollision(this.GetComponent<Collider>(), colliders[i]);
        }
    }

    private void Update() {
        transform.parent = gunHand.transform;
    }
}
