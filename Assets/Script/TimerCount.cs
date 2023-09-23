using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class TimerCount : MonoBehaviour
{
    Text teks;
    [SerializeField] public float _TimerAwal;
    [HideInInspector] public bool Kondisi;
    [SerializeField] GameObject _TeksSetengah, _BoxDest, _Sfx;    
    public GameObject[] _DuitSpawn = new GameObject[3];
    float _setengah, _TimeSet;        
    // Start is called before the first frame update
    void Start()
    {        
        teks = GetComponent<Text>();
        _setengah = _TimerAwal * 1 / 2;
    }

    // Update is called once per frame
    void Update()
    {
        //Audio
        if (PlayerPrefs.GetInt("Music") == 1) { _Sfx.GetComponent<AudioSource>().mute = true; }
        else { _Sfx.GetComponent<AudioSource>().mute = false; }

        teks.text = _TimerAwal.ToString("0");
       
        if (Kondisi != true)
        {
            _TimerAwal -= Time.deltaTime;            
        }            

        if (_TimerAwal <= _setengah)
        {
            _TimeSet += 0.01f;
            Kondisi = true;
            _TeksSetengah.SetActive(true);
            _Sfx.SetActive(true);
            _BoxDest.SetActive(true);
            _DuitSpawn[0].SetActive(true);
            _DuitSpawn[1].SetActive(true);
            _DuitSpawn[2].SetActive(true);

            if (_TimeSet > 3.5f)
            {
                _BoxDest.SetActive(false);
                _DuitSpawn[0].SetActive(false);
                _DuitSpawn[1].SetActive(false);
                _DuitSpawn[2].SetActive(false);
                Kondisi = false;
            }        
        }                             
    }
}