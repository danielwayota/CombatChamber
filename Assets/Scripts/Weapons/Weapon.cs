using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [Header("Weapon")]
    public GameObject weaponItemPrefab;

    public float maxCooldownTime = 1f;
    private float cooldownTime;

    public float damage = 1;

    public bool IsReady => this.cooldownTime >= this.maxCooldownTime;

    /// =========================================================
    /// <summary>
    ///
    /// </summary>
    protected void Awake()
    {
        this.cooldownTime = this.maxCooldownTime;
    }

    /// =========================================================
    /// <summary>
    ///
    /// </summary>
    protected void Update()
    {
        if (this.IsReady == false)
        {
            this.cooldownTime += Time.deltaTime;
        }
    }

    /// =========================================================
    /// <summary>
    ///
    /// </summary>
    public void Activate()
    {
        if (this.IsReady)
        {
            // Shoot, attack and stuff
            this.OnActivate();

            this.cooldownTime = 0;
        }
    }

    /// =========================================================
    /// <summary>
    ///
    /// </summary>
    /// <param name="health"></param>
    public virtual void OnHit(Health health)
    {
        health.Damage(this.damage);
    }

    /// =========================================================
    /// <summary>
    ///
    /// </summary>
    public void Throw()
    {
        Instantiate(this.weaponItemPrefab, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    protected abstract void OnActivate();
}
