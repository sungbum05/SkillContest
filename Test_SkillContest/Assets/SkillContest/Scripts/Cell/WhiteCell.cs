using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteCell : Cell
{
    public GameObject[] Item;

    private void Start()
    {
        Hp = 30;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void CellEffct()
    {
        int Ran = Random.Range(0, Item.Length);
        Instantiate(Item[Ran], this.gameObject.transform.position, Item[Ran].transform.rotation);
    }
}
