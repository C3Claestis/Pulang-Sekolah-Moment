using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ControlButton : MonoBehaviour
{
    private Transform player, _Spawn;
    private Animator animatorPlayer, animator;
    private bool Kondisi;
    private float Count;
    public Count _countBullet;
    private AudioSource audioSource;
    [SerializeField] GameObject _JumpCowok, _JumpCewek, _PanelResume, _IconMan, _IconFamale;
    [SerializeField] GameObject _bulletBook;
    [SerializeField] Button _buttonAttack;
    [SerializeField] AudioClip _audioJump, _audioMove, _buttonSfx, _attackSfx;
    Player pemain;    
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animatorPlayer = GameObject.FindGameObjectWithTag("Child").GetComponent<Animator>();
        animator = FindObjectOfType<Player>().GetComponent<Animator>();
        player = FindObjectOfType<Player>().GetComponent<Transform>();
        pemain = FindObjectOfType<Player>();
        
        if (PlayerPrefs.GetInt("Gender") == 1) { _JumpCowok.SetActive(true); }

        if (PlayerPrefs.GetInt("Gender") == 2) { _JumpCewek.SetActive(true); }
    }
    private void Update()
    {
        //Audio
        if (PlayerPrefs.GetInt("Music") == 1) { audioSource.mute = true; }
        else { audioSource.mute = false; }

        _Spawn = GameObject.FindGameObjectWithTag("Spawn").GetComponent<Transform>();

        if (_countBullet._BulletCount <= 0)
        {
            _buttonAttack.interactable = false;
        }
        else { _buttonAttack.interactable = true; }
        if (PlayerPrefs.GetInt("Gender") == 1) { _IconMan.SetActive(true); }

        else if (PlayerPrefs.GetInt("Gender") == 2) { _IconFamale.SetActive(true); }

        if (Kondisi == true)
            Count += Time.deltaTime;

        if (Count > 1)
            Count = 0;

        if (Count == 0)
        {
            Kondisi = false;
            Player._canShoot = true;
        }
        else
            Player._canShoot = false;
        
    }
    public void Attack()
    {
        GameObject newbullet = Instantiate(_bulletBook, _Spawn.transform.position, Quaternion.identity);

        _countBullet._BulletCount--;
        pemain._NoAttack = 2;
        audioSource.PlayOneShot(_attackSfx);
    }
    public void Keatas()
    {        
        if (player.transform.position.y == -5.5f)
            Player.Posisi = 2;

        if (player.transform.position.y == -4f)
            Player.Posisi = 1;

        audioSource.PlayOneShot(_audioMove);
    }
    public void Kebawah()
    {       

        if (player.transform.position.y == -2.5)
            Player.Posisi = 2;

        if (player.transform.position.y == -4f)
            Player.Posisi = 3;

        audioSource.PlayOneShot(_audioMove);
    }
    public void Lompat()
    {
        if(Kondisi == false)
        {
            animatorPlayer.SetTrigger("Jump");
            animator.SetTrigger("Colider");            
            Kondisi = true;
            audioSource.PlayOneShot(_audioJump);
        }        
    }
    public void MainMenu()
    {
        audioSource.PlayOneShot(_buttonSfx);
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        Destroy(pemain.gameObject);
        KameraMati.Death = false;
        KameraMati.Finish = false;
        BackgroundLoop.Kondisi = false;
    }
    public void Retry()
    {
        audioSource.PlayOneShot(_buttonSfx);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        Destroy(pemain.gameObject);
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

    public void NextStage(int number)
    {
        audioSource.PlayOneShot(_buttonSfx);
        SceneManager.LoadScene(number);
        KameraMati.Death = false;
        KameraMati.Finish = false;
        BackgroundLoop.Kondisi = false;
        KameraMati.Death = false;
        KameraMati.Finish = false;
        Time.timeScale = 1;
        pemain.EndKondisi = false;
    }
}
