using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEndless : MonoBehaviour
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
    Button _JMANSD, _JMANSMP, _JMANSMA, _JWMSD, _JWMSMP, _JWMSMA;

    //Display Dead    
    [SerializeField] Transform _DeadPosisi;
    public bool EndKondisi;

    //Sfx
    AudioSource audioSource;
    [SerializeField] AudioClip _moneySfx;
    // Start is called before the first frame update    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        MaxHP = PlayerPrefs.GetInt("HP") + 100;

        switch (PlayerPrefs.GetInt("JumpSiswaEndless"))
        {
            case 1:
                _JMANSD = GameObject.Find("Jump-Cowok-SD").GetComponent<Button>();
                break;
            case 2:
                _JMANSMP = GameObject.Find("Jump-Cowok-SMP").GetComponent<Button>();
                break;
            case 3:
                _JMANSMA = GameObject.Find("Jump-Cowok-SMA").GetComponent<Button>();
                break;
            case 4:
                _JWMSD = GameObject.Find("Jump-Cewek-SD").GetComponent<Button>();
                break;
            case 5:
                _JWMSMP = GameObject.Find("Jump-Cewek-SMP").GetComponent<Button>();
                break;
            case 6:
                _JWMSMA = GameObject.Find("Jump-Cewek-SMA").GetComponent<Button>();
                break;
        }                                      
        
        Target[0] = GameObject.Find("PlayerUp").GetComponent<Transform>();
        Target[1] = GameObject.Find("PlayerMid").GetComponent<Transform>();
        Target[2] = GameObject.Find("PlayerDown").GetComponent<Transform>();

        _DeadPosisi = GameObject.Find("DeadTarget").GetComponent<Transform>();
        currentHP = MaxHP;
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentHP);

        //Audio
        if (PlayerPrefs.GetInt("Music") == 1) { audioSource.mute = true; }
        else { audioSource.mute = false; }

        if (EndKondisi != true)
        {     
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
        if (currentHP <= 0)
        {
            EndKondisi = true;
            transform.position = Vector3.MoveTowards(transform.position, _DeadPosisi.position, 0.1f);
            KameraMati.Death = true;
            if (transform.position == _DeadPosisi.position)
            {
                _childAnim.SetBool("Dead", true);
            }
        }
    }
    public void ChangeBar(int value)
    {
        if (value < 0)
        {
            _childAnim.SetTrigger("Damage");
            _animator.SetTrigger("Colider");

            switch (PlayerPrefs.GetInt("JumpSiswaEndless"))
            {
                case 1:
                    StartCoroutine(_NotJump(_JMANSD));
                    break;
                case 2:
                    StartCoroutine(_NotJump(_JMANSMP));
                    break;
                case 3:
                    StartCoroutine(_NotJump(_JMANSMA));
                    break;
                case 4:
                    StartCoroutine(_NotJump(_JWMSD));
                    break;
                case 5:
                    StartCoroutine(_NotJump(_JWMSMP));
                    break;
                case 6:
                    StartCoroutine(_NotJump(_JWMSMA));
                    break;
            }           
        }
        currentHP = Mathf.Clamp(currentHP + value, 0, 350);

        BandelBar.instance.SetValue(currentHP / (float)MaxHP);
    }
    IEnumerator _NotJump(Button button)
    {
        button.interactable = false;
        yield return new WaitForSeconds(1);
        button.interactable = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Money"))
        {
            audioSource.volume = 0.1f;
            audioSource.PlayOneShot(_moneySfx);
        }
    }
}
