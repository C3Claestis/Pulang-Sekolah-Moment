using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    [SerializeField] private float kecepatan;
    [SerializeField] private int _Damage;
    private Player pemain;
    public float Darah;
    public bool Miras;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        pemain = FindObjectOfType<Player>();        
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody2D.velocity = new Vector2(kecepatan * -1, rigidbody2D.velocity.y);

        if(Darah <= 0)
        {
            if(Miras == true)
            {
                pemain._NoMiras = true;
            }
            Destroy(gameObject);
        }        

        if(transform.position.x < -20f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) { pemain.ChangeBar(-_Damage); Destroy(gameObject); }
    }
}
