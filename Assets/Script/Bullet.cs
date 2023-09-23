using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private int Attack;

    private void Awake()
    {
        Attack = PlayerPrefs.GetInt("DamageBuku") + 5;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle")) { collision.GetComponent<Obstacle>().Darah -= Attack; Destroy(gameObject); }

        if (collision.gameObject.CompareTag("Warnet")) { collision.GetComponent<Obstacle>().Darah -= Attack; Destroy(gameObject); }

        if (collision.gameObject.CompareTag("PS")) { collision.GetComponent<Obstacle>().Darah -= Attack; Destroy(gameObject); }

        if (collision.gameObject.CompareTag("Pacaran")) { collision.GetComponent<Obstacle>().Darah -= Attack; Destroy(gameObject); }
    }
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();        
    }

    private void Update()
    {
        rigidbody2D.velocity = new Vector2(10, rigidbody2D.velocity.y);

        if(transform.position.x > 50) { Destroy(gameObject); }

        Debug.Log(Attack);
    }
}
