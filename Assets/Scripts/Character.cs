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

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        if (isActive && Input.GetMouseButton(0)){
            SetTargetPosition();
        }

        if (isMoving){
            Move();
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

}
