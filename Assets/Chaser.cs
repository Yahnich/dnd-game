using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : EntityEnemy {
    private int moveSpeed = 2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 newDestination = PlayerCharacter.reference.transform.position;
        Vector2 currPosition = this.transform.position;
        Vector2 directionVector = (newDestination - currPosition).normalized;
        GetComponent<Rigidbody2D>().velocity = directionVector * moveSpeed;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        GameObject target = coll.gameObject;
        if (target.tag.Equals("Player") == true)
        {
            BaseEntity entity = target.GetComponent<BaseEntity>();
            if (entity != null && !entity.IsInvulnerable() )
            {
                int damage = 1;

                entity.TakeDamage(damage);
            }
        }
    }
    void OnCollisionStay2D(Collision2D coll)
    {
        OnCollisionEnter2D(coll);
    }
}
