using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleEndless : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    [SerializeField] private float kecepatan;
    [SerializeField] private int _Damage;
    private PlayerEndless pemain;
    public float Darah;

    // Start is called before the first frame update
    void Start()
    {        
        rigidbody2D = GetComponent<Rigidbody2D>();
        pemain = FindObjectOfType<PlayerEndless>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody2D.velocity = new Vector2(kecepatan * -1, rigidbody2D.velocity.y);

        if (Darah <= 0)
        {           
            Destroy(gameObject);
        }

        if (transform.position.x < -20f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) { pemain.ChangeBar(-_Damage); Destroy(gameObject); }
    }
}
