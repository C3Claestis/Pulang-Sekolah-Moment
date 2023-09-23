using UnityEngine;
using UnityEngine.UI;
public class AchievementManager : MonoBehaviour
{
    [SerializeField] public int _NumberAchievement;
    TimerCount _timer;
    public bool[] _Penghargaan = new bool[4];

    //Penghargaan 2    
    public bool _No1, _No3, _No4, _No6, _No7, _No8, _No11, _No14;
    Player _player;
    Count _Bulletcount, _CoinCount;    

    [SerializeField] private Animator _Animasi;
    [SerializeField] private Text _text;
    [SerializeField] private EndlessManager _endlessManager;
    [SerializeField] private GameObject _Sfx;
    // Start is called before the first frame update
    void Start()
    {
        _NumberAchievement = -1;        
        _timer = FindObjectOfType<TimerCount>();
        _player = FindObjectOfType<Player>();
        _Bulletcount = GameObject.Find("Count-1").GetComponent<Count>();
        _CoinCount = GameObject.Find("CoinCount").GetComponent<Count>();
    }
    
    // Update is called once per frame
    void Update()
    {        
        if (_timer._TimerAwal < 0 || _timer.gameObject != true)
        {
            if (_Penghargaan[0] == true)
            {                
                _Animasi.SetTrigger("Mulai");                

                _NumberAchievement = 0;
                _Sfx.SetActive(true);
            }
            else if (_Penghargaan[1] == true)
            {
                _Animasi.SetTrigger("Mulai");

                _NumberAchievement = 2;
                _Sfx.SetActive(true);
            }
            else if (_Penghargaan[2] == true)
            {
                _Animasi.SetTrigger("Mulai");

                _NumberAchievement = 5;
                _Sfx.SetActive(true);
            }
            else if (_Penghargaan[3] == true)
            {
                _Animasi.SetTrigger("Mulai");

                _NumberAchievement = 9;
                _Sfx.SetActive(true);
            }
            else { }

            //Penghargaan 2
            if (_No1 == true)
            {
                if (PlayerPrefs.GetInt("HP") + 100 == _player.currentHP)
                {
                    _NumberAchievement = 1;

                    _Animasi.SetTrigger("Mulai");
                    _Sfx.SetActive(true);
                }
            }

            //Penghargaan 3
            if (_No3 == true)
            {
                if (_player._NoWarnetPS != true)
                {
                    _NumberAchievement = 3;

                    _Animasi.SetTrigger("Mulai");
                    _Sfx.SetActive(true);
                }
            }

            //Penghargaan 4
            if (_No4 == true)
            {
                if (_Bulletcount._NoBullet != true)
                {
                    _NumberAchievement = 4;

                    _Animasi.SetTrigger("Mulai");
                    _Sfx.SetActive(true);
                }
            }

            //_Penghargaan 6
            if (_No6 == true)
            {
                if (_player._Nodate != true)
                {
                    _NumberAchievement = 6;

                    _Animasi.SetTrigger("Mulai");
                    _Sfx.SetActive(true);
                }
            }

            //Penghargaan 7
            if (_No7 == true)
            {
                if (_player._NoMiras == true)
                {
                    _NumberAchievement = 7;

                    _Animasi.SetTrigger("Mulai");
                    _Sfx.SetActive(true);
                }
            }

            //Penghargaan 8
            if (_No8 == true)
            {
                if (_player._NoAttack != 0 || _player._NoAttack != 1)
                {
                    _NumberAchievement = 8;

                    _Animasi.SetTrigger("Mulai");
                    _Sfx.SetActive(true);
                }
            }

            //Penghargaan 11
            if (_No11 == true)
            {
                if (_CoinCount._MoneyCount == 0)
                {
                    _NumberAchievement = 11;

                    _Animasi.SetTrigger("Mulai");
                    _Sfx.SetActive(true);
                }
            }
        }

        //Penghargaan 14
        if(_No14 == true)
        {
            if(_endlessManager._JumlahWave == 10)
            {
                _NumberAchievement = 14;

                _Animasi.SetTrigger("Mulai");
                _Sfx.SetActive(true);
            }
        }
        switch (_NumberAchievement) 
        {
            case 0:
                PlayerPrefs.SetInt("Achievement-0", 1);                
                break;
            case 1:
                PlayerPrefs.SetInt("Achievement-1", 1);                
                break;
            case 2:
                PlayerPrefs.SetInt("Achievement-2", 1);                
                break;
            case 3:
                PlayerPrefs.SetInt("Achievement-3", 1);                
                break;
            case 4:
                PlayerPrefs.SetInt("Achievement-4", 1);                
                break;
            case 5:
                PlayerPrefs.SetInt("Achievement-5", 1);                
                break;
            case 6:
                PlayerPrefs.SetInt("Achievement-6", 1);                
                break;
            case 7:
                PlayerPrefs.SetInt("Achievement-7", 1);                
                break;
            case 8:
                PlayerPrefs.SetInt("Achievement-8", 1);                
                break;
            case 9:
                PlayerPrefs.SetInt("Achievement-9", 1);                
                break;
            case 11:
                PlayerPrefs.SetInt("Achievement-11", 1);
                break;
            case 14:
                PlayerPrefs.SetInt("Achievement-14", 1);                
                break;            
        }        
    }    
}
