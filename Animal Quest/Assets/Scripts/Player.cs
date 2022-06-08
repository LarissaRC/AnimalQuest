using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Animator animator;
    public float speed;

    public LayerMask talkingThingsLayer;
    public GameObject dialogCloud;
    public float radious;
    bool onRadious;

    private void FixedUpdate()
    {
        Interact();
    }

    public void Interact()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radious, talkingThingsLayer);

        // Se colidir
        if(hit != null)
        {
            onRadious = true;
        }
        else
        {
            onRadious = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.magnitude);

        transform.position = transform.position + movement * speed * Time.deltaTime;

        if(onRadious)
        {
            dialogCloud.SetActive(true);
        }
        else
        {
            dialogCloud.SetActive(false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radious);
    }
}
