using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Germ : Enemy
{

    [Header("Germ 고유 속성")]
    [SerializeField] GameObject Shield;

    [SerializeField] GameObject ShieldForm;
    [SerializeField] GameObject GunForm;

    [SerializeField] List<Transform> FirePos;

    // Start is called before the first frame update
    void Start()
    {
        Hp = 30;
        ShieldCnt = 1;

        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
        EnemyPatton();
    }

    protected override IEnumerator Attack()
    {
        base.GetTarget();

        while(true)
        {
            AttackRange = Vector3.Distance(this.gameObject.transform.position, Target.position); 

            yield return null;
            if (ShieldCnt <= 0 && AttackRange <= 500 && FreezeTime <= 0)
            {
                foreach (Transform Pos in FirePos)
                {
                    yield return new WaitForSeconds(AttackDelay);

                    GameObject Bullet = Instantiate(EnemyBullet, Pos.position, EnemyBullet.transform.rotation);
                    Bullet.GetComponent<Rigidbody>().AddForce((-1 * Bullet.transform.forward) * BulletSpeed, ForceMode.Impulse);
                    Bullet.GetComponent<EnemyBullet>().BulletPower = AttckPower;
                }
            }
        }
    }

    protected override void EnemyMove()
    {
        this.gameObject.transform.Translate(0,0,-MoveSpeed * Time.deltaTime);
    }

    protected override void EnemyPatton()
    {
        if (ShieldCnt > 0)
        {
            ShieldForm.SetActive(true);
            GunForm.SetActive(false);

            Shield.transform.Rotate(0, 90 * Time.deltaTime, 0);
        }

        else
        {
            ShieldForm.SetActive(false);
            GunForm.SetActive(true);
        }
    }
}
