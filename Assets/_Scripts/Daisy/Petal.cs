using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Petal : MonoBehaviour
{
    public bool isPicked = false;
    Vector3 scaleOnStart;

    void Start()
    {
        scaleOnStart = transform.localScale;
    }

    public void Pick()
    {
        isPicked = true;
        transform.DOScale(Vector3.zero, 1f).SetEase(Ease.OutExpo);
    }

    public void Grow()
    {
        isPicked = false;
        transform.DOScale(scaleOnStart, 1f).SetEase(Ease.OutExpo);
    }
}
