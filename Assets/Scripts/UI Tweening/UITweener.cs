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

    public TweenModifier TweenPosition(TweenAnimation data) => TweenPosition(data.tweenEnd, data.tweenStart, data.speed, data.resetOnEnd, data.waitTime).CustomEnd(data.onEnd).CustomSpeedCurve(data.speedCurve);
    public TweenModifier TweenPosition(Vector3 endPosition, Vector3 startPosition, float speed = 1f, bool resetPositionOnEnd = false, float waitTime = 0f)
    {
        StartCoroutine(_positionModifier.Animate(endPosition, startPosition, speed, resetPositionOnEnd, waitTime));
        return _positionModifier;
    }

    public TweenModifier TweenRotation(TweenAnimation data) => TweenRotation(data.tweenEnd, data.tweenStart, data.speed, data.resetOnEnd, data.waitTime).CustomEnd(data.onEnd).CustomSpeedCurve(data.speedCurve);
    public TweenModifier TweenRotation(Vector3 endRotation, Vector3 startRotation, float speed = 1f, bool resetRotationOnEnd = false, float waitTime = 0f)
    {
        StartCoroutine(_rotationModifier.Animate(endRotation, startRotation, speed, resetRotationOnEnd, waitTime));
        return _rotationModifier;
    }

    public TweenModifier TweenScale(TweenAnimation data) => TweenScale(data.tweenEnd, data.tweenStart, data.speed, data.resetOnEnd, data.waitTime).CustomEnd(data.onEnd).CustomSpeedCurve(data.speedCurve);
    public TweenModifier TweenScale(Vector3 endScale, Vector3 startScale, float speed = 1f, bool resetScaleOnEnd = false, float waitTime = 0f) 
    {
        StartCoroutine(_scaleModifier.Animate(endScale, startScale, speed, resetScaleOnEnd, waitTime));
        return _scaleModifier;
    }
}