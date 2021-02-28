using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class life_text : MonoBehaviour
{
    Text lifetext;
    [SerializeField]float life = 5;
    void Start()
    {
        life = Mathf.Floor(Options._higher(life));
        lifetext = GetComponent<Text>();
        lifetext.text = life.ToString();
    }

    public void _reduce_life()
    {
        if (life > 0)
        {
            life--;
            lifetext.text = life.ToString();
        }
    }
    public bool _check_life()
    {
        if (life > 0){ return true; }
        return false;
    }

}
