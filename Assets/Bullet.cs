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
            DestroyBulletEvent();
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        GameObject target = coll.gameObject;
        if (target.tag.Equals("Enemy") == true)
        {
            DestroyBulletEvent();
            BaseEntity entity = target.GetComponent<BaseEntity>();
            if (entity != null)
            {
                int damage = (int) this.GetDamage() * 10;
                entity.TakeDamage( damage );
            }
        }
    }

    public void DestroyBulletEvent()
    {
        Destroy(gameObject);
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
