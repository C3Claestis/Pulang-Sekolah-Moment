using UnityEngine;
using UnityEngine.EventSystems;
public class Peluru : MonoBehaviour
{
    private Count _countbullet;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {        
        _countbullet = GameObject.Find("Count-1").GetComponent<Count>();        
        audioSource = GameObject.Find("Count-1").GetComponent<AudioSource>();
    }
    private void OnMouseDown()
    {
        _countbullet._BulletCount += 1;
        audioSource.Play();
        Destroy(gameObject);        
    }
    private void Update()
    {
        //Audio
        if (PlayerPrefs.GetInt("Music") == 1) { audioSource.mute = true; }
        else { audioSource.mute = false; }

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
