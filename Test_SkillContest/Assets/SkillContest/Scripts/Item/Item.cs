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
            Destroy(this.gameObject);
        }
    }

    protected virtual void ItemEffect(GameObject Player)
    {

    }
}
