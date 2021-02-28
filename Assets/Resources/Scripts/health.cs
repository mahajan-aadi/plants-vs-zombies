using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    [SerializeField] float remaining_health = 100;
    GameObject death;
    private void Start()
    {
        death = Resources.Load<GameObject>("VFX/Explosion VFX");
        if (GetComponent<attacker>() != null)
        { 
            remaining_health = Options._lower(remaining_health);
            remaining_health = (FindObjectOfType<level_progress>()._progress() + 1) * remaining_health;
        }
        else { remaining_health = Options._higher(remaining_health); }
    }
    public void _decrease_health(float damage)
    {
        if (GetComponent<attacker>() != null) { damage =Options._higher(damage); }
        else { damage = Options._lower(damage); }
        
        remaining_health -= damage;
        if (remaining_health <= 0)
        {
            GameObject death_vfx = Instantiate(death,transform.position, Quaternion.identity);
            Destroy(death_vfx, 1f);
            Destroy(this.gameObject);
        }
    }
}
