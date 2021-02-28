using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score_text : MonoBehaviour
{
    Text score_text;
    [SerializeField]int score = 200;
    void Start()
    {
        score_text = GetComponent<Text>();
        _update_score(0);
    }
    public void _update_score(int amount)
    {
        score += amount;
        score_text.text = score.ToString();
    }
    public void _reduce_score(int amount)
    {
        if (score >= amount)
        {
            score -= amount;
            score_text.text = score.ToString();
        }
    }
    public bool _check_score(int amount)
    {
        if (score >= amount){ return true; }
        return false;
    }

}
