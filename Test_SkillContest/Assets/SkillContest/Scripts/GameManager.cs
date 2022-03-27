using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region ÀÎ½ºÅÏ½º »ý¼º
    private static GameManager instance;

    public static GameManager Instance { 
        get
        {
            if(!instance)
            {
                instance = FindObjectOfType(typeof(GameManager)) as GameManager;
            }

            return instance;
        } 
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;

        else if(instance != this)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    #endregion

    public int Stage = 1;
    public int Pain = 0;

    [Header("¾À °´Ã¼")]
    public EnemySpanwer enemySpanwer;
    public PlayerController Player;

    [Header("UI °´Ã¼")]
    public Slider HpSlider;
    public Slider PainSlider;
    public Slider ProgressSlider;

    public Text HpText;
    public Text PainText;
    public Text ProgressText;

    // Start is called before the first frame update
    void Start()
    {
        BasicSetting();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentState();
    }

    public IEnumerator SendEnemyData()
    {
        enemySpanwer.ReadEnemyData(
            Resources.Load<TextAsset>($"Stage{Stage}/EnemyPatton_{Random.Range(1,7)}").text);

        yield return new WaitForSeconds(15.0f);

        StartCoroutine(SendEnemyData());
    }
    
    void BasicSetting()
    {
        switch(Stage)
        {
            case 1:
                Pain = 10;
                break;

            case 2:
                Pain = 30;
                break;
        }

        enemySpanwer = FindObjectOfType(typeof(EnemySpanwer)) as EnemySpanwer;
        Player = FindObjectOfType(typeof(PlayerController)) as PlayerController;

        HpSlider = GameObject.Find("HpSlider").gameObject.GetComponent<Slider>();
        PainSlider = GameObject.Find("PainSlider").gameObject.GetComponent<Slider>();
        ProgressSlider = GameObject.Find("ProgressSlider").gameObject.GetComponent<Slider>();

        HpText = GameObject.Find("HpTxt").gameObject.GetComponent<Text>();
        PainText = GameObject.Find("PainTxt").gameObject.GetComponent<Text>();
        ProgressText = GameObject.Find("ProgressTxt").gameObject.GetComponent<Text>();

        HpSlider.value = Player.HP;
        PainSlider.value = Pain;
        ProgressSlider.maxValue = 5000;
        ProgressSlider.value = Player.transform.position.z;
    }

    void CurrentState()
    {
        HpText.text = $"HP : {Player.HP}";
        PainText.text = $"PAIN : {Pain}";
        ProgressText.text = $"{System.Math.Truncate((ProgressSlider.value/ProgressSlider.maxValue) * 100)} %";

        HpSlider.value = GotoValue(HpSlider.value, Player.HP);
        PainSlider.value = GotoValue(PainSlider.value, Pain);
        ProgressSlider.value = Player.transform.position.z;
    }

    float GotoValue(float Value, float TargetValue)
    {
        if(Value > TargetValue)
        {
            Value -= 20 * Time.deltaTime;
        }

        else if(Value < TargetValue)
        {
            Value += 20 * Time.deltaTime;
        }

        return Value;
    }
}
