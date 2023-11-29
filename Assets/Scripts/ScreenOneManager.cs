using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ScreenOneManager : MonoBehaviour
{

    public Button NextBtn;

    public Button PreviousBtn;

    public Button backButton;

    public GameObject StandByGameObject;

    public GameObject BackGroundGameObject;

    public GameObject OneState;

    public GameObject TwoState;

    public GameObject ThreeState;

    public GameObject FourState;

    public Button OneBtn;

    public Button TwoBtn;

    public Button ThreeBtn;

    public Button FourBtn;

    public Button OneBtnDwon;

    public Button TwoBtnDwon;

    public Button ThreeBtnDwon;

    public Button FourBtnDwon;


    public List<Sprite> normalSprites = new List<Sprite>();

    public List<Sprite> presSprites = new List<Sprite>();


    private List<GameObject> _curShowGameObjects;

    private List<GameObject> _oneList = new List<GameObject>();

    private List<GameObject> _twoList = new List<GameObject>();

    private List<GameObject> _threeList = new List<GameObject>();

    private List<GameObject> _fourList = new List<GameObject>();

    public float PlayTime = 1f;

    private int _curIndex = 0;

    private Coroutine _coroutine;

    private Coroutine _autoCoroutine;

    private List<GameObject> _activeList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920,1080,true);
        _oneList = GetList(OneState);
        _twoList = GetList(TwoState);
        _threeList = GetList(ThreeState);
        _fourList = GetList(FourState);

        _activeList.Add(StandByGameObject);
        _activeList.Add(OneState);
        _activeList.Add(TwoState);
        _activeList.Add(ThreeState);
        _activeList.Add(FourState);

        backButton.onClick.AddListener((() =>
        {
            ActiveObjes(StandByGameObject);
        }));

        OneBtn.onClick.AddListener((() =>
        {
            ActiveObjes(OneState);
            BtnEvent(_oneList);
            ChangeBtnSprite(0);
        }));

        TwoBtn.onClick.AddListener((() =>
        {
            ActiveObjes(TwoState);
            BtnEvent(_twoList);
            ChangeBtnSprite(1);
        }));

        ThreeBtn.onClick.AddListener((() =>
        {
            ActiveObjes(ThreeState);
            BtnEvent(_threeList);
            ChangeBtnSprite(2);
        }));

        FourBtn.onClick.AddListener((() =>
        {
            ActiveObjes(FourState);
            BtnEvent(_fourList);
            ChangeBtnSprite(3);
        }));

        OneBtnDwon.onClick.AddListener((() =>
        {
            ActiveObjes(OneState);
            BtnEvent(_oneList);
            ChangeBtnSprite(0);
        }));

        TwoBtnDwon.onClick.AddListener((() =>
        {
            ActiveObjes(TwoState);
            BtnEvent(_twoList);
            ChangeBtnSprite(1);
        }));

        ThreeBtnDwon.onClick.AddListener((() =>
        {
            ActiveObjes(ThreeState);
            BtnEvent(_threeList);
            ChangeBtnSprite(2);
        }));

        FourBtnDwon.onClick.AddListener((() =>
        {
            ActiveObjes(FourState);
            BtnEvent(_fourList);
            ChangeBtnSprite(3);
        }));





        NextBtn.onClick.AddListener((() =>
        {
            _curIndex++;
            if (_curShowGameObjects.Count <= _curIndex)
            {
                _curIndex = 0;
            }
            ShowInfo();

            if (_autoCoroutine != null) StopCoroutine(_autoCoroutine);
            if (_coroutine != null) StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(StartCalculateStandBy());

        }));

        PreviousBtn.onClick.AddListener((() =>
        {
            _curIndex--;
            if (0 >_curIndex)
            {
                _curIndex = _curShowGameObjects.Count-1;
            }

            ShowInfo();
            if (_autoCoroutine != null) StopCoroutine(_autoCoroutine);
            if (_coroutine!=null)StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(StartCalculateStandBy());
        }));

       // OneBtn.onClick.Invoke();
    }

    private void BtnEvent(List<GameObject> list)
    {
        if (_autoCoroutine != null) StopCoroutine(_autoCoroutine);
        if (_coroutine != null) StopCoroutine(_coroutine);
        _curShowGameObjects = list;
        _curIndex = -1;
        NextBtn.onClick.Invoke();
    }
    private List<GameObject> GetList(GameObject parent)
    {
        Transform[] list = parent.GetComponentsInChildren<Transform>(true);

        List<GameObject> temp = new List<GameObject>();

        foreach (Transform transform1 in list)
        {
            if (transform1.parent == parent.transform)
            {
                temp.Add(transform1.gameObject);
            }
        }

        return temp;

        
    }
    private IEnumerator StartCalculateStandBy()
    {
        yield return new WaitForSeconds(5f);
        Debug.Log("开始倒计时进入轮播");
        _autoCoroutine= StartCoroutine(AutoPlay());
    }
    private void ShowInfo()
    {
        int n = 0;
        foreach (GameObject showGameObject in _curShowGameObjects)
        {

            if (n == _curIndex)
            {
                showGameObject.gameObject.SetActive(true);
                RawImage rawImage = showGameObject.GetComponent<RawImage>();
                rawImage.DOKill();
                rawImage.DOFade(1f, 0.5f);
                showGameObject.transform.Find("RawImage").GetComponent<RawImage>().DOKill();
                showGameObject.transform.Find("RawImage").GetComponent<RawImage>().DOFade(1f, 0.5f);
            }
            else
            {
                showGameObject.transform.Find("RawImage").GetComponent<RawImage>().DOKill();
                showGameObject.transform.Find("RawImage").GetComponent<RawImage>().DOFade(0f, 0.5f);

                RawImage rawImage = showGameObject.GetComponent<RawImage>();
                rawImage.DOKill();
                rawImage.DOFade(0f, 0.5f).OnComplete((() =>
                {
                    showGameObject.SetActive(false);
                }));
            }

            n++;
        }
    }

    private void ActiveObjes(GameObject activeObj)
    {

        foreach (GameObject o in _activeList)
        {
            o.SetActive(o == activeObj);
        }
      
    }

    private void ChangeBtnSprite(int index)
    {
        OneBtnDwon.GetComponent<Image>().sprite = normalSprites[0];
        TwoBtnDwon.GetComponent<Image>().sprite = normalSprites[1];
        ThreeBtnDwon.GetComponent<Image>().sprite = normalSprites[2];
        FourBtnDwon.GetComponent<Image>().sprite = normalSprites[3];

        if (index == 0) OneBtnDwon.GetComponent<Image>().sprite = presSprites[0];
        if (index == 1) TwoBtnDwon.GetComponent<Image>().sprite = presSprites[1];
        if (index == 2) ThreeBtnDwon.GetComponent<Image>().sprite = presSprites[2];
        if (index == 3) FourBtnDwon.GetComponent<Image>().sprite = presSprites[3];
    }

    public void Exit()
    {
        Application.Quit();
    }
    private IEnumerator AutoPlay()
    {
        int count = _curShowGameObjects.Count;

        while (true)
        {
            count--;
            if (count <= 0)
            {
                ActiveObjes(StandByGameObject);
                yield break;
            }
            //Debug.Log("进行轮播 "+count);
            _curIndex++;
            if (_curShowGameObjects.Count <= _curIndex)
            {
                _curIndex = 0;
            }
            ShowInfo();
            yield return new WaitForSeconds(PlayTime);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
