using UnityEngine;
using UnityEngine.SceneManagement;

public class UIcontroller : MonoBehaviour
{
    public static int speed = 0;
    [SerializeField] private GameObject error;

    public void EasyDifficult()
    {
        speed = 5;
    }
    public void MediumDifficult()
    {
        speed = 10;
    }
    public void HighDifficult()
    {
        speed = 15;
    }
    public void StartButton()
    {
        if (speed >= 5)
        {
            if (error.activeSelf)
                error.SetActive(false);

            SceneManager.LoadScene(1);

        }
        else
            error.SetActive(true);
    }
}
