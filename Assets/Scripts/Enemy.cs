using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    public float speed = -100f;
    Rigidbody2D rbPlayer;
    private void Start()
    {
        rbPlayer = this.GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {
        Move2();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("EndOfView"))
        {
            //Destroy(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }

    void Move1()
    {
        speed = -5;
        Vector3 position = transform.position;
        position.x += speed * Time.deltaTime;
        transform.position = position;
    }
    void Move2()
    {  
        rbPlayer.velocity = new Vector2(speed * Time.deltaTime, rbPlayer.velocity.y); // moving to the left side
    }
}