using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WorldBuilder : MonoBehaviour
{
    private int currentSpeed;

    public static float time;
    public static int attempts = 0;

    private GameObject sphere;

    private GameObject tunnel;
    private GameObject tunnelInstantiated;

    private GameObject line;
    private GameObject lineInstantiated;

    private bool newLine;

    private GameObject tunnelContinue;

    private bool firstExist;
    private bool secondExist;

    [SerializeField] private GameObject menu;
    [SerializeField] private Text timeText;
    [SerializeField] private Text numberAttempts;
    
    void Start()
    {
        attempts++;

        time = 0;
        firstExist = true;
        secondExist = false;
        newLine = true;

        currentSpeed = UIcontroller.speed;

        sphere = Resources.Load<GameObject>("Character");
        Instantiate(sphere, new Vector3(0, 0, 0), Quaternion.identity);

        tunnel = Resources.Load<GameObject>("Tunnel");
        tunnelInstantiated = Instantiate(tunnel, new Vector3(0, 0, 0), Quaternion.identity);

        line = Resources.Load<GameObject>("Line");

        tunnelContinue = null;
    }

    void Update()
    {
        if (!SphereController.dead)
        {
            if (time < 10)
                time += Time.deltaTime;

            if (firstExist)
                tunnelInstantiated.transform.position += Vector3.back * UIcontroller.speed * Time.deltaTime;

            if (secondExist)
                tunnelContinue.transform.position += Vector3.back * UIcontroller.speed * Time.deltaTime;


            if (tunnelContinue != null && firstExist == false)
            {
                if (tunnelContinue.transform.position.z < -4)
                {
                    tunnelInstantiated = Instantiate(tunnel, new Vector3(0, 0, 54), Quaternion.identity);
                    firstExist = true;
                }
            }

            if (secondExist == false)
            {
                if (tunnelInstantiated.transform.position.z < -4)
                {
                    tunnelContinue = Instantiate(tunnel, new Vector3(0, 0, 54), Quaternion.identity);
                    secondExist = true;
                }
            }
            
            if (firstExist)
            {
                if (tunnelInstantiated.transform.position.z < -58)
                {
                    Destroy(tunnelInstantiated);
                    firstExist = false;
                }
            }

            if (secondExist)
            {
                if (tunnelContinue != null)
                {
                    if (tunnelContinue.transform.position.z < -58)
                    {
                        Destroy(tunnelContinue);
                        secondExist = false;
                    }
                }
            }
            
            if (newLine)
                CreateLine();
        }
        
        if (SphereController.dead)
        {
            menu.SetActive(true);
            time = (int)time;
            timeText.text = ("Last attempt time: " + time.ToString() + " фцвц");
            numberAttempts.text = ("Еotal attempts: " + attempts.ToString());
        }
    }
    
    public void CreateLine()
    {
        float k = Random.Range(0, 7.18f);
        newLine = false;
        lineInstantiated = Instantiate(line, new Vector3(0, k, 47), Quaternion.identity);

        if (UIcontroller.speed == 5)
            Invoke(nameof(WaitTwoSeconds), 1f);

        if (UIcontroller.speed == 10)
            Invoke(nameof(WaitTwoSeconds), 0.7f);

        if (UIcontroller.speed == 15)
            Invoke(nameof(WaitTwoSeconds), 0.4f);
    }

    public void WaitTwoSeconds()
    {
        newLine = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
        UIcontroller.speed = currentSpeed;
        menu.SetActive(false);
        SphereController.dead = false;
    }

    public void ChangeDifficulty()
    {
        SceneManager.LoadScene(0);
        menu.SetActive(false);
        SphereController.dead = false;
    }
}



