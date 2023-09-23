using UnityEngine;

public class PlayerChildCurrent : MonoBehaviour
{
    [SerializeField] private Transform UP, DOWN;
    public bool Kondisi;    
    // Update is called once per frame
    void Update()
    {
        if (Kondisi)       
            transform.position = Vector2.MoveTowards(transform.position, UP.position, 0.1f);        
        else
            transform.position = Vector2.MoveTowards(transform.position, DOWN.position, 0.1f);
    }
}
