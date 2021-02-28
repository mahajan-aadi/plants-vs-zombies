using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reduce_life : MonoBehaviour
{
    Load_level level_loader;
    life_text life_handler;
    void Start()
    {
        level_loader = FindObjectOfType<Load_level>();
        life_handler = FindObjectOfType<life_text>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        life_handler._reduce_life();
        bool lives_available = life_handler._check_life();
        if (!lives_available) { level_loader._lose(); }
    }
}
