using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defenders : MonoBehaviour
{
    GameObject defender;
    int cost;
    private void OnMouseDown()
    {
        if (defender != null) { spawn_defender(); }    
    }
    public void _set_defender(GameObject defender,int cost) { this.defender = defender; this.cost = cost; }
    void spawn_defender()
    {
        Instantiate(defender,get_location(),Quaternion.identity);
        after_instantiate();
    }
    Vector2 get_location()
    {
        Vector2 local_pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 world_pos = Camera.main.ScreenToWorldPoint(local_pos);
        Vector2 rounded_pos = round(world_pos);
        return rounded_pos;
    }
    Vector2 round(Vector2 roundvalue)
    {
        Vector2 rounded;
        rounded.x = Mathf.RoundToInt(roundvalue.x);
        rounded.y = Mathf.RoundToInt(roundvalue.y);
        return rounded;
    }
    void after_instantiate()
    {
        defender = null;
        FindObjectOfType<Score_text>()._reduce_score(cost);

    }
}
