using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchOptionsAnimation : MonoBehaviour
{
    [SerializeField] private TweenAnimation switchToMainMenuPosition, switchToMainMenuScale;
    [SerializeField] private TweenAnimation switchBackPosition, switchBackScale;

    private UITweener _tweener;

    private void Start()
    {
        _tweener = GetComponent<UITweener>();
    }

    public void SwitchToMainMenu()
    {
        _tweener.TweenScale(switchToMainMenuScale);
        _tweener.TweenPosition(switchToMainMenuPosition);
    }

    public void SwitchBack()
    {
        _tweener.TweenPosition(switchBackPosition);
        _tweener.TweenScale(switchBackScale);
    }
}
