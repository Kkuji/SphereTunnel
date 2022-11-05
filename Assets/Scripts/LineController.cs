using UnityEngine;

public class LineController : MonoBehaviour
{

    void Update()
    {
        transform.position += Vector3.back * UIcontroller.speed * Time.deltaTime;
        if (gameObject.transform.position.z < -8f)
            Destroy(gameObject);
    }
}
