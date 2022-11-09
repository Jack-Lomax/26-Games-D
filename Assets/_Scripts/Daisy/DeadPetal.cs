using UnityEngine;
using DG.Tweening;

public class DeadPetal : MonoBehaviour
{
    void Start()
    {
        transform.DOScale(Vector3.zero, 1.5f).SetEase(Ease.InSine);
        transform.DORotate(Vector3.zero, 1.5f, RotateMode.FastBeyond360).SetEase(Ease.InSine);
    }

    void Update()
    {
        if(transform.localScale.magnitude == 0)
            Destroy(gameObject);
    }
}
