using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreScript : MonoBehaviour
{

    public int score;
    TextMeshProUGUI text;
    
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        score = 0;
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        score ++;
        text.text = score.ToString();
    }
}
