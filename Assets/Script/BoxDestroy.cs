using UnityEngine;

public class BoxDestroy : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Warnet"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("PS"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Pacaran"))
        {
            Destroy(collision.gameObject);
        }
    }
}
