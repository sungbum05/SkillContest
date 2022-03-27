using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : Enemy
{
    [Header("보스 개인 속성")]
    [SerializeField]
    Slider BossHpBar;

    [SerializeField]
    Text BossHpTxt;

    private void Start()
    {
        BossBasicSetting();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override IEnumerator Attack()
    {
        yield return null;
    }

    protected override void EnemyMove()
    {
        
    }

    protected override void EnemyPatton()
    {
        
    }

    void BossBasicSetting()
    {
        Hp = 500 * GameManager.Instance.Stage;

        BossHpTxt.text = this.gameObject.name;
        BossHpBar.maxValue = Hp;
        BossHpBar.value = BossHpBar.maxValue;
    }

}
