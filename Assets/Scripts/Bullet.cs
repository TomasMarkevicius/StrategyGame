using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20;
    public int damage = 10;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 5);
    }
    void OnCollisionEnter2D(Collision2D col){
        Character character = col.collider.GetComponent<Character>();

        if (character != null){
            character.TakeDamage(damage);
        }
        
        Destroy(gameObject);
    }

}
