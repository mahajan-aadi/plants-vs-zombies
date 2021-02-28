using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spwanner : MonoBehaviour
{
    [SerializeField] attacker [] enemies;
    [SerializeField]float lower_value, higher_value;
    [SerializeField]bool time_for_main = false;
    bool spawn = true;
    IEnumerator Start()
    {
        lower_value = Options._higher(lower_value);
        higher_value = Options._higher(higher_value);
        while (spawn)
        {
            float random_value = Random.Range(lower_value, higher_value);
            yield return new WaitForSeconds(random_value);
            int random_enemy = Random.Range(0, enemies.Length);
            attacker lane_attacker = (attacker)Instantiate(enemies[random_enemy],transform.position,transform.rotation);
            lane_attacker.transform.parent = transform;
            if(!time_for_main && Time.timeSinceLevelLoad > 120)
            {
                attacker _lane_attacker = (attacker)Instantiate(Resources.Load<attacker>("Prefabs/Ghost"), 
                    transform.position, transform.rotation);
                _lane_attacker.transform.parent = transform;
                time_for_main = true;
            }
        }
    }
    public void _stop_spawn() { spawn = false; }

}
