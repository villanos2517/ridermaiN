using UnityEngine;

public class MyCarController : MonoBehaviour
{
    private SurfaceEffector2D surfaceEffector2D;
    private Rigidbody2D rb;
    private bool onGround = false;

    public float jumpForce = 7f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<SurfaceEffector2D>(out var effector))
        {
            onGround = true;
            surfaceEffector2D = effector;
        }
    }

    private void Update()
    {
        if (surfaceEffector2D == null) return;

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            surfaceEffector2D.speed = 10f;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            surfaceEffector2D.speed = 5f;
        }
        UIManager.Instance.UpdateSurfaceText($"Surface Speed : {surfaceEffector2D.speed:F1}");

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            Jump();
        }
        UIManager.Instance.UpdateCarSpeedText($"Car Speed : {rb.linearVelocity.magnitude:F1}");

        // 공중에 있을 때 방향키로 회전
        if (!onGround)
        {
            float torque = 0f;
            if (Input.GetKey(KeyCode.RightArrow))
            {
                torque = -0.5f; // 시계 방향 회전
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                torque = 0.5f; // 반시계 방향 회전
            }

            if (torque != 0f)
            {
                rb.AddTorque(torque, ForceMode2D.Force);
            }
        }
    }

    private void Jump()
    {
        onGround = false;

        if (rb == null) return;

        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
