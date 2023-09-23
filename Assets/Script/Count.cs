using UnityEngine;
using UnityEngine.UI;
public class Count : MonoBehaviour
{
    public int _BulletCount, _MoneyCount;
    [SerializeField] bool _Money;
    [SerializeField] Text _teks;
    public bool _NoBullet;
    
    // Update is called once per frame
    void Update()
    {        
        if(_Money == true)
        {
            _Duit();
        }
        else { _Bullet(); }
    }
    void _Bullet()
    {
        if (_BulletCount >= 1) { _teks.gameObject.SetActive(true); _teks.text = _BulletCount.ToString(); _NoBullet = true; }

        else { _teks.gameObject.SetActive(false); }
    }
    void _Duit()
    {
        _teks.text = _MoneyCount.ToString(); 
    }
}
