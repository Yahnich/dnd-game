using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {

    public float maxSpeed;
    public GameObject bulletPrefab;

    private Rigidbody2D _RB2D;
    private Animator _A;
    private int _fireDelay = 30;

    private bool facingRight = true;


	// Use this for initialization
	private void Start () {
        _RB2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per fixed dt
	private void FixedUpdate () {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        _RB2D.velocity = new Vector2(moveX * maxSpeed, moveY * maxSpeed);

        if ((!facingRight && moveX > 0) || (facingRight && moveX < 0)) {
            FlipSprite();
        }
	}

    private void Update()
    {
        float fireX = Input.GetAxis("FireHorizontal");
        float fireY = Input.GetAxis("FireVertical");

        if (_fireDelay <= 0)
        {
            if (fireX != 0)
            {
                Vector2 fireDirection = new Vector2(fireX, 0);
                FireBullet(fireDirection);
            }
            else if (fireY != 0)
            {
                Vector2 fireDirection = new Vector2(0, fireY);
                FireBullet(fireDirection);
            }
        }
        else {
            --_fireDelay;
        }
        
    }

    private void FlipSprite()
    {
        facingRight = !facingRight;
        Vector3 _scale = transform.localScale;
        _scale.x *= -1;
        transform.localScale = _scale;
    }

    private void FireBullet(Vector2 fireDirection) {
        _fireDelay = 30;
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            transform.position,
            transform.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody2D>().velocity = fireDirection * 5;

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
    }
}
