using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScreenTwoManager : MonoBehaviour
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

    public GameObject FiveState;

    public GameObject SixState;

    public GameObject ServenState;

    public GameObject TimeBtnsState;

    public GameObject DaChengState;

    public GameObject JiaYuanState;

    public Button OneBtn;

    public Button TwoBtn;

    public Button ThreeBtn;

    public Button FourBtn;

    public Button FiveBtn;

    public Button SixBtn;

    public Button ServenBtn;

    public Button DaChengBtn;

    public Button JiaYuanBtn;


    public Transform TimeBtnsParent;

    public Transform NavigationParent;

    public DragEvent DragEvent;

    /// <summary>
    /// 可以打开图片的button
    /// </summary>
    List< Button> _timeButtons = new List<Button>();

    List<Button> _navigationButtons = new List<Button>();

    public List<Button> SelectJiaYuanBtn = new List<Button>();


    private List<GameObject> _curShowGameObjects;

    private List<GameObject> _oneList = new List<GameObject>();

    private List<GameObject> _twoList = new List<GameObject>();

    private List<GameObject> _threeList = new List<GameObject>();

    private List<GameObject> _fourList = new List<GameObject>();

    private List<GameObject> _fiveList = new List<GameObject>();

    private List<GameObject> _sixList = new List<GameObject>();

    private List<GameObject> _servenList = new List<GameObject>();

    private List<GameObject> _timeBtnList= new List<GameObject>();

    private List<GameObject>  _daChengList = new List<GameObject>();

    private List<GameObject> _jiaYuanList = new List<GameObject>();


    public float PlayTime = 1f;

    private int _curIndex = 0;

    private Coroutine _coroutine;

    private Coroutine _autoCoroutine;

    private List<GameObject> _activeList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
        _oneList = GetList(OneState);
        _twoList = GetList(TwoState);
        _threeList = GetList(ThreeState);
        _fourList = GetList(FourState);
        _fiveList = GetList(FiveState);
        _sixList = GetList(SixState);
        _servenList = GetList(ServenState);
        _timeBtnList = GetList(TimeBtnsState);
        _daChengList = GetList(DaChengState);
        _jiaYuanList = GetList(JiaYuanState);


        _timeButtons.AddRange(TimeBtnsParent.GetComponentsInChildren<Button>(true));


        _navigationButtons.AddRange(NavigationParent.GetComponentsInChildren<Button>(true));

        _activeList.Add(StandByGameObject);
        _activeList.Add(OneState);
        _activeList.Add(TwoState);
        _activeList.Add(ThreeState);
        _activeList.Add(FourState);
        _activeList.Add(FiveState);
        _activeList.Add(SixState);
        _activeList.Add(ServenState);
        _activeList.Add(TimeBtnsState);
        _activeList.Add(DaChengState);
        _activeList.Add(JiaYuanState);


        DaChengBtn.onClick.AddListener((() =>
        {
            ActiveObjes(DaChengState);
            BtnEvent(_daChengList);
        }));

        JiaYuanBtn.onClick.AddListener((() =>
        {
            ActiveObjes(JiaYuanState);
            BtnEvent(_jiaYuanList);
            ActiveJiaYuanBtn(true);
        }));

        foreach (Button button in _navigationButtons)
        {

            button.onClick.AddListener((() =>
            {
                ShowBtn(button.name);
            }));
         
        }

        foreach (Button button in _timeButtons)
        {
            if (button.name == "6:00")
            {
                button.onClick.AddListener((() =>
                {
                    ClickTimeBtn(1);
                })); 
            }
            else if (button.name == "7:00")
            {
                button.onClick.AddListener((() =>
                {
                    ClickTimeBtn(2);
                }));
            }
            else if (button.name == "8:00")
            {
                button.onClick.AddListener((() =>
                {
                    ClickTimeBtn(3);
                }));
            }
            else if (button.name == "10:00")
            {
                button.onClick.AddListener((() =>
                {
                    ClickTimeBtn(4);
                }));
            }
            else if (button.name == "12:00")
            {
                button.onClick.AddListener((() =>
                {
                    ClickTimeBtn(5);
                }));
            }
            else if (button.name == "13:30")
            {
                button.onClick.AddListener((() =>
                {
                    ClickTimeBtn(6);
                }));
            }
            else if (button.name == "15:00")
            {
                button.onClick.AddListener((() =>
                {
                    ClickTimeBtn(7);
                }));
            }
            else if (button.name == "16:30")
            {
                button.onClick.AddListener((() =>
                {
                    ClickTimeBtn(8);
                }));
            }
            else if (button.name == "19:00")
            {
                button.onClick.AddListener((() =>
                {
                    ClickTimeBtn(9);
                }));
            }
            else if (button.name == "21:00")
            {
                button.onClick.AddListener((() =>
                {
                    ClickTimeBtn(10);
                }));
            }
            else if (button.name == "23:30")
            {
                button.onClick.AddListener((() =>
                {
                    ClickTimeBtn(11);
                }));
            }
           
        }

        backButton.onClick.AddListener((() =>
        {
            ActiveObjes(StandByGameObject,false);
            ShowBtn(null);
            ActiveJiaYuanBtn(false);

        }));

        OneBtn.onClick.AddListener((() =>
        {
            ActiveObjes(OneState);
            BtnEvent(_oneList);
          
        }));

        TwoBtn.onClick.AddListener((() =>
        {
            ActiveObjes(TwoState);
            BtnEvent(_twoList);
          
        }));

        ThreeBtn.onClick.AddListener((() =>
        {
            ActiveObjes(ThreeState);
            BtnEvent(_threeList);
           
        }));

        FourBtn.onClick.AddListener((() =>
        {
            ActiveObjes(FourState);
            BtnEvent(_fourList);
           
        }));

        FiveBtn.onClick.AddListener((() =>
        {
            ActiveObjes(FiveState);
            BtnEvent(_fiveList);

        }));

        SixBtn.onClick.AddListener((() =>
        {
            ActiveObjes(SixState);
            BtnEvent(_sixList);

        }));

        ServenBtn.onClick.AddListener((() =>
        {
            ActiveObjes(ServenState);
            BtnEvent(_servenList);

        }));







        NextBtn.onClick.AddListener((() =>
        {
            if (_curShowGameObjects == null || _curShowGameObjects.Count == 0) return;
            _curIndex++;
            if (_curShowGameObjects.Count <= _curIndex)
            {
                //返回主页面
                _curIndex = 0;
               //backButton.onClick.Invoke();
            }
            ShowInfo();

            if (_autoCoroutine != null) StopCoroutine(_autoCoroutine);
            if (_coroutine != null) StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(StartCalculateStandBy());

        }));

        PreviousBtn.onClick.AddListener((() =>
        {

            if (_curShowGameObjects == null || _curShowGameObjects.Count == 0) return;
            _curIndex--;
            if (0 > _curIndex)
            {
                _curIndex = _curShowGameObjects.Count - 1;
            }

            ShowInfo();
            if (_autoCoroutine != null) StopCoroutine(_autoCoroutine);
            if (_coroutine != null) StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(StartCalculateStandBy());
        }));

        ShowActiveBtn();

        DragEvent.DragDirEvent += DragEvent_DragDirEvent;
        // OneBtn.onClick.Invoke();
    }

    private void DragEvent_DragDirEvent(bool obj)
    {
        if (obj)
        {
            NextBtn.onClick.Invoke();
        }
        else
        {
            PreviousBtn.onClick.Invoke();
        }
    }

    private void ClickTimeBtn(int timeBtnIndex)
    {
        ActiveObjes(TimeBtnsState);
        BtnEvent(_timeBtnList, timeBtnIndex-2);
    }

    /// <summary>
    /// 显示相应的B
    /// </summary>
    private void ShowBtn(string btnName)
    {
        Debug.Log("需要打开的是" +btnName);
        foreach (Button btn in _timeButtons)
        {
            if (btnName == btn.name)
            {
                btn.gameObject.SetActive(true);
            }
            else btn.gameObject.SetActive(false);
        }
    }
    private void BtnEvent(List<GameObject> list,int index=-1)
    {
        if (_autoCoroutine != null) StopCoroutine(_autoCoroutine);
        if (_coroutine != null) StopCoroutine(_coroutine);
        _curShowGameObjects = list;
        _curIndex = index;
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
        _autoCoroutine = StartCoroutine(AutoPlay());
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
            }
            else
            {
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

    private void ActiveObjes(GameObject activeObj,bool isShowBtn=true)
    {

        foreach (GameObject o in _activeList)
        {
            o.SetActive(o == activeObj);
        }

        DragEvent.gameObject.SetActive(isShowBtn);
        
            NextBtn.gameObject.SetActive(isShowBtn);
            PreviousBtn.gameObject.SetActive(isShowBtn);
            backButton.gameObject.SetActive(isShowBtn);
       

    }

    public void ActiveJiaYuanBtn(bool isShow)
    {
        SelectJiaYuanBtn[0].transform.parent.gameObject.SetActive(isShow);
    }

    /// <summary>
    /// 选择按钮
    /// </summary>
    public void ShowActiveBtn()
    {
        foreach (Button button in SelectJiaYuanBtn)
        {
            int index = 0;
            if (button.name == "1")
            {
                index = 0;
            }
            else if(button.name=="2")
            {
                index = 2;
            }
            else if (button.name == "3")
            {
                index = 12;
            }
            else if (button.name == "4")
            {
                index = 21;
            }

            button.onClick.AddListener((() => {

                _curIndex= index;

                ShowInfo();
                if (_autoCoroutine != null) StopCoroutine(_autoCoroutine);
                if (_coroutine != null) StopCoroutine(_coroutine);
                _coroutine = StartCoroutine(StartCalculateStandBy());

            }));
        }
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
                ActiveObjes(StandByGameObject, false);
                yield break;
            }
            //Debug.Log("进行轮播 "+count);
            _curIndex++;
            if (_curShowGameObjects.Count <= _curIndex)
            {
                backButton.onClick.Invoke();
                //_curIndex = 0;
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
