using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_GameManager : MonoBehaviour
{
    public Test_PlayerControllet Player;

    public Test_EnemySpanwer EnemySpanwer;

    public int Stage = 1;

    #region instance생성
    private static Test_GameManager instance;

    public static Test_GameManager INSTANCE
    {
        get
        {
            if(!instance)
            {
                instance = FindObjectOfType(typeof(Test_GameManager)) as Test_GameManager;
            }

            return instance;
        }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        else if(instance != this)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
        #endregion

        //Awake함수 가려짐
        Player = FindObjectOfType(typeof(Test_PlayerControllet)) as Test_PlayerControllet;
        EnemySpanwer = FindObjectOfType(typeof(Test_EnemySpanwer)) as Test_EnemySpanwer;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator SendPattonData()
    {
        yield return null;

        EnemySpanwer.ReadPattonData(Resources.Load<TextAsset>($"Test/Stage_{Stage}/Patton_{1}").text);

        yield return new WaitForSeconds(17.0f);

        StartCoroutine(SendPattonData());
    }
}
