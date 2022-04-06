using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingMgr : MonoBehaviour
{
    public List<RankingData> RankingDatas;
    public GameObject Input;

    public int Score = 10000;

    private static RankingMgr instance;
    public static RankingMgr Instance
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType(typeof(RankingMgr)) as RankingMgr;
            }

            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        ListSort();

        if (RankingDatas[RankingDatas.Count - 1].Score < Score)
        {
            Input.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ListSort()
    {
        int k = 0;

        for (int i = 0; i < RankingDatas.Count - 1; i++)
        {
            for (int j = 0; j < RankingDatas.Count - i - 1; j++)
            {
                if (RankingDatas[j].Score <= RankingDatas[j + 1].Score)
                {
                    string TempName = RankingDatas[j].UserName;
                    int TempScore = RankingDatas[j].Score;

                    RankingDatas[j].UserName = RankingDatas[j + 1].UserName;
                    RankingDatas[j].Score = RankingDatas[j + 1].Score;

                    RankingDatas[j + 1].UserName = TempName;
                    RankingDatas[j + 1].Score = TempScore;
                }
            }
        }
    }
}
