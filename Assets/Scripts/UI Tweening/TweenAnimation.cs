using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public struct TweenAnimation
{
    public float speed;
    public AnimationCurve speedCurve;
    public Vector3 tweenEnd;
    public Vector3 tweenStart;
    public float waitTime;
    public bool resetOnEnd;
    public UnityEvent onEnd;
}