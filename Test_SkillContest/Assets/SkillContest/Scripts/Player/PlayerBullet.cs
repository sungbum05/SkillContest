using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public int PlayerBulletPower = 0;

    public GameObject Target;
    public bool StartFire = false;
    public bool TargetChk = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Target)
            DestroyBullet();

        if (StartFire == true && Target)
        {
            Fire(Target);
            StartFire = false;
        }
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

    public void BasicSetting(bool FireChk, GameObject Enemy)
    {
        StartFire = FireChk;
        Target = Enemy;
    }


    void Fire(GameObject Target)
    {
        this.gameObject.transform.LookAt(Target.transform);
        this.gameObject.GetComponent<Rigidbody>().AddForce(this.gameObject.transform.forward * 300, ForceMode.Impulse);
    }

    void HomingFire(GameObject Target)
    {
        if (Target = null)
            DestroyBullet();

        this.gameObject.transform.LookAt(Target.transform);
        this.gameObject.GetComponent<Rigidbody>().velocity = this.gameObject.transform.forward * 150;
    }
}
