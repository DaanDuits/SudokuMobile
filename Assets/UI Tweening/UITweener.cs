using UnityEngine;

public class UITweener : MonoBehaviour
{
    private TweenModifier _positionModifier, _rotationModifier, _scaleModifier;

    private void Start()
    {
        _positionModifier = new TweenModifier(transform, TweenTypes.Position);
        _rotationModifier = new TweenModifier(transform, TweenTypes.Rotation);
        _scaleModifier = new TweenModifier(transform, TweenTypes.Scale);
    }

    public void ResetAnimation()
    {
        _positionModifier.Reset();
        _rotationModifier.Reset();
        _scaleModifier.Reset();
    }

    public TweenModifier TweenPosition(TweenData data) => TweenPosition(data.tweenEnd, data.speed, data.resetOnEnd).CustomEnd(data.onEnd).CustomSpeedCurve(data.speedCurve);
    public TweenModifier TweenPosition(Vector3 position, bool resetPositionOnEnd) => TweenPosition(position, resetPositionOnEnd);
    public TweenModifier TweenPosition(Vector3 position, float speed = 1f, bool resetPositionOnEnd = false)
    {
        StartCoroutine(_positionModifier.Animate(position, speed, resetPositionOnEnd));
        return _positionModifier;
    }

    public TweenModifier TweenRotation(TweenData data) => TweenRotation(data.tweenEnd, data.speed, data.resetOnEnd).CustomEnd(data.onEnd).CustomSpeedCurve(data.speedCurve);
    public TweenModifier TweenRotation(Vector3 rotation, bool resetRotationOnEnd) => TweenRotation(rotation, resetRotationOnEnd);
    public TweenModifier TweenRotation(Vector3 rotation, float speed = 1f, bool resetRotationOnEnd = false)
    {
        StartCoroutine(_rotationModifier.Animate(rotation, speed, resetRotationOnEnd));
        return _rotationModifier;
    }

    public TweenModifier TweenScale(TweenData data) => TweenScale(data.tweenEnd, data.speed, data.resetOnEnd).CustomEnd(data.onEnd).CustomSpeedCurve(data.speedCurve);
    public TweenModifier TweenScale(Vector3 scale, bool resetScaleOnEnd) => TweenScale(scale, resetScaleOnEnd);
    public TweenModifier TweenScale(Vector3 scale, float speed = 1f, bool resetScaleOnEnd = false) 
    {
        StartCoroutine(_scaleModifier.Animate(scale, speed, resetScaleOnEnd));
        return _scaleModifier;
    }
}