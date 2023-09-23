using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerMainGame : MonoBehaviour
{
    public Count _Money;    
    [SerializeField] bool _End;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Money", Gamemanager.Money += _Money._MoneyCount);

        if(_End==true)
        {
            PlayerPrefs.SetInt("Endless", 1);
        }
    }
}
