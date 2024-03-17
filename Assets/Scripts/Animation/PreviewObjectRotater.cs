using System.Collections;
using UnityEngine;

public class PreviewObjectRotater : MonoBehaviour
{
    [SerializeField] private float _rotateByXSpeed;
    [SerializeField] private float _rotateByYSpeed;
    [SerializeField] private float _rotateByZSpeed;

    private Coroutine _rotateCoroutine;

    private void OnEnable()
    {
        _rotateCoroutine = StartCoroutine(RotateCoroutine());
    }

    private IEnumerator RotateCoroutine()
    {
        while (true)
        {
            transform.Rotate(_rotateByXSpeed, _rotateByYSpeed, _rotateByZSpeed);
            yield return null;
        }
    }

    private void OnDisable()
    {
        StopCoroutine(_rotateCoroutine);
    }
}
