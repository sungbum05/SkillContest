using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    public int BulletPower;

    private void Start()
    {
        HP = 2;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().HP -= BulletPower;
            Destroy(this.gameObject);
        }
    }
}
