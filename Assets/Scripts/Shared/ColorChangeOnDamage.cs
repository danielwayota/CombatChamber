using UnityEngine;

public class ColorChangeOnDamage : MonoBehaviour
{
    public Color damagedColor = Color.red;
    public SpriteRenderer gfx;

    public float recoverSpeed = 2f;

    private float damagedPercent = 0;
    private Color baseColor;

    /// ==============================================
    /// <summary>
    ///
    /// </summary>
    void Start()
    {
        this.baseColor = this.gfx.color;

        var h = GetComponent<Health>();
        h.OnDamage += this.OnDamageReceived;
    }

    /// ==============================================
    /// <summary>
    ///
    /// </summary>
    void Update()
    {
        if (this.damagedPercent >= 0f)
        {
            this.gfx.color = Color.Lerp(this.baseColor, this.damagedColor, this.damagedPercent);
            this.damagedPercent -= Time.deltaTime * this.recoverSpeed;
        }
    }

    /// ==============================================
    /// <summary>
    ///
    /// </summary>
    /// <param name="amount"></param>
    /// <param name="instigatorLocation"></param>
    void OnDamageReceived(float amount, Vector3 instigatorLocation)
    {
        this.damagedPercent = 1;
    }
}
