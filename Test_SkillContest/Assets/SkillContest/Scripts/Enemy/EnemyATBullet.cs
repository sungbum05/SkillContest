using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyATBullet : Bullet
{
    public int BulletPower;

    public bool Fire = false;
    public bool IsHoming = false;

    public Rigidbody ballrigid;
    public float turn;
    public float ballvelocity;

    // Start is called before the first frame update
    private void Start()
    {
        PlayerTr = GameObject.Find("Player").transform;
        HP = 2;
    }

    private void OnDestroy()
    {
        Debug.Log("Destroy");
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        if (Fire == true)
        {
            //Debug.Log("Fire");
            StartCoroutine(FireBullet());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().HP -= BulletPower;
            Destroy(this.gameObject);
        }
    }

    public IEnumerator FireBullet()
    {
        yield return new WaitForSeconds(0.3f);

        this.gameObject.transform.LookAt(PlayerTr);
        this.gameObject.GetComponent<Rigidbody>().velocity = this.gameObject.transform.forward * ballvelocity;
    }

    public void ThisDestroy()
    {
        Destroy(this.gameObject, (Vector3.Distance(this.gameObject.transform.position, PlayerTr.position) / 60));

        Debug.Log(Vector3.Distance(this.gameObject.transform.position, PlayerTr.position) / 80);
    }
}
