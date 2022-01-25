using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Heart : MonoBehaviour
{
    [SerializeField] private float _lerpDuration;
    [SerializeField] private float _startValue;
    [SerializeField] private float _endValue;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.fillAmount = 1;
    }

    public void ToFill()
    {
        StartCoroutine(Filling(_startValue, _endValue, _lerpDuration, Fill));
    }

    public void ToEmpty()
    {
        StartCoroutine(Filling(_endValue, _startValue, _lerpDuration, Destroy));
    }

    private IEnumerator Filling(float startValue, float endValue, float duration, UnityAction<float> lerpingEnd)
    {
        float elapsed = 0;
        float nextValue;

        while (elapsed < duration)
        {
            nextValue = Mathf.Lerp(startValue, endValue, elapsed / duration);
            _image.fillAmount = nextValue;
            elapsed += Time.deltaTime;
            yield return null;
        }

        lerpingEnd?.Invoke(endValue);
    }

    private void Destroy(float value)
    {
        _image.fillAmount = value;
        Destroy(gameObject);
    }

    private void Fill(float value)
    {
        _image.fillAmount = value;
    }
}