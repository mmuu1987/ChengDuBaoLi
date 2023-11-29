using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MoveEffect : MonoBehaviour
{

    public Vector3 moveTarget;


    public ScaleEffect scaleEffect;


    private Image _image;

    private Image _scaleImage;

    private Vector3 _orinigal;

    private Coroutine _coroutine;
    // Start is called before the first frame update
    void Start()
    {

        _image = this.GetComponent<Image>();

        _scaleImage = scaleEffect.GetComponent<Image>();

        _orinigal = _image.rectTransform.anchoredPosition;

      
    }

    private IEnumerator Wait()
    {
        while (true)
        {

            yield return new WaitForSeconds(5f);

            _image.DOFade(1f, 0.5f);

            _image.rectTransform.anchoredPosition = _orinigal;
            scaleEffect.Clear();
            _image.rectTransform.DOLocalMove(moveTarget, 1f).OnComplete((() =>
            {
                scaleEffect.gameObject.SetActive(true);
            }));

            yield return new WaitForSeconds(5f);

            _image.DOFade(0f, 0.5f).OnComplete((() =>
            {
                scaleEffect.gameObject.SetActive(false);

                scaleEffect.Clear();
            }));
        }
    }

    private void OnDisable()
    {
        if(_coroutine!=null)
            StopCoroutine(_coroutine);
    }

    private void OnEnable()
    {
        _coroutine = StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
