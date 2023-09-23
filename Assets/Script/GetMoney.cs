using UnityEngine;

public class GetMoney : MonoBehaviour
{
    Count _MoneyCount;
    [SerializeField] private int _Nilai;
    private Rigidbody2D rigidbody2D;
    [SerializeField] private float kecepatan;
    // Start is called before the first frame update
    void Start()
    {
        _MoneyCount = GameObject.Find("CoinCount").GetComponent<Count>();
        rigidbody2D = GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody2D.velocity = new Vector2(kecepatan * -1, rigidbody2D.velocity.y);

        if(transform.position.x < -20) { Destroy(gameObject); }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _MoneyCount._MoneyCount += _Nilai;
            Destroy(gameObject);
        }
    }    
}
