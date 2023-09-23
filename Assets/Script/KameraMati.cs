using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraMati : MonoBehaviour
{
    Camera _camera;
    public static bool Death, Finish;
    Transform players;
    [SerializeField] GameObject _deadDisplay, _PanelDead, _PanelFinish, _BoxDestroy;
    [SerializeField] GameObject _Manager, _FinishSfx, _LoseSfx;
    [SerializeField] AudioSource audioSource;
     // Start is called before the first frame update
    void Start()
    {
        Death = false;
        Finish = false;
        BackgroundLoop.Kondisi = false;
        _camera = GetComponent<Camera>();
        players = GameObject.Find("DeadTarget").GetComponent<Transform>();        
        
        if(PlayerPrefs.GetInt("Music") == 1)
        {
            _FinishSfx.GetComponent<AudioSource>().mute = true;
            _LoseSfx.GetComponent<AudioSource>().mute = true;
        }
        else
        {
            _FinishSfx.GetComponent<AudioSource>().mute = false;
            _LoseSfx.GetComponent<AudioSource>().mute = false;
        }
    }

    // Update is called once per frame
    void Update()
    {                        
        if (_camera.orthographicSize <= 1.5f)
        {
            _camera.orthographicSize = 1.5f;
        }

        if (Death == true)
        {
            StartCoroutine(Dead());
            _deadDisplay.SetActive(false);
            BackgroundLoop.Kondisi = true;
            _BoxDestroy.SetActive(true);           
        }

        if(Finish ==  true)
        {
            StartCoroutine(Finisihing());
            _deadDisplay.SetActive(false);
            BackgroundLoop.Kondisi = true;
            _BoxDestroy.SetActive(true);            
        }
    }
    IEnumerator Dead()
    {
        _Manager.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        _camera.orthographicSize -= Time.deltaTime / 3f;
        yield return new WaitForSeconds(2f);
        transform.position = Vector3.MoveTowards(transform.position, players.position, 0.01f);
        yield return new WaitForSeconds(5f);
        _PanelDead.SetActive(true);
        audioSource.volume = 0;
        _LoseSfx.SetActive(true);
        yield return new WaitForSeconds(1.5f);        
        Time.timeScale = 0;        
    }

    IEnumerator Finisihing()
    {
        _Manager.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        _camera.orthographicSize -= Time.deltaTime / 3f;
        yield return new WaitForSeconds(2f);
        transform.position = Vector3.MoveTowards(transform.position, players.position, 0.01f);
        yield return new WaitForSeconds(5f);
        _PanelFinish.SetActive(true);
        audioSource.volume = 0;
        _FinishSfx.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 0;
    }
}
