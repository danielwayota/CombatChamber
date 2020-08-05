using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGunWeapon : GunWeapon
{
    [Header("Projectile Gun Weapon")]
    public GameObject projectilePrefab;

    /// =========================================================
    /// <summary>
    ///
    /// </summary>
    /// <param name="position"></param>
    /// <param name="direction"></param>
    protected override void ShootProjectile(Vector3 position, Vector3 direction)
    {
        float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) - 90;
        var rotation = Quaternion.Euler(0, 0, angle);

        var bullet = Instantiate(this.projectilePrefab, position, rotation);

        bullet.GetComponent<Projectile>().weapon = this;
    }
}
