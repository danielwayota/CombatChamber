using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunWeapon : Weapon
{
    [Header("Gun")]
    public int maxAmmo;
    public int currentAmmo { get; protected set; }

    public int bulletsPerShoot = 1;

    public Transform shootPoint;

    [Header("Shoot spread")]
    public float maxDispersionAmount = 0;
    public Transform dispersionPoint;

    /// =========================================================
    /// <summary>
    ///
    /// </summary>
    protected virtual void Start()
    {
        this.currentAmmo = this.maxAmmo;
    }

    /// =========================================================
    /// <summary>
    ///
    /// </summary>
    protected override void OnActivate()
    {
        if (this.currentAmmo == 0)
            return;

        this.currentAmmo--;

        for (int i = 0; i < this.bulletsPerShoot; i++)
        {
            // bum bum

            float dispersionAmount = Random.Range(-this.maxDispersionAmount, this.maxDispersionAmount);

            Vector3 dispersionDirection = this.dispersionPoint.up * dispersionAmount;
            Vector3 dispersionTarget = this.dispersionPoint.position + dispersionDirection;

            Vector3 shootDirection = (dispersionTarget - this.shootPoint.position).normalized;

            this.ShootProjectile(this.shootPoint.position, shootDirection);
        }
    }

    /// =========================================================
    private void OnDrawGizmos()
    {
        // Draw dispersion bubble
        Gizmos.DrawWireSphere(this.dispersionPoint.position, this.maxDispersionAmount);
    }

    protected abstract void ShootProjectile(Vector3 position, Vector3 direction);
}
