using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    void Start()
    {
        StartCoroutine(spawn_enemies());
    }
    IEnumerator spawn_enemies()
    {
        var rot = Quaternion.identity;
        while (true)
        {
            yield return (new WaitForSeconds(5f));
            var pos = transform.position;
            float posy = transform.position.y;
            if (posy < 2) { Instantiate(enemy, pos + new Vector3(0, 1, 0), rot); }
            if (posy > -2) { Instantiate(enemy, pos + new Vector3(0, -1, 0), rot); }
            Instantiate(enemy, pos + new Vector3(1, 0, 0), rot);
            Instantiate(enemy, pos + new Vector3(-1, 0, 0), rot);            
        }
    }
    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
