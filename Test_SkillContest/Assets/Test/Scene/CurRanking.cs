using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurRanking : MonoBehaviour
{
    public List<Text> RankingTxt;
    public InputField InputField;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;

        foreach(RankingData Data in RankingMgr.Instance.RankingDatas)
        {
            RankingTxt[i].text = $"{i + 1}À§: {Data.UserName}({Data.Score}Á¡)";
            i++;
        }
    }

    public void InputUserName()
    {
        RankingMgr.Instance.RankingDatas[4].UserName = InputField.text;
        RankingMgr.Instance.RankingDatas[4].Score = RankingMgr.Instance.Score;

        RankingMgr.Instance.ListSort();

        InputField.gameObject.SetActive(false);
    }
}
