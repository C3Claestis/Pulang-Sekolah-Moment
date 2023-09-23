using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Gamemanager : MonoBehaviour
{
    float _Waktu;
    public static int Money;
    private int _levelunlock;
    private int[] _Penghargaan = new int[15];
    private AudioSource _Sfx;
    [SerializeField] private Text text, _JumlahMoney, _TeksScreen;
    [SerializeField] GameObject _panelMain, _panelLoad, _panelGallery, _panelName, _panelAchievement, _panelAbout, _panelAboutUtama, _panelTeam, _panelKopiKanan;
    [SerializeField] GameObject _buttonPeringatanName, _buttonPeringatanGender;
    [SerializeField] GameObject _checkMale, _checkFemale, _iconMale, _iconFemale;
    [SerializeField] GameObject _PanelButtonGame, _GalleryButton, _PanelStatus, _PanelAlbum, _StatsCewek, _StatsCowok;
    [SerializeField] GameObject _ButtonAlbum, _TeksAlbum, _ButtonBackAlbum;
    [SerializeField] GameObject[] _AlbumPanel = new GameObject[9];
    [SerializeField] private GameObject[] _LockAcheivement = new GameObject[15];
    [SerializeField] GameObject[] _LockLoadLevel = new GameObject[15];
    [SerializeField] Button _EndlessButton;
    [SerializeField] GameObject _CanvasScreen, _PanelEndless, _PanelPeringatanUpgrade;
    [SerializeField] private Text _HP_Upgrade, _Attack_Upgrade, _BiayaHP, _BiayaAttack, _BiayaRename;
    [SerializeField] GameObject[] _GambarPrologue = new GameObject[4];
    [SerializeField] AudioSource[] _SfxPlogoue = new AudioSource[5];
    [SerializeField] Animator[] _AnimasiPenghargaan = new Animator[3];
    [SerializeField] GameObject[] _SfxAchievement = new GameObject[3];
    [SerializeField] AudioClip[] _AudioclipSfx;
    [SerializeField] AudioSource _BGM;
    [SerializeField] GameObject _buttonOn, _buttonOff;
    bool _MulaiAwal = false;

    public int _nilaiHP;
    public int _nilaiBuku;   
    private void Awake()
    {
        //SD
        _Penghargaan[0] = PlayerPrefs.GetInt("Achievement-0");
        _Penghargaan[1] = PlayerPrefs.GetInt("Achievement-1");
        _Penghargaan[2] = PlayerPrefs.GetInt("Achievement-2");

        //SMP
        _Penghargaan[3] = PlayerPrefs.GetInt("Achievement-3");
        _Penghargaan[4] = PlayerPrefs.GetInt("Achievement-4");
        _Penghargaan[5] = PlayerPrefs.GetInt("Achievement-5");

        //SMA/SMK
        _Penghargaan[6] = PlayerPrefs.GetInt("Achievement-6");
        _Penghargaan[7] = PlayerPrefs.GetInt("Achievement-7");
        _Penghargaan[8] = PlayerPrefs.GetInt("Achievement-8");

        _Penghargaan[9] = PlayerPrefs.GetInt("Achievement-9");
        _Penghargaan[10] = PlayerPrefs.GetInt("Achievement-10");

        _Penghargaan[11] = PlayerPrefs.GetInt("Achievement-11");
        _Penghargaan[12] = PlayerPrefs.GetInt("Achievement-12");

        _Penghargaan[13] = PlayerPrefs.GetInt("Achievement-13");
        _Penghargaan[14] = PlayerPrefs.GetInt("Achievement-14");
    }
    // Start is called before the first frame update
    void Start()
    {        
        //text = GameObject.Find("Input").GetComponent<Text>();                
        _Sfx = GetComponent<AudioSource>();
        if (PlayerPrefs.GetInt("NameKey") == 1)
        {
            _panelName.SetActive(false);
        }
        else { _panelName.SetActive(true); }

        Kelamin();
        _levelunlock = PlayerPrefs.GetInt("LevelPassed");

        if(PlayerPrefs.GetInt("Endless") == 1)
        {
            _EndlessButton.interactable = true;
        }
    }

    // Update is called once per frame
    void Update()
    {        
        _nilaiHP = PlayerPrefs.GetInt("HargaHP") + 10;
        _nilaiBuku = PlayerPrefs.GetInt("HargaAttack") + 10;

        UnlockAchievment();
        UnlockLoadLevel();
        Money = PlayerPrefs.GetInt("Money");

        if(PlayerPrefs.GetInt("Music") == 1)
        {
            _Sfx.mute = true;
            _BGM.mute = true;

            for (int i = 0; i < _SfxPlogoue.Length; i++)
            {
                _SfxPlogoue[i].mute = true;
            }

            _buttonOn.SetActive(false);
            _buttonOff.SetActive(true);
        }
        else
        {
            for(int i = 0; i < _SfxPlogoue.Length; i++)
            {
                _SfxPlogoue[i].mute = false;
            }
            _Sfx.mute = false;
            _BGM.mute = false;

            _buttonOn.SetActive(true);
            _buttonOff.SetActive(false);
        }

        if (PlayerPrefs.GetInt("NameKey") == 1) 
        {
            _PanelButtonGame.SetActive(true);
        }
        else
            _PanelButtonGame.SetActive(false);

        if (Input.GetKey(KeyCode.Space)) { PlayerPrefs.DeleteAll(); }

        _JumlahMoney.text = Money.ToString();
                       
        Prologue();
        ScreenUpgrade();        
    }
    
    void Prologue()
    {        
        if (_MulaiAwal)
        {
            _BGM.mute = true;
            _Waktu += 0.1f;

            if(_Waktu > 10)
            {
                _SfxPlogoue[1].volume = 1;
            }
            if (_Waktu > 25)
            {
                _GambarPrologue[0].SetActive(true);
                _TeksScreen.text = "'Ingat langsung pulang ke rumah ya! Jangan main ke tempat lain!'";
                _SfxPlogoue[1].volume = 0.25f;
            }            
            if (_Waktu > 50)
            {
                _GambarPrologue[1].SetActive(true);
                _SfxPlogoue[1].volume = 0.1f;
                _TeksScreen.text = "Tidak lama kemudian " + PlayerPrefs.GetString("Name") + " Pergi dari kelas";
            }
            if (_Waktu > 75)
            {
                _SfxPlogoue[2].Stop();
                _SfxPlogoue[1].Stop();
                _SfxPlogoue[3].Stop();
                _GambarPrologue[2].SetActive(true);
                _TeksScreen.text = "Namun teman sekelas " + PlayerPrefs.GetString("Name") + " datang dan mengajak untuk bermain";
            }
            if (_Waktu > 100)
            {
                _SfxPlogoue[4].volume = 0.1f;
                _GambarPrologue[3].SetActive(true);
                _TeksScreen.fontSize = 36;
                _TeksScreen.text = "Dengan berlari " + PlayerPrefs.GetString("Name") + " berusaha menghindari ajakan tersebut. Sebab " + PlayerPrefs.GetString("Name") + " ingin menaati aturan sekolah dan langsung pulang ke rumah";
            }
            if (_Waktu > 200)
            {
                SceneManager.LoadScene(1);
            }
        }
    }
    public void EnterNama()
    {        
        PlayerPrefs.SetString("Name", text.text);

        if (text.text != "" && PlayerPrefs.GetInt("Gender") == 1 || text.text != "" && PlayerPrefs.GetInt("Gender") == 2)
        {
            PlayerPrefs.SetInt("NameKey", 1);
            _panelName.SetActive(false);            
        }

        else if (text.text == "") { StartCoroutine(Name()); }

        else if(PlayerPrefs.GetInt("Gender") != 1 || PlayerPrefs.GetInt("Gender") != 2) { StartCoroutine(Genders()); }

        _Sfx.PlayOneShot(_AudioclipSfx[0]);
        Kelamin();
    }
    IEnumerator Name()
    {
        _buttonPeringatanName.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        _buttonPeringatanName.SetActive(false);
    }
    IEnumerator Genders()
    {
        _buttonPeringatanGender.SetActive(true);        
        yield return new WaitForSeconds(1.5f);
        _buttonPeringatanGender.SetActive(false);
    }
    IEnumerator UpgradeWarning()
    {
        _PanelPeringatanUpgrade.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        _PanelPeringatanUpgrade.SetActive(false);
    }
    void Kelamin()
    {
        if (PlayerPrefs.GetInt("Gender") == 1) { _iconMale.SetActive(true); _StatsCowok.SetActive(true); }

        else if (PlayerPrefs.GetInt("Gender") == 2) { _iconFemale.SetActive(true); _StatsCewek.SetActive(true); }
    }

    //Button Utama
    public void MulaiAwal()
    {
        //SceneManager.LoadScene(1);
        _CanvasScreen.SetActive(true);
        _MulaiAwal = true;
        _Sfx.PlayOneShot(_AudioclipSfx[0]);
    }
    public void LoadLevel()
    {
        _panelLoad.SetActive(true);
        _panelMain.SetActive(false);       
        _panelGallery.SetActive(false);
        _Sfx.PlayOneShot(_AudioclipSfx[0]);
    }
    public void Gallery()
    {
        _panelGallery.SetActive(true);
         _panelMain.SetActive(false);
        _panelLoad.SetActive(false);
        _Sfx.PlayOneShot(_AudioclipSfx[0]);
    }
    public void EndlessPanel()
    {
        _PanelEndless.SetActive(true);
        _panelMain.SetActive(false);
        _panelLoad.SetActive(false);
        _panelGallery.SetActive(false);
        _panelAchievement.SetActive(false);
        _Sfx.PlayOneShot(_AudioclipSfx[0]);
    }    
    public void ExitGame()
    {
        _Sfx.PlayOneShot(_AudioclipSfx[0]);
        Application.Quit();
    }
    public void About()
    {
        _panelAbout.SetActive(true);
        _panelMain.SetActive(false);
        _Sfx.PlayOneShot(_AudioclipSfx[0]);
    }

    //Button Second
    public void MainMenu()
    {
        _panelMain.SetActive(true);
        _panelLoad.SetActive(false);
        _panelGallery.SetActive(false);
        _panelAchievement.SetActive(false);
        _panelAbout.SetActive(false);
        _Sfx.PlayOneShot(_AudioclipSfx[1]);
    }
    public void StatusGallery()
    {        
        _GalleryButton.SetActive(false);
        _PanelStatus.SetActive(true);
        _Sfx.PlayOneShot(_AudioclipSfx[2]);
    }
    public void AlbumGallery()
    {
        _GalleryButton.SetActive(false);
        _PanelAlbum.SetActive(true);
        _Sfx.PlayOneShot(_AudioclipSfx[2]);
    }
    public void PanelAlbum(int nomor)
    {
        _AlbumPanel[nomor].SetActive(true);
        _ButtonAlbum.SetActive(false);
        _TeksAlbum.SetActive(false);
        _ButtonBackAlbum.SetActive(false);
        _Sfx.PlayOneShot(_AudioclipSfx[0]);
    }
    public void BackPanelAlbum(int nomor)
    {
        _AlbumPanel[nomor].SetActive(false);
        _ButtonAlbum.SetActive(true);
        _TeksAlbum.SetActive(true);
        _ButtonBackAlbum.SetActive(true);
        _Sfx.PlayOneShot(_AudioclipSfx[1]);
    }
    public void GalleryDisplay()
    {
        _PanelAlbum.SetActive(false);
        _PanelStatus.SetActive(false);
        _GalleryButton.SetActive(true);
        _Sfx.PlayOneShot(_AudioclipSfx[1]);
    }    
    public void Achievement()
    {
        _panelAchievement.SetActive(true);
        _panelMain.SetActive(false);
        _Sfx.PlayOneShot(_AudioclipSfx[0]);
    }    
    public void OnMusic()
    {
        PlayerPrefs.SetInt("Music", 1);        
        _Sfx.PlayOneShot(_AudioclipSfx[1]);
    }
    public void OffMusic()
    {
        _Sfx.PlayOneShot(_AudioclipSfx[1]);
        PlayerPrefs.SetInt("Music", 0);                
    }
    public void AboutUtama()
    {
        _panelAboutUtama.SetActive(true);
        _panelKopiKanan.SetActive(false);
        _panelTeam.SetActive(false);
        _Sfx.PlayOneShot(_AudioclipSfx[1]);
    }
    public void AboutTeam()
    {
        _panelAboutUtama.SetActive(false);
        _panelTeam.SetActive(true);
        _Sfx.PlayOneShot(_AudioclipSfx[0]);
    }
    public void AboutCopyKanan()
    {
        _panelAboutUtama.SetActive(false);
        _panelKopiKanan.SetActive(true);
        _Sfx.PlayOneShot(_AudioclipSfx[0]);
    }
    //Fungsi 
    public void EndlessRun(int NomorSiswa)
    {
        PlayerPrefs.SetInt("JumpSiswaEndless", NomorSiswa);                
    }
    public void EndlessRunMirror(int NomorTingkat)
    {
        PlayerPrefs.SetInt("AttackEndless", NomorTingkat);        
    }
    public void EndlessRunGender(int NomorTingkat)
    {
        PlayerPrefs.SetInt("GenderEndless", NomorTingkat);
        SceneManager.LoadScene(17);
    }
    public void UnlockAchievment()
    {        
        if (_Penghargaan[0] == 1)
        {
            _LockAcheivement[0].SetActive(false);
        }
        if (_Penghargaan[1] == 1)
        {
            _LockAcheivement[1].SetActive(false);
        }
        if (_Penghargaan[2] == 1)
        {
            _LockAcheivement[2].SetActive(false);
        }
        if (_Penghargaan[3] == 1)
        {
            _LockAcheivement[3].SetActive(false);
        }
        if (_Penghargaan[4] == 1)
        {
            _LockAcheivement[4].SetActive(false);
        }
        if (_Penghargaan[5] == 1)
        {
            _LockAcheivement[5].SetActive(false);
        }
        if (_Penghargaan[6] == 1)
        {
            _LockAcheivement[6].SetActive(false);
        }
        if (_Penghargaan[7] == 1)
        {
            _LockAcheivement[7].SetActive(false);
        }
        if (_Penghargaan[8] == 1)
        {
            _LockAcheivement[8].SetActive(false);
        }
        if (_Penghargaan[9] == 1)
        {
            _LockAcheivement[9].SetActive(false);
        }
        if (_Penghargaan[10] == 1)
        {
            _LockAcheivement[10].SetActive(false);
        }
        if (_Penghargaan[11] == 1)
        {
            _LockAcheivement[11].SetActive(false);
        }
        if (_Penghargaan[12] == 1)
        {
            _LockAcheivement[12].SetActive(false);
        }
        if (_Penghargaan[13] == 1)
        {
            _LockAcheivement[13].SetActive(false);
        }
        if (_Penghargaan[14] == 1)
        {
            _LockAcheivement[14].SetActive(false);
        }        
    }
    public void UnlockLoadLevel()
    {
        switch (_levelunlock)
        {
            case 1:                
                    _LockLoadLevel[0].SetActive(false);
                break;
            case 2:
                for (int i = 0; i < 2; i++)
                    _LockLoadLevel[i].SetActive(false);
                break;
            case 3:
                for (int i = 0; i < 3; i++)
                    _LockLoadLevel[i].SetActive(false);
                break;
            case 4:
                for (int i = 0; i < 4; i++)
                    _LockLoadLevel[i].SetActive(false);
                break;
            case 5:
                for (int i = 0; i < 5; i++)
                    _LockLoadLevel[i].SetActive(false);
                break;
            case 6:
                for (int i = 0; i < 6; i++)
                    _LockLoadLevel[i].SetActive(false);
                break;
            case 7:
                for (int i = 0; i < 7; i++)
                    _LockLoadLevel[i].SetActive(false);
                break;
            case 8:
                for (int i = 0; i < 8; i++)
                    _LockLoadLevel[i].SetActive(false);
                break;
            case 9:
                for (int i = 0; i < 9; i++)
                    _LockLoadLevel[i].SetActive(false);
                break;
            case 10:
                for (int i = 0; i < 10; i++)
                    _LockLoadLevel[i].SetActive(false);
                break;
            case 11:
                for (int i = 0; i < 11; i++)
                    _LockLoadLevel[i].SetActive(false);
                break;
            case 12:
                for (int i = 0; i < 12; i++)
                    _LockLoadLevel[i].SetActive(false);
                break;
            case 13:
                for (int i = 0; i < 13; i++)
                    _LockLoadLevel[i].SetActive(false);
                break;
            case 14:
                for (int i = 0; i < 14; i++)
                    _LockLoadLevel[i].SetActive(false);
                break;
            case 15:
                for (int i = 0; i < 15; i++)
                    _LockLoadLevel[i].SetActive(false);
                break;
            case 16:
                for (int i = 0; i < 16; i++)
                    _LockLoadLevel[i].SetActive(false);
                break;
        }
    }
    public void GameScene(int Number)
    {
        _Sfx.PlayOneShot(_AudioclipSfx[3]);
        StartCoroutine(Wait(Number));        
    }
    IEnumerator Wait(int number)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(number);
    }
    public void CheckMale()
    {
        _checkMale.SetActive(true);
        _checkFemale.SetActive(false);
        _Sfx.PlayOneShot(_AudioclipSfx[1]);
        PlayerPrefs.SetInt("Gender", 1);
    }
    public void CheckFemale()
    {
        _checkFemale.SetActive(true);
        _checkMale.SetActive(false);
        _Sfx.PlayOneShot(_AudioclipSfx[1]);
        PlayerPrefs.SetInt("Gender", 2);
    }        
    public void UpHP()
    {        
        if(PlayerPrefs.GetInt("Money") < _nilaiHP)
        {
            StartCoroutine(UpgradeWarning());
        }
        else
        {            
            if(PlayerPrefs.GetInt("HP") < 10)
            {
                PlayerPrefs.SetInt("HP", +10);                
                PlayerPrefs.SetInt("Money", Money - 10);
                PlayerPrefs.SetInt("HargaHP", +90);
                _Sfx.PlayOneShot(_AudioclipSfx[4]);
            }            
            else if (PlayerPrefs.GetInt("HP") >= 10 && PlayerPrefs.GetInt("HP") < 30)
            {
                PlayerPrefs.SetInt("HP", +30);
                PlayerPrefs.SetInt("Money", Money - 100);
                PlayerPrefs.SetInt("HargaHP", +190);
                _Sfx.PlayOneShot(_AudioclipSfx[4]);
            }
            else if (PlayerPrefs.GetInt("HP") >= 30 && PlayerPrefs.GetInt("HP") < 60)
            {
                PlayerPrefs.SetInt("HP", +60);
                PlayerPrefs.SetInt("Money", Money - 200);
                PlayerPrefs.SetInt("HargaHP", +390);
                _Sfx.PlayOneShot(_AudioclipSfx[4]);
            }
            else if (PlayerPrefs.GetInt("HP") >= 60 && PlayerPrefs.GetInt("HP") < 120)
            {
                PlayerPrefs.SetInt("HP", +120);
                PlayerPrefs.SetInt("Money", Money - 400);
                PlayerPrefs.SetInt("HargaHP", +790);
                _Sfx.PlayOneShot(_AudioclipSfx[4]);
            }
            else if (PlayerPrefs.GetInt("HP") >= 120 && PlayerPrefs.GetInt("HP") < 250)
            {
                PlayerPrefs.SetInt("HP", +250);
                PlayerPrefs.SetInt("Money", Money - 800);                
                PlayerPrefs.SetInt("HargaHP", +1000);
                PlayerPrefs.SetInt("Achievement-13", 1);
                _Sfx.PlayOneShot(_AudioclipSfx[4]);
                _AnimasiPenghargaan[2].SetTrigger("Mulai");
                _SfxAchievement[2].SetActive(true);
            }
        }
    }
    public void UpAttack()
    {
        if (PlayerPrefs.GetInt("Money") < _nilaiBuku)
        {
            StartCoroutine(UpgradeWarning());
        }
        else
        {
            if (PlayerPrefs.GetInt("DamageBuku") < 1)
            {
                PlayerPrefs.SetInt("DamageBuku", +1);
                PlayerPrefs.SetInt("Money", Money - 10);
                PlayerPrefs.SetInt("HargaAttack", +90);
                _Sfx.PlayOneShot(_AudioclipSfx[4]);
            }
            else if (PlayerPrefs.GetInt("DamageBuku") >= 1 && PlayerPrefs.GetInt("DamageBuku") < 2)
            {
                PlayerPrefs.SetInt("DamageBuku", +2);
                PlayerPrefs.SetInt("Money", Money - 100);
                PlayerPrefs.SetInt("HargaAttack", +190);
                _Sfx.PlayOneShot(_AudioclipSfx[4]);
            }
            else if (PlayerPrefs.GetInt("DamageBuku") >= 2 && PlayerPrefs.GetInt("DamageBuku") < 4)
            {
                PlayerPrefs.SetInt("DamageBuku", +4);
                PlayerPrefs.SetInt("Money", Money - 200);
                PlayerPrefs.SetInt("HargaAttack", +390);
                _Sfx.PlayOneShot(_AudioclipSfx[4]);
            }
            else if (PlayerPrefs.GetInt("DamageBuku") >= 4 && PlayerPrefs.GetInt("DamageBuku") < 8)
            {
                PlayerPrefs.SetInt("DamageBuku", +8);
                PlayerPrefs.SetInt("Money", Money - 400);
                PlayerPrefs.SetInt("HargaAttack", +790);
                _Sfx.PlayOneShot(_AudioclipSfx[4]);
            }
            else if (PlayerPrefs.GetInt("DamageBuku") >= 8 && PlayerPrefs.GetInt("DamageBuku") < 20)
            {
                PlayerPrefs.SetInt("DamageBuku", +20);
                PlayerPrefs.SetInt("Money", Money - 800);
                PlayerPrefs.SetInt("HargaAttack", +1000);
                PlayerPrefs.SetInt("Achievement-10", 1);
                _Sfx.PlayOneShot(_AudioclipSfx[4]);
                _AnimasiPenghargaan[0].SetTrigger("Mulai");
                _SfxAchievement[0].SetActive(true);
            }
        }
    }
    public void ScreenUpgrade()
    {
        if(PlayerPrefs.GetInt("HargaHP") >= 1000)
        {
            _BiayaHP.text = "MAX";            
        }
        else { _BiayaHP.text = _nilaiHP.ToString(); }

        if (PlayerPrefs.GetInt("HargaAttack") >= 1000)
        {
            _BiayaAttack.text = "MAX";                        
        }
        else { _BiayaAttack.text = _nilaiBuku.ToString(); }
        

        _HP_Upgrade.text = PlayerPrefs.GetInt("HP").ToString();
        _Attack_Upgrade.text = PlayerPrefs.GetInt("DamageBuku").ToString();
    }    
}