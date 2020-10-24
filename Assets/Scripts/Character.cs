using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    [Range(2,50)]
    private float speed = 20;

    private Vector3 targetPosition;
    private bool isMoving = false;
    public bool isActive = false;
    public GameObject highlight;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start(){
        highlight = GameObject.Find(gameObject.name + "/highlight");
        // highlight.GetComponent<SpriteRenderer>().color = Color.red;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update(){
        if (isActive && Input.GetMouseButton(0)){
            SetTargetPosition();
        }
        if (isMoving){
            Move();
        }
        if (isActive && Input.GetKeyDown(KeyCode.Space)){
            TakeDamage(20);
        }
    }

    void SetTargetPosition(){
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = transform.position.z;
        
        isMoving = true;
    }

    void Move(){
        // transform.rotation = Quaternion.LookRotation(Vector3.forward, targetPosition);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if (transform.position == targetPosition){
            isMoving = false;
        }
    }

    // Stopping bounciness on collision
    void OnCollisionEnter2D(Collision2D col){
        isMoving = false;
    }

    public void SetActive(){
        isActive = true;
        highlight.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void SetNotActive(){
        isActive = false;
        highlight.GetComponent<SpriteRenderer>().enabled = false;
    }

    void TakeDamage(int damage){
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
