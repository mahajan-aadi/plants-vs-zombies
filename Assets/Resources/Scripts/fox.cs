using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject target = collision.gameObject;
        if (target.GetComponent<gravestone>()) { GetComponent<Animator>().SetTrigger("is_jumping"); }
        else if (target.tag == "defenders")
        {
            GetComponent<attacker>()._attack(target);
        }
    }
}
