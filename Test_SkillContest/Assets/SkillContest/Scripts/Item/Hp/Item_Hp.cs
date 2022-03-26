using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Hp : Item
{
    int MaxHp = 100;

    [SerializeField]
    int HealCnt = 20;

    [SerializeField]
    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

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
        Player.GetComponent<PlayerController>().HP += HealCnt;

        if(Player.GetComponent<PlayerController>().HP >= MaxHp)
        {
            Player.GetComponent<PlayerController>().HP = MaxHp;
        }
    }
}
