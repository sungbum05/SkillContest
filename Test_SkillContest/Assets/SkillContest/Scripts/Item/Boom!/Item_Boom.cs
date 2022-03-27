using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Boom : Item
{
    [SerializeField]
    GameObject[] Target;

    protected override void Update()
    {
        base.Update();

        Target = GameObject.FindGameObjectsWithTag("Enemy");
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }

    protected override void ItemEffect(GameObject Player)
    {
        Player.GetComponent<PlayerController>().BoomTime = 3.0f;

        foreach (GameObject Enemy in Target)
        {
            Enemy.gameObject.GetComponent<Enemy>().Hp -= 100;
        }
    }
}
