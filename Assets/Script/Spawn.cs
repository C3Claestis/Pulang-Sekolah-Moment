using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject[] _Bullets;
    [SerializeField] public float _Min, _Max;
    private float _TimeAttack, _JangkauanRandom;
    private bool _Mulai = false;
    public bool _Duit, _Endless;
    private EndlessManager endlessManager;
    // Start is called before the first frame update
    void Start()
    {
        if(_Duit == true)
        {            
            GameObject newbullet = Instantiate(_Bullets[Random.Range(0, 9)], transform.position, Quaternion.identity);            
            gameObject.SetActive(false);
        }
        else { StartCoroutine(Mulai(3)); _JangkauanRandom = Random.Range(_Min, _Max); }        

        if(_Endless == true) { endlessManager = FindObjectOfType<EndlessManager>(); }
    }

    // Update is called once per frame
    void Update()
    {
        _TimeAttack += Time.deltaTime;

        if (_Mulai == true)
        {             
            if(_Endless == true)
            {
                if(endlessManager._Waktu > 30 && endlessManager._Waktu < 50)
                {
                    _Max = 20;
                }
                else if(endlessManager._Waktu > 50 && endlessManager._Waktu < 70)
                {
                    _Max = 15;
                }
                else if (endlessManager._Waktu > 70 && endlessManager._Waktu < 80)
                {
                    _Max = 10;
                }
                else if (endlessManager._Waktu > 80)
                {
                    _Max = 5;
                }
                else { _Max = 30; }
            }
            while (_TimeAttack > _JangkauanRandom)
            {
                _TimeAttack = 0;
                _JangkauanRandom = Random.Range(_Min, _Max);
                GameObject newbullet = Instantiate(_Bullets[Random.Range(0, 2)], transform.position, Quaternion.identity);                
            }
        }                    
    }

     IEnumerator Mulai(float time)
    {
        yield return new WaitForSeconds(time);
        _Mulai = true;
    }
}
