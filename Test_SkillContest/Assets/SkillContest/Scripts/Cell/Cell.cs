using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public int Hp;

    public int MoveSpeed;

    protected virtual void Update()
    {
        if (Hp <= 0)
        {
            CellEffct();
            Destroy(this.gameObject);
        }

        this.gameObject.transform.Translate(0, 0, -MoveSpeed * Time.deltaTime);
    }

    protected virtual void CellEffct()
    {

    }
}
