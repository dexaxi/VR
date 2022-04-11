using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    public int enemyCount;
    public int maxEnemyCount;
    public GameObject enemyRef;
    public EnemyBehaviour[] behaviours;
    public GameObject player;

    private void Awake() {
        enemyCount = 0;
        maxEnemyCount = 3;
        
    }

    // Update is called once per frame
    void Update()
    {
        behaviours = FindObjectsOfType<EnemyBehaviour>();
        if(enemyCount < 3 && Random.Range(0, 150) == 3) {
            
            Instantiate(enemyRef, new Vector3(player.transform.position.x - 10, player.transform.position.y, player.transform.position.z), player.transform.rotation);
            enemyCount++;

        }

        for(int i = 0;i < behaviours.Length;i++ ){

            if(behaviours[i].isDead){
                Debug.Log("Done");
                Destroy(behaviours[i].gameObject);
                enemyCount--;
            }

        }
    }


}
