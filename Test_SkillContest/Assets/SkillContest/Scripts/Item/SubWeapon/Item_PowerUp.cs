using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_PowerUp : Item
{
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
        Player.GetComponent<PlayerController>().WeaponCnt++;
        Player.GetComponent<PlayerController>().UpGradeWeapon[Player.GetComponent<PlayerController>().WeaponCnt - 1].transform.GetChild(0).gameObject.SetActive(true);
    }
}
