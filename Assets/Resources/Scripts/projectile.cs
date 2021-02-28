﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int damage;
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        attacker enemy = collision.GetComponent<attacker>();
        if (enemy != null) 
        {
            collision.GetComponent<health>()._decrease_health(damage); 
            Destroy(this.gameObject); 
        }
    }
}
