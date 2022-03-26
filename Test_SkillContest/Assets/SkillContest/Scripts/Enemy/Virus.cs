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

            for (int i = 0; i < ShotCnt; i++)
            {
                GameObject Bullet = Instantiate(EnemyBullet, this.gameObject.transform.position, EnemyBullet.transform.rotation);
                Bullet.GetComponent<EnemyBullet>().BulletPower = AttckPower;
                Bullet.transform.position = MaxShotCnt[i].position;

                Bullet.transform.LookAt(Target);

                StartCoroutine(StartAttck(Bullet));
            }

            Debug.Log(ShotCnt);

            if (ShotCnt >= MaxShotCnt.Count)
                ShotCnt = 1;

            else
                ShotCnt += 2;
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
        this.gameObject.transform.Translate(0, 0, -MoveSpeed * Time.deltaTime);
    }

    protected override void EnemyPatton()
    {
        
    }
}
