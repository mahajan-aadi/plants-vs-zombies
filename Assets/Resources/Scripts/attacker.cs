using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attacker : MonoBehaviour
{
    [Range(0f, 4f)] [SerializeField] float speed;
    GameObject current_target;
    Animator myanimation;
    private void Awake()
    {
        FindObjectOfType<level_handler>()._increase_attackers();
    }
    private void OnDestroy()
    {
        level_handler level= FindObjectOfType<level_handler>();
        if (level != null) { level._decrease_attackers(); }

    }
    private void Start()
    {
        myanimation = GetComponent<Animator>();
    }
    void Update()
    {
        transform.Translate(Vector2.left*speed*Time.deltaTime);
        update_animation();
    }

    private void update_animation()
    {
        if (!current_target) { myanimation.SetBool("is_attacking", false); }
    }

    void set_speed(float speed)
    {
        this.speed = speed;
    }
    public void _attack(GameObject target)
    {
        current_target = target;
        myanimation.SetBool("is_attacking", true);
    }
    void attack_player(int health)
    {
        current_target.GetComponent<health>()._decrease_health(health);
    }
}
