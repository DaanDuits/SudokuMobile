using UnityEngine;

public class QuestionBoxAnimation : MonoBehaviour
{
    [SerializeField] private TweenData animationData;

    public void StartAnimation()
    {
        GetComponent<UITweener>().TweenScale(animationData);
    }
}
