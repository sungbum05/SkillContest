using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    protected virtual void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("asd");
            ItemEffect(other.gameObject);
            Destroy(this.gameObject.transform.parent.gameObject);
        }
    }

    protected virtual void Update()
    {
        this.gameObject.transform.Rotate(0, 90 * Time.deltaTime, 0);
    }

    protected virtual void ItemEffect(GameObject Player)
    {

    }
}
