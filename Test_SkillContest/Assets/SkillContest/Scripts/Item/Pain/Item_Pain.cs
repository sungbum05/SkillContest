using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Pain : Item
{
    int MinPain = 0;

    [SerializeField]
    int PainCnt = 10;

    // Update is called once per frame
    void Update()
    {

    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }

    protected override void ItemEffect(GameObject Player)
    {
        GameManager.Instance.Pain -= PainCnt;

        if (GameManager.Instance.Pain <= MinPain)
        {
            GameManager.Instance.Pain = MinPain;
        }
    }
}
