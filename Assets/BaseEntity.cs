using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEntity : MonoBehaviour {
    protected int maxHealth = 50;
    protected int currHealth;
    protected bool dead = false;

    protected bool invulnerable = false;
    protected int invulFrames = 0;
    // Use this for initialization
    void Start () {
        currHealth = maxHealth;
	}

    public void TakeDamage(int damage)
    {
        if ( !(this.IsInvulnerable() || this.IsDead()) )
        {
            currHealth -= damage;
            OnTakeDamage();
        }
    }

    protected abstract void OnTakeDamage();

    public virtual void Kill()
    {
        Destroy(gameObject);
    }

    public bool IsInvulnerable() {
        return invulnerable;
    }

    public void SetInvulnerable(bool trueFalse)
    {
        invulnerable = trueFalse;    }

    public void SetInvulnerable(int duration)
    {
        invulnerable = true;
        invulFrames = duration;
    }

    public bool IsDead()
    {
        return dead;
    }
}
