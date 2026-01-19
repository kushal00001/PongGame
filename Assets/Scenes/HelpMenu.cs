using UnityEngine;

public class HelpMenu : MonoBehaviour
{
    public GameObject helpScreen;
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            isPaused = !isPaused;
            helpScreen.SetActive(isPaused);
            Time.timeScale = isPaused ? 0f : 1f;
        }
    }
}
