using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFollows : MonoBehaviour
{
    public GameObject Player;
    public int BulletZone;
    bool moving;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Manager.OnNextZone.AddListener(OnChangeZone);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(moving)
        {
            // Vector3.MoveTowards(this, Player.GetComponent, 0.25f);
        }
    }

    void OnChangeZone(int newZone) {
        if(newZone == BulletZone)
        {
            moving = true;
        }
    }
}
