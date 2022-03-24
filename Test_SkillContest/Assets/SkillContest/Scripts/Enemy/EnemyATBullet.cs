using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyATBullet : MonoBehaviour
{
    public int BulletPower;
    public bool Fire = false;

    public Transform PlayerTr;
    public Rigidbody ballrigid;
    public float turn;
    public float ballvelocity;

    // Start is called before the first frame update
    private void Start()
    {
        PlayerTr = GameObject.Find("Player").transform;
    }

    private void OnDestroy()
    {
        Debug.Log("Destroy");
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        if(Fire == true)
        {
            //Debug.Log("Fire");
            FireBullet();
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

    public void FireBullet()
    {
        ballrigid.velocity = transform.forward * ballvelocity;
        var ballTargetRotation = Quaternion.LookRotation(PlayerTr.position + new Vector3(0, 0, 0.8f) - transform.position);
        ballrigid.MoveRotation(Quaternion.RotateTowards(transform.rotation, ballTargetRotation, turn));
    }

    public void ThisDestroy()
    {
        Destroy(this.gameObject, 5.0f);
    }
}
