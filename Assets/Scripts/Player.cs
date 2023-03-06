using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //  uses the Rigidbody2D component to handle physics and movement
    //a Vector2 that stores the input from the player for horizontal and vertical movement
    public Vector2 inputVec;
    public float speed;
    Animator anim;
    Rigidbody2D rigid;
    SpriteRenderer spriter;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inputVec.x = Input.GetAxis("Horizontal");
        inputVec.y = Input.GetAxis("Vertical");
    }
    //calculates the next movement vector 
    private void FixedUpdate()

    {
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        // moves the player to the next position 
        rigid.MovePosition(rigid.position + nextVec);
    }
    private void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude);
        if (inputVec.x != 0)
        {
            spriter.flipX = inputVec.x < 0;
        }
    }
}
