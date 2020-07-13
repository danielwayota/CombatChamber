using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;

    public float percent
    {
        get { return this.currentHealth / this.maxHealth; }
    }

    protected float currentHealth;

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
    public virtual void Damage(float amount)
    {
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
        Destroy(this.gameObject);
    }
}