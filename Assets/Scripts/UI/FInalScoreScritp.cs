using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FInalScoreScritp : MonoBehaviour
{

    public int score;
    TextMeshProUGUI text;

    DifficultyScript settings;

    private void Awake() {
        text = GetComponent<TextMeshProUGUI>();
        settings = FindObjectOfType<DifficultyScript>();
    }
    // Start is called before the first frame update
    void Start()
    {
        text.text = settings.score.ToString();
    }

}
