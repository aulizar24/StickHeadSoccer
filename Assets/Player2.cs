using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{    
    [SerializeField] private LayerMask groundLayerMask;
    private Player_Base2 playerBase;
    private Rigidbody2D rigidBody2d;
    private BoxCollider2D boxCollider2d;
    // Start is called before the first frame update
    private void Awake()
    {
        playerBase = gameObject.GetComponent<Player_Base2>();
        rigidBody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(IsGrounded() && Input.GetKeyDown(KeyCode.W)){
            float jumpVelocity = 25f;
            rigidBody2d.velocity = Vector2.up * jumpVelocity;
        }

        HandleMovement();
    }
    private bool IsGrounded(){
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down * .1f, groundLayerMask);
        return raycastHit2d.collider != null;
    }
    private void HandleMovement(){
        float moveSpeed = 10f;
        if(Input.GetKey(KeyCode.A)){
            rigidBody2d.velocity = new Vector2 (-moveSpeed, rigidBody2d.velocity.y);
        } else {
            if(Input.GetKey(KeyCode.D)){
                rigidBody2d.velocity = new Vector2(+moveSpeed, rigidBody2d.velocity.y);
            } else{
                rigidBody2d.velocity = new Vector2(0, rigidBody2d.velocity.y);
            }
        }
    }
}
