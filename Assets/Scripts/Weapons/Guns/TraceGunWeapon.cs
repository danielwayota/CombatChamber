using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraceGunWeapon : GunWeapon
{
    [Header("Trace Gun Weapon")]
    public float range;

    public GameObject trailPrefab;

    private LineRenderer[] trails;

    private int trailIndex;

    /// =========================================================
    /// <summary>
    ///
    /// </summary>
    protected override void Start()
    {
        base.Start();

        this.trails = new LineRenderer[this.bulletsPerShoot];

        for (int i = 0; i < this.bulletsPerShoot; i++)
        {
            GameObject go = Instantiate(this.trailPrefab);

            var line = go.GetComponent<LineRenderer>();
            line.enabled = false;

            this.trails[i] = line;

            go.transform.SetParent(this.transform);
        }

        this.trailIndex = 0;
    }

    /// =========================================================
    /// <summary>
    ///
    /// </summary>
    /// <param name="position"></param>
    /// <param name="direction"></param>
    protected override void ShootProjectile(Vector3 position, Vector3 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(position, direction, this.range);

        Vector3 shootStart = position;
        Vector3 shootEnd = position + direction * this.range;

        if (hit.collider != null)
        {
            shootEnd = hit.point;

            var health = hit.collider.GetComponent<Health>();
            if (health != null)
            {
                this.OnHit(health);
            }
        }

        StartCoroutine(this.DoTheTrail(shootStart, shootEnd, this.trailIndex));
        this.trailIndex++;
        this.trailIndex %= this.trails.Length;
    }

    /// =========================================================
    /// <summary>
    ///
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    IEnumerator DoTheTrail(Vector3 start, Vector3 end, int index)
    {
        var trail = this.trails[index];

        trail.enabled = true;

        trail.SetPosition(0, start);
        trail.SetPosition(1, end);

        yield return new WaitForSeconds(this.maxCooldownTime * 0.9f);

        trail.enabled = false;
    }
}
