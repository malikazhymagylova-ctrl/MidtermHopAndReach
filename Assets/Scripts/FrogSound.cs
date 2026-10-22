using UnityEngine;

public class FrogSound : MonoBehaviour
{
    void Update()
    {
        if (Time.timeScale == 0f) return;
        if (Input.GetKeyDown(KeyCode.UpArrow) ||
            Input.GetKeyDown(KeyCode.DownArrow) ||
            Input.GetKeyDown(KeyCode.LeftArrow) ||
            Input.GetKeyDown(KeyCode.RightArrow))
        {
            SoundManager.Instance.PlayHop();
        }
    }
}