using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ScaleEffect : MonoBehaviour
{
    // Start is called before the first frame update

    public Image Prefabs;

    public float Timer = 0.5f;

    public float Scale = 2f;

    private WaitForSeconds _waitForSeconds;
    

    private List<Image> _images  = new List<Image>();

    void Start()
    {
       
    }

    private void OnEnable()
    {
        Clear();

         _waitForSeconds = new WaitForSeconds(Timer);
        StartCoroutine(WaitEnumerator());
    }


    public void Clear()
    {
        foreach (Image image in _images)
        {
            if (image != null) Destroy(image.gameObject);
        }
        _images.Clear();
    }
    private void OnDisable()
    {
        Clear();
    }
    private IEnumerator WaitEnumerator()
    {
        while (true)
        {
            yield return _waitForSeconds;

            Image image = Instantiate(Prefabs);

            _images.Add(image);
            image.rectTransform.parent = this.transform;
            image.rectTransform.localPosition = Vector2.zero;
            image.rectTransform.DOScale(Scale, 10f).SetEase(Ease.OutCubic).OnComplete((() =>
            {

                image.DOFade(0f, 0.35f).OnComplete((() =>
                {
                    Destroy(image);
                }));
               
            }));
            image.DOFade(0f, 3f).SetDelay(1f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
