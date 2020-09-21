using UnityEngine;

public class PlatformPlayer : MonoBehaviour
{
    public float speed = 1f;
    public float jumpPower = 10f;

    private bool lookingRight;

    private Movement2D movement;

    /// =============================================
    /// <summary>
    ///
    /// </summary>
    void Start()
    {
        this.movement = this.GetComponent<Movement2D>();

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

        if (this.movement.CanJump && Input.GetButtonDown("Jump"))
        {
            this.movement.Jump(this.jumpPower);
        }

        this.movement.Move(h * this.speed);
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
