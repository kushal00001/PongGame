using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        float move = Input.GetAxis("Vertical");
        transform.Translate(Vector2.up * move * speed * Time.deltaTime);

        if (Input.GetKey("escape"))
            Application.Quit();
    }
}
