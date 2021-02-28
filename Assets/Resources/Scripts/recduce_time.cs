using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recduce_time : MonoBehaviour
{
    [SerializeField] defender_selector my_icon;
    void Awake()
    {
        defender_selector[] defenders = FindObjectsOfType<defender_selector>();
        foreach(defender_selector defender in defenders)
        {
            if (my_icon.name == defender.name) { defender._start_shading(); }
        }
    }
}
