using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMainMenuAnimations : MonoBehaviour
{
    [SerializeField] private TweenAnimation switchToOptionsPosition, switchToOptionsScale;
    [SerializeField] private TweenAnimation switchBackPosition, switchBackScale;

    private UITweener _tweener;

    private void Start()
    {
        _tweener = GetComponent<UITweener>();
    }

    public void SwitchToOptions()
    {
        _tweener.TweenScale(switchToOptionsScale);
        _tweener.TweenPosition(switchToOptionsPosition);
    }

    public void SwitchBack()
    {
        _tweener.TweenPosition(switchBackPosition);
        _tweener.TweenScale(switchBackScale);
    }
}
