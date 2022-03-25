using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public int PlayerBulletPower = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Ok");

            Attack(PlayerBulletPower, other.gameObject);
            DestroyBullet();
        }

        if(other.gameObject.CompareTag("EnemyBullet"))
        {
            other.GetComponent<Bullet>().HP--;
            DestroyBullet();
        }
    }


    void Attack(int AttackPower, GameObject Enemy)
    {
        Enemy.GetComponent<Enemy>().Hp -= AttackPower;
    }

    void DestroyBullet()
    {
        Destroy(this.gameObject);
    }
}
