using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour {
    public GameObject bulletPrefab;
    public Text hpText;

    private const float MOVE_SPEED = 5f;
    private const float SHOT_SPEED = 7.5f;

    private float baseDamage = 3.5f;
    private float baseHeight = 25f;
    private float baseShotSpeed = 1f;
    private float baseFallSpeed = 0.3f;
    private float moveSpeed = 1.0f;
    private int fireDelay = 10;
    private int maxHealth = 5;
    private int currHealth;

    private Rigidbody2D _RB2D;
    private Animator _AI;

    private bool facingRight = true;


	// Use this for initialization
	private void Start () {
        _RB2D = GetComponent<Rigidbody2D>();
        currHealth = maxHealth;
    }
	
	// Update is called once per fixed dt
	private void FixedUpdate () {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        float fireX = Input.GetAxis("FireHorizontal");
        float fireY = Input.GetAxis("FireVertical");

        hpText.text = this.currHealth + "/" + this.maxHealth;

        _RB2D.velocity = new Vector2(moveX * moveSpeed * MOVE_SPEED, moveY * moveSpeed * MOVE_SPEED);

        if ((!facingRight && moveX > 0) || (facingRight && moveX < 0)) {
            FlipSprite();
        }

        if (fireDelay <= 0)
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
        else
        {
            --fireDelay;
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
        fireDelay = 30;
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            transform.position,
            transform.rotation);

        // Get true bullet object
        var bulletInstance = bullet.GetComponent<Bullet>();
        bulletInstance.SetDamage(this.baseDamage);
        bulletInstance.SetHeight(this.baseHeight);
        bulletInstance.SetShotSpeed(this.baseShotSpeed);
        bulletInstance.SetFallSpeed(this.baseFallSpeed);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody2D>().velocity = fireDirection * bulletInstance.GetShotSpeed() * SHOT_SPEED + this._RB2D.velocity / 3;
    }
}
