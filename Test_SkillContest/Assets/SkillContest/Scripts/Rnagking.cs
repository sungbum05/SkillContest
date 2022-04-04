using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rnagking : MonoBehaviour
{
    public InputField input;
    public Text txt;

    // Start is called before the first frame update
    public void ChangeTxt()
    {
        txt.text = input.text;
    }
}
