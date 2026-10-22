using UnityEngine;

public class FrogController : MonoBehaviour
{
    public float stepSize = 1f;

    public float minY = -3.5f;
    public float maxY = 3.5f;
    public float minX = -4.5f;
    public float maxX = 4.5f;

    private Vector3 lastDirection = Vector3.up;
    private Vector3 startPosition;
    private GameObject currentLog;

    void Start()
    {
        
        Vector3 p = transform.position;
        p.y = SnapToRow(p.y);
        transform.position = p;

        startPosition = transform.position;
    }

    void Update()
    {
        if (Time.timeScale == 0f) return;

        Vector3 movement = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.UpArrow))
            movement = Vector3.up;
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            movement = Vector3.down;
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            movement = Vector3.left;
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            movement = Vector3.right;

        if (movement != Vector3.zero)
        {
            lastDirection = movement;

            Vector3 pos = transform.position;

          
            float newY = SnapToRow(pos.y) + movement.y * stepSize;
            float newX = pos.x + movement.x * stepSize;

            newY = Mathf.Clamp(newY, minY, maxY);
            newX = Mathf.Clamp(newX, minX, maxX);

            transform.position = new Vector3(newX, newY, pos.z);
        }
    }

    
    private static float SnapToRow(float y)
    {
        return Mathf.Round(y - 0.5f) + 0.5f;
    }

    public void Die()
    {
        transform.SetParent(null);
        currentLog = null;
        transform.position = startPosition;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Log"))
        {
            currentLog = other.gameObject;
            transform.SetParent(currentLog.transform, true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Log") && currentLog == other.gameObject)
        {
            transform.SetParent(null, true);
            currentLog = null;
        }
    }

    public bool IsOnLog()
    {
        return currentLog != null;
    }
}