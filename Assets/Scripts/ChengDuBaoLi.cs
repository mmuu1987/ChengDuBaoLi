using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using LitJson;
using UnityEngine;
using UnityEngine.UI;

public class ChengDuBaoLi : MonoBehaviour
{
    // Start is called before the first frame update


    public RawImage StandByTexture2D;

    private Configure _configure;

    private int _screenIndex = 0;

    public List<Texture2D> ContentList = new List<Texture2D>();
    private void Awake()
    {
        LoadConfigure();
    }
    void Start()
    {

        if (_configure.ShowIndex > 0)
        {
            _screenIndex = (int)_configure.ShowIndex;
            string pathName = "";
            switch (_screenIndex)
            {
                case 1:
                    pathName = "屏幕1";
                    break;
                case 2:
                    pathName = "屏幕2";
                    break;
                case 3:
                    pathName = "屏幕3";
                    break;
                case 4:
                    pathName = "屏幕4";
                    break;
                case 5:
                    pathName = "屏幕5";
                    break;

            }

            if (!string.IsNullOrEmpty(pathName))
            {
                Debug.Log($"需要加载的文件夹是：{pathName}");
                LoadPicture(pathName);

            }
            else
            {
                Debug.LogError("获取的路径名为null");
            }

        }
    }

    private void LoadPicture(string pathName)
    {
        string path = Application.streamingAssetsPath + "/" + pathName;

        string [] files = Directory.GetFiles(path);

        foreach (string file in files)
        {
            if (file.Contains("meta")) continue;

        
            DirectoryInfo info = new DirectoryInfo(file);

            string texName = info.Name.Replace(info.Extension,"");
            byte[] bytes = File.ReadAllBytes(file);

            Texture2D tex = new Texture2D(4,4);

            tex.LoadImage(bytes);

            tex.Apply();

            tex.name = texName;

            Debug.Log($"加载图片成功 {texName}");

            if (texName == "StandBy")
            {
                StandByTexture2D.texture = tex;

               
            }
            else
            {
                ContentList.Add(tex);
            }

            
        }


    }
    /// <summary>
    /// 加载配置
    /// </summary>
    private void LoadConfigure()
    {
        string path = Application.streamingAssetsPath + "/Configure.json";

        if (!File.Exists(path))
        {
            CreatConfigure(path);
        }
        else
        {
            byte[] bytes = File.ReadAllBytes(path);

            string str = Encoding.Default.GetString(bytes);

            _configure = JsonMapper.ToObject<Configure>(str);

            if (_configure != null)
            {
                Debug.Log("加载json数据成功");
            }
        }
    }

    private void CreatConfigure(string path)
    {
        _configure = new Configure();
     
        _configure.StandBy = 300f;

        _configure.ShowIndex = 0;


        SaveConfiugre(path, true);
    }

    /// <summary>
    /// 保存配置
    /// </summary>
    private void SaveConfiugre(string path, bool isFirst)
    {


        string str = JsonMapper.ToJson(_configure);

        byte[] bytes = Encoding.Default.GetBytes(str);

        if (isFirst)
        {
            if (!File.Exists(path))
            {
                File.WriteAllBytes(path, bytes);

                Debug.Log("创建json数据成功");
            }
            else
            {
                throw new UnityException("已经有了json文件");

            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadTex()
    {

    }
}
