using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lizard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject target = collision.gameObject;
        if (target.tag == "defenders")
        {
            GetComponent<attacker>()._attack(target);
        }
    }
}
