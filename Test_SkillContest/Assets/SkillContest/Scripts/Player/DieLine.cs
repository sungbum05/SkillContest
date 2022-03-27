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

        if (other.gameObject.CompareTag("WhiteCell"))
        {
            other.gameObject.GetComponent<Cell>().Hp -= 10000;
        }

        if (other.gameObject.CompareTag("RedCell"))
        {
            other.gameObject.GetComponent<RedCell>().PainUpChk = false;
            other.gameObject.GetComponent<Cell>().Hp -= 10000;
        }
    }
}
