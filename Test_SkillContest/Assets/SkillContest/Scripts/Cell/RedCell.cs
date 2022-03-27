using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCell : Cell
{
    public bool PainUpChk = false;

    private void Start()
    {
        Hp = 30;
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void CellEffct()
    {
        if(PainUpChk == true)
            GameManager.Instance.Pain += 10;
    }
}
