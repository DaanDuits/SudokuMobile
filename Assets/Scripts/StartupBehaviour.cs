using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartupBehaviour : MonoBehaviour
{
    [SerializeField] private Button continueButton;
    public float difficultyPercentage
    {
        get; private set;
    }

    private bool shouldContinue
    {
        get; set;
    }
    
    private void Start()
    {
        continueButton.interactable = GetComponent<PersistentSudoku>().CanLoad;
    }

    public void SetDifficulty(float difficulty)
    {
        difficultyPercentage = difficulty;
    }

    public void Continue()
    {
        shouldContinue = true;
    }

    public void LoadSudokuScene()
    {
        SceneManager.LoadScene(1);
    }

    public bool canContinue()
    {
        return shouldContinue;
    }
}