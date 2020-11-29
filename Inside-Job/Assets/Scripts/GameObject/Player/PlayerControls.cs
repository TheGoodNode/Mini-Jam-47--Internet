using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    Rigidbody2D rigidbody2d;

    public float PlayerSpeed;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        this.MovePlayer();
    }


    private void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);
        Vector2 position = rigidbody2d.position;

        position += move * PlayerSpeed * Time.deltaTime;
        rigidbody2d.MovePosition(position);
    }
}
