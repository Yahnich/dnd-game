using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityEnemy : BaseEntity {
    protected bool champion = false;
    protected bool boss = false;

    protected EntityEnemy()
    {
    }

    private bool IsChampion() {
        return champion;
    }

    private bool IsBoss()
    {
        return boss;
    }

    protected override void OnTakeDamage() {
        if (currHealth <= 0)
        {
            this.Kill();
        }
    }
}
