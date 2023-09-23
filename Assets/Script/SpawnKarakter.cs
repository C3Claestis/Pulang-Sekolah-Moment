using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKarakter : MonoBehaviour
{
    [SerializeField] GameObject _AvaCowok, _AvaCewek;
    // Start is called before the first frame update
    void Awake()
    {
        if(PlayerPrefs.GetInt("Gender") == 1)
        {
            GameObject gameObject = Instantiate(_AvaCowok, transform.position, Quaternion.identity);
        }
        else
        {
            GameObject gameObject = Instantiate(_AvaCewek, transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
