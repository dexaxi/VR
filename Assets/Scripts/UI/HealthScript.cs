using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] [Range(0,100)]public float health;
    public float totalHealth;
    Scrollbar scrollbar;
    void Start()
    {
        health = 100;
        totalHealth = health;
        scrollbar = GetComponent<Scrollbar>();
    }

    // Update is called once per frame
    void Update()
    {
        scrollbar.size = health/100f;

        if(health > 100) health =  100;
        else if(health > 50) {
             ColorBlock cb = scrollbar.colors;
            cb.normalColor = Color.green;
             scrollbar.colors = cb;
        } 
       else  if(health < 50) {
             ColorBlock cb = scrollbar.colors;
            cb.normalColor = Color.yellow;
             scrollbar.colors = cb;
        } 
        if(health < 25) {
             ColorBlock cb = scrollbar.colors;
            cb.normalColor = Color.red;
             scrollbar.colors = cb;
        } if(health < 0) health = 0;
    }
}
