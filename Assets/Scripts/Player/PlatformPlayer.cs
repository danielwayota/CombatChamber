using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlatformPlayer : MonoBehaviour
{
    public float speed = 1f;
    public float jumpPower = 10f;

    private Rigidbody2D body;

    /// =============================================
    /// <summary>
    ///
    /// </summary>
    void Start()
    {
        this.body = this.GetComponent<Rigidbody2D>();
    }

    /// =============================================
    /// <summary>
    ///
    /// </summary>
    void Update()
    {
        var movement = this.body.velocity;

        float h = Input.GetAxisRaw("Horizontal");
        movement.x = h * this.speed;

        if ((movement.y == 0) && Input.GetButtonDown("Jump"))
        {
            movement.y = this.jumpPower;
        }

        this.body.velocity = movement;
    }
}
