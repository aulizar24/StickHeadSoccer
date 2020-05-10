using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{  [SerializeField] private LayerMask groundlayerMask;
     private Player_Base PlayerBase;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;
    // Start is called before the first frame update
    private void Awake()
    {   
        PlayerBase = gameObject.GetComponent<Player_Base>();
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
        
    }

    // Update is called once per frame
    private void Update()
    {
        if(IsGrounded()&& Input.GetKeyDown(KeyCode.UpArrow)){
            float jumpVelocity = 25f;
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
        }

        HandleMovement();
    }
    private bool IsGrounded(){
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down * .1f, groundlayerMask);
        return raycastHit2d.collider != null;
    }
    private void HandleMovement(){
        float moveSpeed = 10f;
        if(Input.GetKey(KeyCode.LeftArrow)){
            rigidbody2d.velocity = new Vector2 (-moveSpeed, rigidbody2d.velocity.y);
        } else {
            if(Input.GetKey(KeyCode.RightArrow)){
                rigidbody2d.velocity = new Vector2(+moveSpeed, rigidbody2d.velocity.y);
            } else {
                rigidbody2d.velocity = new Vector2 (0, rigidbody2d.velocity.y);
            }
        }
    }
}
