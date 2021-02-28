using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulb : MonoBehaviour
{
    float speed = 10f;
    int damage=500;
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<attacker>() != null) { collision.GetComponent<health>()._decrease_health(damage); }
    }
}
