using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    private float damage;
    private float height;
    private float sSpeed;
    private float fSpeed;

    private void FixedUpdate()
    {
        this.height -= this.fSpeed;
        if (this.height <= 0) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        print(coll.gameObject.tag);
        if (coll.gameObject.tag.Equals("Enemy") == true)
        {
            Destroy(coll.gameObject);
        }
    }

    public float GetDamage()
    {
        return this.damage;
    }

    public float GetHeight()
    {
        return this.height;
    }

    public float GetShotSpeed()
    {
        return this.sSpeed;
    }

    public float GetFallSpeed()
    {
        return this.fSpeed;
    }

    public void SetDamage(float newDamage)
    {
        this.damage = newDamage;
    }

    public void SetHeight(float newHeight)
    {
        this.height = newHeight;
    }

    public void SetShotSpeed(float newShotSpeed)
    {
        this.sSpeed = newShotSpeed;
    }

    public void SetFallSpeed(float newFallSpeed)
    {
        this.fSpeed = newFallSpeed;
    }
}
