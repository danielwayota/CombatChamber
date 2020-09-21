using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    public float maxHealth;

    public float percent
    {
        get { return this.currentHealth / this.maxHealth; }
    }

    protected float currentHealth;

    public Action<float, Vector3> OnDamage;
    public Action OnDeath;

    /// ============================================
    /// <summary>
    ///
    /// </summary>
    protected virtual void Awake()
    {
        this.currentHealth = this.maxHealth;
    }

    /// ============================================
    /// <summary>
    ///
    /// </summary>
    /// <param name="amount"></param>
    public virtual void Restore(float amount)
    {
        this.currentHealth = Mathf.Clamp(this.currentHealth + amount, 0, this.maxHealth);
    }

    /// ============================================
    /// <summary>
    ///
    /// </summary>
    /// <param name="amount"></param>
    public virtual void Damage(float amount, Vector3 instigatorLocation)
    {
        if (this.OnDamage != null)
        {
            this.OnDamage(amount, instigatorLocation);
        }

        this.currentHealth = Mathf.Clamp(this.currentHealth - amount, 0, this.maxHealth);

        if (this.currentHealth == 0)
        {
            this.Die();
        }
    }

    /// ============================================
    /// <summary>
    ///
    /// </summary>
    public virtual void Die()
    {
        if (this.OnDeath != null)
        {
            this.OnDeath();
        }

        Destroy(this.gameObject);
    }
}