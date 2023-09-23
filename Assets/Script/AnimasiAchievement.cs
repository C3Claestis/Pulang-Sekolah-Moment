using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimasiAchievement : MonoBehaviour
{
    public bool[] _Penghargaan = new bool[15];
    float _Waktu;
    [SerializeField] GameObject _AnimasiAchievement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Mathf.Clamp(_Waktu, 0, 20);

        if(_Penghargaan[0] == true)
        {
            if(PlayerPrefs.GetInt("Achievement-0") == 1)
            {
                _Waktu += Time.deltaTime;

                if(_Waktu > 10)
                {
                    _AnimasiAchievement.SetActive(false);
                }
            }
        }
        if (_Penghargaan[1] == true)
        {
            if (PlayerPrefs.GetInt("Achievement-1") == 1)
            {
                _Waktu += Time.deltaTime;

                if (_Waktu > 10)
                {
                    _AnimasiAchievement.SetActive(false);
                }
            }
        }
        if (_Penghargaan[2] == true)
        {
            if (PlayerPrefs.GetInt("Achievement-2") == 1)
            {
                _Waktu += Time.deltaTime;

                if (_Waktu > 10)
                {
                    _AnimasiAchievement.SetActive(false);
                }
            }
        }
        if (_Penghargaan[3] == true)
        {
            if (PlayerPrefs.GetInt("Achievement-3") == 1)
            {
                _Waktu += Time.deltaTime;

                if (_Waktu > 10)
                {
                    _AnimasiAchievement.SetActive(false);
                }
            }
        }
        if (_Penghargaan[4] == true)
        {
            if (PlayerPrefs.GetInt("Achievement-4") == 1)
            {
                _Waktu += Time.deltaTime;

                if (_Waktu > 10)
                {
                    _AnimasiAchievement.SetActive(false);
                }
            }
        }
        if (_Penghargaan[5] == true)
        {
            if (PlayerPrefs.GetInt("Achievement-5") == 1)
            {
                _Waktu += Time.deltaTime;

                if (_Waktu > 10)
                {
                    _AnimasiAchievement.SetActive(false);
                }
            }
        }
        if (_Penghargaan[6] == true)
        {
            if (PlayerPrefs.GetInt("Achievement-6") == 1)
            {
                _Waktu += Time.deltaTime;

                if (_Waktu > 10)
                {
                    _AnimasiAchievement.SetActive(false);
                }
            }
        }
        if (_Penghargaan[7] == true)
        {
            if (PlayerPrefs.GetInt("Achievement-7") == 1)
            {
                _Waktu += Time.deltaTime;

                if (_Waktu > 10)
                {
                    _AnimasiAchievement.SetActive(false);
                }
            }
        }
        if (_Penghargaan[8] == true)
        {
            if (PlayerPrefs.GetInt("Achievement-8") == 1)
            {
                _Waktu += Time.deltaTime;

                if (_Waktu > 10)
                {
                    _AnimasiAchievement.SetActive(false);
                }
            }
        }
        if (_Penghargaan[9] == true)
        {
            if (PlayerPrefs.GetInt("Achievement-9") == 1)
            {
                _Waktu += Time.deltaTime;

                if (_Waktu > 10)
                {
                    _AnimasiAchievement.SetActive(false);
                }
            }
        }

        if (_Penghargaan[11] == true)
        {
            if (PlayerPrefs.GetInt("Achievement-11") == 1)
            {
                _Waktu += Time.deltaTime;

                if (_Waktu > 10)
                {
                    _AnimasiAchievement.SetActive(false);
                }
            }
        }

        if (_Penghargaan[14] == true)
        {
            if (PlayerPrefs.GetInt("Achievement-9") == 1)
            {
                _Waktu += Time.deltaTime;

                if (_Waktu > 10)
                {
                    _AnimasiAchievement.SetActive(false);
                }
            }
        }
    }
}
