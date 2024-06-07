using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public struct TweenData
{
    public float speed;
    public AnimationCurve speedCurve;
    public Vector3 tweenEnd;
    public bool resetOnEnd;
    public UnityEvent onEnd;
}