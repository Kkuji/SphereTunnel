using UnityEngine;

public class SphereController : MonoBehaviour
{
    private bool timeEnded = true;
    private float verticalSpeed = 0.01f;
    public static bool dead = false;
    
    void Update()
    {
        if (!dead)
        {
            if (Input.GetKey(KeyCode.Space) && transform.position.y < 7)
                transform.position = new Vector3(transform.position.x, transform.position.y + verticalSpeed, transform.position.z);
                
            if (!Input.GetKey(KeyCode.Space) && transform.position.y > 0.2)
                transform.position = new Vector3(transform.position.x, transform.position.y - verticalSpeed, transform.position.z);

            if (timeEnded)
            {
                Invoke("AddSpeed", 15f);
                timeEnded = false;
            }
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Line"))
        {
            UIcontroller.speed = 0;
            dead = true;
        }
    }

    public void AddSpeed()
    {
        verticalSpeed += 0.002f;
        timeEnded = true;
    }
}
