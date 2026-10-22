using UnityEngine;

public class DashScript : MonoBehaviour
{
    public float stepSize = 1f;
    public int dashSteps = 2;
    public float cooldown = 0.3f;
    public SpriteRenderer bottomArea;
    public SpriteRenderer topArea;

    private Vector2 lastDirection = Vector2.up;
    private float nextDashTime = 0f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (Time.timeScale == 0f) return;
        if (Input.GetKeyDown(KeyCode.UpArrow)) lastDirection = Vector2.up;
        if (Input.GetKeyDown(KeyCode.DownArrow)) lastDirection = Vector2.down;
        if (Input.GetKeyDown(KeyCode.LeftArrow)) lastDirection = Vector2.left;
        if (Input.GetKeyDown(KeyCode.RightArrow)) lastDirection = Vector2.right;

        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextDashTime)
        {
            TryDash();
        }
    }

    void TryDash()
    {
        Vector3 target = transform.position + (Vector3)(lastDirection * stepSize * dashSteps);
        float half = stepSize * 0.5f;

        target.x = Mathf.Clamp(target.x, bottomArea.bounds.min.x + half, bottomArea.bounds.max.x - half);
        target.y = Mathf.Clamp(target.y, bottomArea.bounds.min.y + half, topArea.bounds.max.y - half);

        if (Vector3.Distance(target, transform.position) < 0.01f) return;
        if (!GameManager.Instance.UseCharge()) return;

        SoundManager.Instance.PlayDash();

        transform.position = target;
        if (rb != null) rb.position = target;
        Physics2D.SyncTransforms();

        nextDashTime = Time.time + cooldown;
    }
}