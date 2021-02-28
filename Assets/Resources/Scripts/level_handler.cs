using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level_handler : MonoBehaviour
{
    int attackers=0;
    bool level_finished=false;
    
    void level_complete()
    {
        if(attackers==0 && level_finished)
        {
            FindObjectOfType<Load_level>()._win();
        }
    }
    public void _increase_attackers() { attackers++; }
    public void _decrease_attackers() { attackers--; level_complete(); }

    public void _level_finished() { level_finished = true; }
    public void _level_lost() { level_finished = false; }
}
