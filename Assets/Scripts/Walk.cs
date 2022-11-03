using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Walk : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rb2D;
    public Animator playerAnimator;
    
    private float moveHorizontal;
    private float moveVertical;
    private float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = this.GetComponent<Animator>();
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        moveSpeed = 1f;
      
    }

    // Update is called once per frame
    void Update()
    {
        
        
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        
       
       if(moveHorizontal > 0.1f || moveHorizontal < 0.1f)
          {
            rb2D.velocity = new Vector2(moveHorizontal * moveSpeed, rb2D.velocity.y);
            playerAnimator.SetBool("isWalking", true);
        }
        if (moveVertical > 0.1f || moveVertical < 0.1f)
          {
              rb2D.velocity = new Vector2(rb2D.velocity.x , moveVertical * moveSpeed);
            playerAnimator.SetBool("isWalking", true);
        }
        if(moveHorizontal == 0 && moveVertical == 0 )
        {
            playerAnimator.SetBool("isWalking", false);
        }
       
        
    }

    
}
