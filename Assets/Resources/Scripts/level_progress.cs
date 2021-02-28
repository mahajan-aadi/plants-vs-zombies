using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class level_progress : MonoBehaviour
{
    [Tooltip("time in seconds")][SerializeField] float level_time;
    Slider myslider;
    bool level_finished = false;
    float progress;
    void Start()
    {
        myslider = GetComponent<Slider>();
        level_time = Options._lower(level_time);
    }
    void Update()
    {
        if (!level_finished) { change_time(); }       
    }
    void change_time()
    {
        float gone_time = Time.timeSinceLevelLoad;
        progress = gone_time / level_time;
        if (level_time > gone_time) { myslider.value = progress; }
        else 
        { 
            level_finished = true;
            FindObjectOfType<level_handler>()._level_finished();
            level_complete();
        }

    }
    public float _progress() { return progress; }
    void level_complete()
    {        
        spwanner[] all_spawners = FindObjectsOfType<spwanner>();
        foreach (spwanner current in all_spawners) { current._stop_spawn(); }        
    }
}
