using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : Enemy
{
    [SerializeField]
    GameObject FirePos;

    [SerializeField]
    Transform target;

    [SerializeField]
    List<Transform> MaxShotCnt;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
        DownFreeze();

        target = GameObject.Find("Player").transform;
    }

    protected override IEnumerator Attack()
    {
        GetTarget();

        foreach(Transform T in FirePos.transform)
        {
            MaxShotCnt.Add(T);
        }

        yield return null;
        
        while(true)
        {
            yield return new WaitForSeconds(AttackDelay);

            AttackRange = Vector3.Distance(this.gameObject.transform.position, Target.position);

            if (AttackRange < 700 && FreezeTime <= 0)
            {
                for (int i = 0; i < ShotCnt; i++)
                {
                    GameObject Bullet = Instantiate(EnemyBullet, this.gameObject.transform.position, EnemyBullet.transform.rotation);
                    Bullet.GetComponent<EnemyBullet>().BulletPower = AttckPower;
                    Bullet.transform.position = MaxShotCnt[i].position;

                    Bullet.transform.LookAt(Target);

                    StartCoroutine(StartAttck(Bullet));
                }

                if (ShotCnt >= MaxShotCnt.Count)
                    ShotCnt = 1;

                else
                    ShotCnt += 2;
            }
        }
    }

    IEnumerator StartAttck(GameObject Bullet)
    {
        yield return new WaitForSeconds(AttackDelay / MaxShotCnt.Count);

        Bullet.GetComponent<Rigidbody>().AddForce(Bullet.transform.forward * BulletSpeed, ForceMode.Impulse);
        StopCoroutine(StartAttck(Bullet));
    }

    protected override void EnemyMove()
    {
        base.EnemyMove();
    }

    protected override void EnemyPatton()
    {
        
    }
}
