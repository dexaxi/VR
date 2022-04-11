using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyScript : MonoBehaviour
{
    public int score;
    public int difficulty;
    private void Awake() {
        difficulty = 1;
        DontDestroyOnLoad(this);
    }
    
    private void Start() {

    }
      
}
