using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{ 
    [SerializeField] private float Speed;
    [SerializeField] Transform[] Target;
    public static int Posisi;
    public static bool _canShoot;
    //HP
    private int MaxHP;
    public int health { get { return currentHP; } }
    public int currentHP;

    //Attack    
    [SerializeField] private GameObject _bullets;
    [SerializeField] private Transform Spawn;
    public Animator _childAnim, _animator;

    //Button
    Button _JumpButtonCwok, _JumpButtonCwek;    

    //Display Dead    
    [SerializeField] Transform _DeadPosisi;
    public bool EndKondisi;
    private float _Times;

    //Sfx
    AudioSource audioSource;
    [SerializeField] AudioClip _moneySfx, _hurtSfx;

    private Transform _Rumah;
    [SerializeField] private float _TimerJalan;
    public bool _NoWarnetPS;
    public bool _Nodate;
    public bool _NoMiras;
    public int _NoAttack = 0;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        MaxHP = PlayerPrefs.GetInt("HP") + 100;
        _DeadPosisi = GameObject.Find("DeadTarget").GetComponent<Transform>();
        _Rumah = GameObject.Find("RumahFinish").GetComponent<Transform>();

        currentHP = MaxHP;
        _animator = GetComponent<Animator>();
        Target[0] = GameObject.Find("PlayerUp").GetComponent<Transform>();
        Target[1] = GameObject.Find("PlayerMid").GetComponent<Transform>();
        Target[2] = GameObject.Find("PlayerDown").GetComponent<Transform>();

        if(PlayerPrefs.GetInt("Gender") == 1)
        {
            _JumpButtonCwok = GameObject.Find("Jump-Cowok").GetComponent<Button>();
        }
        
        if(PlayerPrefs.GetInt("Gender") == 2)
        {
            _JumpButtonCwek = GameObject.Find("Jump-Cewek").GetComponent<Button>();
        }        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentHP);
        Debug.Log(PlayerPrefs.GetInt("DamageBuku") + 5); 

        //Audio
        if(PlayerPrefs.GetInt("Music") == 1) { audioSource.mute = true; }
        else { audioSource.mute = false; }
        
        if (EndKondisi != true)
        {
            _Times = FindObjectOfType<TimerCount>().GetComponent<TimerCount>()._TimerAwal;

            switch (Posisi)
            {
                case 1:
                    transform.position = Vector3.MoveTowards(transform.position, Target[0].position, Speed);
                    break;
                case 2:
                    transform.position = Vector3.MoveTowards(transform.position, Target[1].position, Speed);
                    break;
                case 3:
                    transform.position = Vector3.MoveTowards(transform.position, Target[2].position, Speed);
                    break;
            }

        }

        _Rumah.transform.position = new Vector2(Mathf.Clamp(_Rumah.transform.position.x, 10, 20), Mathf.Clamp(_Rumah.transform.position.y, -2.75f, -2.75f));

        if(currentHP <= 0)
        {
            EndKondisi = true;
            transform.position = Vector3.MoveTowards(transform.position, _DeadPosisi.position, _TimerJalan);         
            KameraMati.Death = true;
            if (transform.position == _DeadPosisi.position)
            {
                _childAnim.SetBool("Dead", true);
            }
        }        

        if(_Times <= 0)
        {
            NextLevel.instance.Interaksi();
            EndKondisi = true;
            transform.position = Vector3.MoveTowards(transform.position, _DeadPosisi.position, _TimerJalan);
            KameraMati.Finish = true;            
            if (transform.position == _DeadPosisi.position)
            {
                _childAnim.SetBool("Clear", true);
            }
        }    
        if(_Times < 4)
        {
            _Rumah.transform.Translate(Vector2.left * 2 * Time.deltaTime);
        }        
    }
    public void ChangeBar(int value)
    {
        if (value < 0)
        {
            audioSource.volume = 1;
            audioSource.PlayOneShot(_hurtSfx);
            _childAnim.SetTrigger("Damage");
            _animator.SetTrigger("Colider");

            if(PlayerPrefs.GetInt("Gender") == 1)
            {
                StartCoroutine(_NotJumpCowok());
            }

            if (PlayerPrefs.GetInt("Gender") == 2)
            {
                StartCoroutine(_NotJumpCewek());
            }
            
        }
        currentHP = Mathf.Clamp(currentHP + value, 0, 350);

        BandelBar.instance.SetValue(currentHP / (float)MaxHP);
    }
    IEnumerator _NotJumpCowok()
    {
        _JumpButtonCwok.interactable = false;        
        yield return new WaitForSeconds(1);
        _JumpButtonCwok.interactable = true;        
    }

    IEnumerator _NotJumpCewek()
    {        
        _JumpButtonCwek.interactable = false;
        yield return new WaitForSeconds(1);     
        _JumpButtonCwek.interactable = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Warnet") || collision.gameObject.CompareTag("PS"))
        {
            _NoWarnetPS = true;
        }
        if (collision.gameObject.CompareTag("Pacaran"))
        {
            _Nodate = true;
        }
        if (collision.gameObject.CompareTag("Money"))
        {
            audioSource.volume = 0.1f;
            audioSource.PlayOneShot(_moneySfx);
        }
    }
}