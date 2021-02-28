using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class defender_selector : MonoBehaviour
{
    [SerializeField] GameObject button;
    [SerializeField] int cost;
    [Tooltip("time in seconds")] [SerializeField] float cool_time;
    bool cool = true;
    float cutting_time;
    float checking_time;
    Text cost_text;
    private void Start()
    {
        cost_text = GetComponentInChildren<Text>();
        cost_text.text = cost.ToString();
        cool_time = Options._lower(cool_time);
    }
    private void OnMouseDown()
    {
        if (FindObjectOfType<Score_text>()._check_score(cost) && cool)
        {
            fading();
            FindObjectOfType<defenders>()._set_defender(button,cost);
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
    public void _start_shading()
    {
        cool = false;
        StartCoroutine(uncool());
    }

    IEnumerator uncool()
    {
        cutting_time = Time.time;
        while (!cool)
        {
            checking_time = Time.time - cutting_time;
            if (checking_time < cool_time)
            {
                int color_code = (int)Mathf.Floor((checking_time / cool_time * 92));
                byte color = BitConverter.GetBytes(color_code)[0];
                GetComponent<SpriteRenderer>().color = new Color32(color,color,color,255);
                yield return (new WaitForSeconds(1f));
            }
            else { StartCoroutine(end_wait()); }
        }
    }
    IEnumerator end_wait()
    {
        cool = true;
        GetComponent<SpriteRenderer>().color = Color.white;
        yield return (new WaitForSeconds(0.1f));
        GetComponent<SpriteRenderer>().color = new Color32(92, 92, 92, 255);
        StopAllCoroutines();
    }

    void fading()
    {
        var defenders = FindObjectsOfType<defender_selector>();
        foreach (defender_selector defender in defenders)
        {
            defender.GetComponent<SpriteRenderer>().color = new Color32(92, 92, 92, 255);
        }
    }
}
