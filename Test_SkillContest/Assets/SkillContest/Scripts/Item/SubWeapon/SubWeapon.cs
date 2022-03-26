using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubWeapon : MonoBehaviour
{
    [SerializeField]
    float Delay;

    [SerializeField]
    bool Attack = true;

    [SerializeField]
    List<GameObject> Enemys;
    [SerializeField]
    GameObject JetBullet;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OnAttack();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Enemys.Add(other.gameObject);
        }
    }

    private void OnAttack()
    {
        if(Enemys.Count > 0 && Attack == true)
        {
            Attack = false;

            StartCoroutine(StartAttack());
        }
    }

    IEnumerator StartAttack()
    {
        int Ran = Random.Range(0, Enemys.Count);
        bool TargetChk = true;

        if(!Enemys[Ran])
        {
            Enemys.RemoveAt(Ran);
            TargetChk = false;
        }

        yield return new WaitForSeconds(0.05f);

        if (TargetChk == true)
        {
            GameObject Target = Enemys[Ran];

            yield return new WaitForSeconds(Delay - Random.Range(0.1f, 0.25f));

            GameObject Bullet = Instantiate(JetBullet, this.gameObject.transform.position, JetBullet.transform.rotation);
            Bullet.GetComponent<PlayerBullet>().PlayerBulletPower = 5;

            Bullet.GetComponent<PlayerBullet>().BasicSetting(true, Target);
        }

        StartCoroutine(StartAttack());
    }
}
