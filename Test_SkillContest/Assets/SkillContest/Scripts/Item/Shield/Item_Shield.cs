using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Shield : Item
{
    [SerializeField]
    GameObject Player;

    protected override void Update()
    {
        base.Update();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }

    protected override void ItemEffect(GameObject Player)
    {
        Player = GameObject.Find("Player").gameObject;
        Player.GetComponent<PlayerController>().ShieldTime = 3.0f;
    }
}
