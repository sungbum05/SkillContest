using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            GameManager.Instance.Pain += other.gameObject.GetComponent<Enemy>().AttckPower / 2;
            Destroy(other.gameObject);
        }
    }
}
