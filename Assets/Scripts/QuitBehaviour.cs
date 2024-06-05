using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitBehaviour : MonoBehaviour
{
    [SerializeField] private MessageData quitRequest;
    public void QuitToMenuRequest()
    {
        MessageCreator.CreateNewMessage(quitRequest);
    }
    public void QuitToMenu()
    {
        SceneManager.LoadScene(0);
    }
}