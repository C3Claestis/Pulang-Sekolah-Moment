using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndlessManager : MonoBehaviour
{
    [SerializeField] private Text _timer, _Wave;
    [SerializeField] Animator _Transisi, _TransisiTeks;
    public float _Waktu = 0; 
    public float _LamaWaktu;
    int _changeBG, _randomBG, _random, _randomObstacle;
    public int _JumlahWave;
    private Transform player, _Spawn;
    private Animator animatorPlayer, animator;
    private bool Kondisi;
    private float Count;
    public Count _countBullet;
    [SerializeField] GameObject _PanelResume, _IconMan, _IconFamale;
    [SerializeField] GameObject _bulletBook;
    [SerializeField] GameObject[] _JumpIcon = new GameObject[6];
    [SerializeField] Button[] _ButtonAttack = new Button[3];
    [SerializeField] GameObject[] _Avatar = new GameObject[6];
    [SerializeField] GameObject[] _BG = new GameObject[3];
    [SerializeField] GameObject[] _Obstacle = new GameObject[3];
    [SerializeField] MoneySpawnEndless[] _Duit = new MoneySpawnEndless[3];
    public Transform _TempatSpawn;

    //Sfx
    [SerializeField] AudioClip _audioJump, _audioMove, _buttonSfx, _attackSfx;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        _BG[Random.Range(0, 2)].SetActive(true);
        _Obstacle[Random.Range(0, 2)].SetActive(true);

        GameObject gameObject;

        switch (PlayerPrefs.GetInt("JumpSiswaEndless"))
        {
            case 1:
                _JumpIcon[0].SetActive(true);                
                gameObject = Instantiate(_Avatar[0], _TempatSpawn.transform.position, Quaternion.identity);
                break;
            case 2:
                _JumpIcon[1].SetActive(true);
                gameObject = Instantiate(_Avatar[1], _TempatSpawn.transform.position, Quaternion.identity);
                break;
            case 3:
                _JumpIcon[2].SetActive(true);
                gameObject = Instantiate(_Avatar[2], _TempatSpawn.transform.position, Quaternion.identity);
                break;
            case 4:
                _JumpIcon[3].SetActive(true);
                gameObject = Instantiate(_Avatar[3], _TempatSpawn.transform.position, Quaternion.identity);
                break;
            case 5:
                _JumpIcon[4].SetActive(true);
                gameObject = Instantiate(_Avatar[4], _TempatSpawn.transform.position, Quaternion.identity);
                break;
            case 6:
                _JumpIcon[5].SetActive(true);
                gameObject = Instantiate(_Avatar[5], _TempatSpawn.transform.position, Quaternion.identity);
                break;
        }
        animatorPlayer = GameObject.FindGameObjectWithTag("Child").GetComponent<Animator>();
        animator = FindObjectOfType<PlayerEndless>().GetComponent<Animator>();
        player = FindObjectOfType<PlayerEndless>().GetComponent<Transform>();        

        switch (PlayerPrefs.GetInt("AttackEndless"))
        {
            case 1:
                _ButtonAttack[0].gameObject.SetActive(true);
                break;
            case 2:
                _ButtonAttack[1].gameObject.SetActive(true);
                break;
            case 3:
                _ButtonAttack[2].gameObject.SetActive(true);
                break;
        }
        if (PlayerPrefs.GetInt("GenderEndless") == 1) { _IconMan.SetActive(true); }

        if (PlayerPrefs.GetInt("GenderEndless") == 2) { _IconFamale.SetActive(true); }
    }

    // Update is called once per frame
    void Update()
    {
        //Audio
        if (PlayerPrefs.GetInt("Music") == 1) { audioSource.mute = true; }
        else { audioSource.mute = false; }

        _Spawn = GameObject.FindGameObjectWithTag("Spawn").GetComponent<Transform>();

        if (Kondisi == true)
            Count += Time.deltaTime;

        if (Count > 1)
            Count = 0;

        if (Count == 0)
        {
            Kondisi = false;
            PlayerEndless._canShoot = true;
        }
        else
            PlayerEndless._canShoot = false;
    
        Manager();

        for (int o = 0; 0 < _ButtonAttack.Length; o++)
        {
            if (_countBullet._BulletCount <= 0)
            {
                _ButtonAttack[o].interactable = false;
            }
            else
            {
                _ButtonAttack[o].interactable = true;
            }
        }

    }
    public void Attack()
    {        
        GameObject newbullet = Instantiate(_bulletBook, _Spawn.transform.position, Quaternion.identity);

        _countBullet._BulletCount--;
        audioSource.PlayOneShot(_attackSfx);
    }
    public void Keatas()
    {
        if (player.transform.position.y == -5.5f)
            PlayerEndless.Posisi = 2;

        if (player.transform.position.y == -4f)
            PlayerEndless.Posisi = 1;

        audioSource.PlayOneShot(_audioMove);
    }
    public void Kebawah()
    {

        if (player.transform.position.y == -2.5)
            PlayerEndless.Posisi = 2;

        if (player.transform.position.y == -4f)
            PlayerEndless.Posisi = 3;

        audioSource.PlayOneShot(_audioMove);
    }
    public void Lompat()
    {
        if (Kondisi == false)
        {
            animatorPlayer.SetTrigger("Jump");
            animator.SetTrigger("Colider");
            Kondisi = true;
            audioSource.PlayOneShot(_audioJump);
        }
    }
    void Manager()
    {
        _Waktu += Time.deltaTime;
        _timer.text = _Waktu.ToString("0");        

        while (_Waktu > _LamaWaktu)
        {
            
            _Waktu = 0;
            _changeBG++;
            _JumlahWave++;
            _randomBG = Random.Range(3, 10);
            _TransisiTeks.SetTrigger("Mulai");
            _Wave.text = "Wave - " + _JumlahWave.ToString();
            
        }
        
        if (_changeBG > _randomBG)
        {
            int i;
            for (i = 0; i < 5; i++)
            {                
                if (i > 5) { i = 0; }                
            }

            _changeBG = 0;
            _Transisi.SetTrigger("Screen");
            _random = Random.Range(0, 2);

            for(int j=0; j< _Duit.Length; j++)
            {                
                _Duit[j]._Max += i;

                if (_Duit[j]._Max > 50)
                {
                    _Duit[j]._Max = 30;
                }
            }                        
   
        }
        /*
        switch (_random)
        {
            case 0:
                _BG[0].SetActive(true);
                _BG[1].SetActive(false);
                _BG[2].SetActive(false);
                break;

            case 1:
                _BG[0].SetActive(false);
                _BG[1].SetActive(true);
                _BG[2].SetActive(false);
                break;

            case 2:
                _BG[0].SetActive(false);
                _BG[1].SetActive(false);
                _BG[2].SetActive(true);
                break;
        }

        
        switch (_randomObstacle)
        {
            case 0:
                _Obstacle[0].SetActive(true);
                _Obstacle[1].SetActive(false);
                _Obstacle[2].SetActive(false);
                break;

            case 1:
                _Obstacle[0].SetActive(false);
                _Obstacle[1].SetActive(true);
                _Obstacle[2].SetActive(false);
                break;

            case 2:
                _Obstacle[0].SetActive(false);
                _Obstacle[1].SetActive(false);
                _Obstacle[2].SetActive(true);
                break;
        }        
        */
    }
    public void MainMenu()
    {
        audioSource.PlayOneShot(_buttonSfx);
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        Destroy(_Avatar[_Avatar.Length].gameObject);
        KameraMati.Death = false;
        KameraMati.Finish = false;
        BackgroundLoop.Kondisi = false;
    }
    public void Resume()
    {
        audioSource.PlayOneShot(_buttonSfx);
        Time.timeScale = 0;
        _PanelResume.SetActive(true);
    }
    public void BackResume()
    {
        audioSource.PlayOneShot(_buttonSfx);
        Time.timeScale = 1;
        _PanelResume.SetActive(false);
    }
}
