using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoneyManagement : MonoBehaviour
{
    public static int _DuitSekarang;
    [SerializeField] Text duit;
    // Start is called before the first frame update
    void Start()
    {
        _DuitSekarang = PlayerPrefs.GetInt("Money");
    }

    // Update is called once per frame
    void Update()
    {
        duit.text = _DuitSekarang.ToString();
    }
}
