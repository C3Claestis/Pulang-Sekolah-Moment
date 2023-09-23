using UnityEngine;

public class MoneySpawnEndless : MonoBehaviour
{
    [SerializeField] GameObject[] _Bullets;
    [SerializeField] public int _Min, _Max;
    private float _TimeAttack, _JangkauanRandom;
    
    // Update is called once per frame
    void Update()
    {
        _TimeAttack += Time.deltaTime;
        
        while (_TimeAttack > _JangkauanRandom)
        {
            _TimeAttack = 0;
            _JangkauanRandom = Random.Range(_Min, _Max);
            GameObject newbullet = Instantiate(_Bullets[Random.Range(0, 9)], transform.position, Quaternion.identity);
        }        
    }
}
