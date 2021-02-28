using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class star : MonoBehaviour
{
    Score_text score;
    private void Start()
    {
        score = FindObjectOfType<Score_text>();
    }
    void increase_score(int value)
    {
        score._update_score(value);
    }
}
