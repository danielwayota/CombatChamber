using UnityEngine;

public class Movement2D : MonoBehaviour
{

    public float knockbackMultiplier = 2;
    public float recoverSpeed = 1;

    private Rigidbody2D body;

    public bool CanJump
    {
        get => this.body.velocity.y == 0;
    }

    private Vector2 knockedMovement;
    private Vector2 movement;

    private float knockedPercent = 0;

    void Awake()
    {
        this.body = GetComponent<Rigidbody2D>();

        var h = GetComponent<Health>();
        h.OnDamage += this.OnDamageReceived;

        this.movement = Vector2.zero;
        this.knockedMovement = Vector2.zero;
    }

    void Update()
    {
        this.knockedPercent = Mathf.Clamp01(this.knockedPercent - Time.deltaTime * this.recoverSpeed);

        this.movement.y = this.body.velocity.y;
        this.knockedMovement.y = this.body.velocity.y;

        this.body.velocity = Vector2.Lerp(this.movement, this.knockedMovement, this.knockedPercent);
    }

    void OnDamageReceived(float amount, Vector3 instigatorLocation)
    {
        this.knockedPercent = 1;

        Vector2 direction = (this.transform.position - instigatorLocation).normalized;

        this.knockedMovement = direction * amount * this.knockbackMultiplier;
    }

    public void Move(float horizontal)
    {
        this.movement.x = horizontal;
    }

    public void Jump(float power)
    {
        this.movement.y = power;
        this.body.velocity = this.movement;
    }
}
