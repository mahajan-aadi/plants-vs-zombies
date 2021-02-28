using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    [SerializeField] GameObject projetile;
    Animator my_animator;
    spwanner myspawnner;
    private void Update()
    {
        check_enemies();   
    }
    private void Start()
    {
        my_animator = GetComponent<Animator>();
        check_my_lane();       
    }
    void check_enemies()
    {
        if (myspawnner.transform.childCount > 0) { my_animator.SetBool("start_attacking", true); }
        else { my_animator.SetBool("start_attacking", false); }
    }
    void check_my_lane()
    {
        spwanner[] all_spawnners = FindObjectsOfType<spwanner>();
        foreach(spwanner spawnner in all_spawnners)
        {
            if (Mathf.Abs(spawnner.transform.position.y - transform.position.y)
                <= Mathf.Epsilon) { myspawnner = spawnner; }
        }
    }
    void fire()
    {
        Instantiate(projetile, transform.position + new Vector3 (0.3f, 0.3f, 0), transform.rotation);
    }
}
