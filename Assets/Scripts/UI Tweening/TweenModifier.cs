using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TweenModifier
{
    private AnimationCurve _speedCurve;
    private UnityEvent _onEnd;

    private Transform _target;

    private Vector3 _startValue;

    private TweenTypes _type;

    public TweenModifier(Transform target, TweenTypes type)
    {
        _target = target;

        _type = type;
        _startValue = GetTargetModifierValue();
        SpeedCurveFlat();
    }

    public IEnumerator Animate(Vector3 endValue, Vector3 startValue, float speed, bool reset, float waitTime)
    {
        if (startValue != Vector3.zero)
        {
            SetTargetModifier(startValue);
        }
        else
        {
            startValue = _startValue;
        }

        float t = 0;

        while (t <= waitTime)
        {
            t += Time.deltaTime;

            yield return null;
        }

        t = 0;

        while (true)
        {
            SetTargetModifier(Vector3.LerpUnclamped(startValue, endValue, _speedCurve.Evaluate(t)));

            t += Time.deltaTime * speed;
            if (t > 1)
            {
                SetTargetModifier(Vector3.LerpUnclamped(startValue, endValue, 1));
                _onEnd.Invoke();
                break;
            }
            yield return null;
        }

        if (reset)
        {
            Reset();
        }
    }

    public void Reset()
    {
        SetTargetModifier(_startValue);
    }

    private void SetTargetModifier(Vector3 value)
    {
        switch (_type) 
        {
            case TweenTypes.Position:
                _target.position = value;
                break;
            case TweenTypes.Rotation:
                _target.eulerAngles = value;
                break;
            case TweenTypes.Scale:
                _target.localScale = value;
                break;
        }
    }
    private Vector3 GetTargetModifierValue()
    {
        switch (_type)
        {
            case TweenTypes.Position:
                return _target.position;
            case TweenTypes.Rotation:
                return _target.eulerAngles;
            case TweenTypes.Scale:
                return _target.localScale;
        }

        return Vector3.zero;
    }

    public TweenModifier CustomSpeedCurve(AnimationCurve curve)
    {
        _speedCurve = curve;
        return this;
    }
    public TweenModifier SpeedCurveLinear()
    {
        _speedCurve = new AnimationCurve(new Keyframe(0, 0, 0, 1), new Keyframe(1, 1, 1, 0));
        return this;
    }
    public TweenModifier SpeedCurveEaseInOut()
    {
        _speedCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 1));
        return this;
    }
    public TweenModifier SpeedCurveEaseIn()
    {
        _speedCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 1, 2, 0));
        return this;
    }
    public TweenModifier SpeedCurveEaseOut()
    {
        _speedCurve = new AnimationCurve(new Keyframe(0, 0, 0, 2), new Keyframe(1, 1));
        return this;
    }
    public TweenModifier SpeedCurveFlat()
    {
        _speedCurve = new AnimationCurve(new Keyframe(0, 1), new Keyframe(1, 1));
        return this;
    }

    public TweenModifier CustomEnd(UnityAction customAction)
    {
        _onEnd.AddListener(customAction);
        return this;
    }
    public TweenModifier CustomEnd(UnityEvent endEvent) 
    {
        _onEnd = endEvent;
        return this;
    }
}

public enum TweenTypes
{
    Position,
    Rotation, 
    Scale
}