using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyATBullet : MonoBehaviour
{
    public int BulletPower;

    public Transform PlayerTr;
    public Rigidbody ballrigid;
    public float turn;
    public float ballvelocity;

    // Start is called before the first frame update

    // Update is called once per frame
    public void FixedUpdate()
    {
        ballrigid.velocity = transform.forward * ballvelocity;
        var ballTargetRotation = Quaternion.LookRotation(PlayerTr.position + new Vector3(0, 0, 8.0f) - transform.position);
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
