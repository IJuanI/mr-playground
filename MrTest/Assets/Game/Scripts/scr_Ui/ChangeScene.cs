using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{

    public void ChangeToScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
}
