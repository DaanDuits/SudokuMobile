using UnityEngine;

public class QuestionBoxAnimation : MonoBehaviour
{
    [SerializeField] private TweenAnimation animationData;

    public void StartAnimation()
    {
        GetComponent<UITweener>().TweenScale(animationData);
    }
}
