using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
  public Rigidbody rb;
    public float speed = 0.05f;
    public bool isGrounded;
    public AudioSource audioSource;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        rb.MovePosition( rb.position + new Vector3(x, 0, z) * speed * Time.deltaTime );

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * 4, ForceMode.Impulse);
            isGrounded = false;
            audioSource.Play();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;

        if (collision.gameObject.tag == "Goal")
        {
            Destroy(collision.gameObject);

            GameManager manager = FindObjectOfType<GameManager>();
            manager.LoadNextLevel();
            
        }
    }
}
