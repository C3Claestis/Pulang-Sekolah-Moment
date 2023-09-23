using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    [SerializeField] GameObject _CanvasTutor, _SpawnBullet;
    [SerializeField] GameObject []_Text;
    [SerializeField] GameObject[] _Objects;
    [SerializeField] TimerCount timerCount;    
    int _Count;
    float _Timer;
    public bool _TutorAwal;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _Timer += Time.deltaTime;
        
        if(_Timer >= 5)
        {
            BackgroundLoop.Kondisi = true;
            timerCount.Kondisi = true;
            _Timer = 0;            
            _CanvasTutor.SetActive(true);            
        }

        if(_TutorAwal == true)
        {
            switch (_Count)
            {
                case 0:
                    _Text[0].SetActive(true);
                    break;
                case 1:
                    _Text[_Count].SetActive(true);
                    break;
                case 2:
                    _Text[_Count].SetActive(true);
                    break;
                case 3:
                    _Text[_Count].SetActive(true);
                    break;
                case 4:
                    _Text[_Count].SetActive(true);
                    break;
                case 5:
                    _Text[_Count].SetActive(true);
                    break;
                case 6:
                    _Text[_Count].SetActive(true);
                    break;
                case 7:
                    _CanvasTutor.SetActive(false);
                    _Timer = 10;
                    timerCount.Kondisi = false;
                    BackgroundLoop.Kondisi = false;                    
                    _Objects[0].SetActive(true);
                    _Objects[1].SetActive(true);
                    _Objects[2].SetActive(true);
                    break;
            }
        }

        else
        {
            switch (_Count)
            {
                case 0:
                    _Text[0].SetActive(true);                    
                    break;
                case 1:
                    _Text[_Count].SetActive(true);
                    break;
                case 2:
                    _Text[_Count].SetActive(true);
                    break;
                case 3:
                    _CanvasTutor.SetActive(false);
                    _Timer = 10;
                    timerCount.Kondisi = false;
                    BackgroundLoop.Kondisi = false;                   
                    _Objects[0].SetActive(true);
                    _Objects[1].SetActive(true);
                    _Objects[2].SetActive(true);
                    _SpawnBullet.SetActive(true);                    
                    break;
            }
        }
    }
    public void Next() 
    {
        _Count++;
    }
}
