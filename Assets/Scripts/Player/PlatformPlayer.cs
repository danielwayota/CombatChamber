using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlatformPlayer : MonoBehaviour
{
    public float speed = 1f;
    public float jumpPower = 10f;

    private Rigidbody2D body;

    private bool lookingRight;

    /// =============================================
    /// <summary>
    ///
    /// </summary>
    void Start()
    {
        this.body = this.GetComponent<Rigidbody2D>();

        this.lookingRight = true;
    }

    /// =============================================
    /// <summary>
    ///
    /// </summary>
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");

        this.FlipSprite(h);

        var movement = this.body.velocity;
        movement.x = h * this.speed;
        if ((movement.y == 0) && Input.GetButtonDown("Jump"))
        {
            movement.y = this.jumpPower;
        }

        this.body.velocity = movement;
    }

    /// =============================================
    /// <summary>
    ///
    /// </summary>
    /// <param name="direction"></param>
    void FlipSprite(float direction)
    {
        if (direction == 0)
            return;

        // Got to right
        if (direction > 0 && this.lookingRight == false)
        {
            this.lookingRight = true;
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        // Got to left
        else if (direction < 0 && this.lookingRight == true)
        {
            this.lookingRight = false;
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
