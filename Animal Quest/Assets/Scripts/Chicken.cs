using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    private Rigidbody2D rig;
    private Animator anim;

    public float speed;
    public bool walking;

    public Transform rightCol;
    public Transform leftCol;

    private bool colliding;

    public LayerMask layer;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        if(walking)
        {
            anim.SetBool("walking", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(walking)
        {
            rig.velocity = new Vector2(speed, rig.velocity.y);

            colliding = Physics2D.Linecast(rightCol.position, leftCol.position, layer);

            // Se houver colisão
            if(colliding)
            {
                transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
                speed = -speed;
            }
        }
    }
}
