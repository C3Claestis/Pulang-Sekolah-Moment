using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    [SerializeField] GameObject[] _Bullets;
    [SerializeField] float _Min, _Max;
    private float _TimeAttack, _JangkauanRandom;    
   
    // Start is called before the first frame update
    void Start()
    {
        _JangkauanRandom = Random.Range(_Min, _Max);        
    }

    // Update is called once per frame
    void Update()
    {
        _TimeAttack += Time.deltaTime;

        while (_TimeAttack > _JangkauanRandom)
        {
            _TimeAttack = 0;
            _JangkauanRandom = Random.Range(_Min, _Max);            
            GameObject newbullet = Instantiate(_Bullets[Random.Range(1, 3)], transform.position = new Vector2(Random.Range(-7f, 9f), transform.position.y), Quaternion.identity);
        }
    }
}
