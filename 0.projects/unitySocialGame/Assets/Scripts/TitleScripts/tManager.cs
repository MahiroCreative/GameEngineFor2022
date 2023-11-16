using System;
using UnityEngine;
using UnityEngine.UI;

public class tManager : MonoBehaviour
{
    //http用
    [SerializeField]
    private string _hostUrl = @"http://localhost/socialGame/";
    public string HostUrl { get { return _hostUrl; } }

    /*ゲームオブジェクトの変数*/
    [SerializeField]
    public GameObject LoginBox, CreateBox, NoticeBox;
    private GameObject _canvas, _buttonBox;

    /*コンポーネント変数*/
    Text _userIdLabel;

    /*変数*/
    bool _isUserID = false;

    private void Start()
    {
        /*Debug*/
        PlayerPrefs.SetString("userID", "0001");
        PlayerPrefs.SetString("userPass", "abcd");

        /*ゲームオブジェクト取得*/
        _canvas = GameObject.Find("Canvas");
        _buttonBox = GameObject.Find("buttonBox");

        /*コンポーネントの取得*/
        _userIdLabel = GameObject.Find("userIdLabel").GetComponent<Text>();

        /*userIDの確認*/
        var temp = PlayerPrefs.GetString("userID", String.Empty);
        if (temp != string.Empty)
        {
            //IDがある場合
            _userIdLabel.text = $"ID:{temp}";

        }
        else
        {
            //IDが無い場合
            _userIdLabel.text = $"userID: none ID.";
        }

    }

    /*ボタンメソッド*/
    public void LoginButton()
    {
        /*プレハブの作成と初期化*/
        GameObject tempObj = InstantiateuGUIBox(LoginBox, _canvas, "loginBox");
    }
    public void CreateButton()
    {
        /*プレハブの作成と初期化*/
        GameObject tempObj = InstantiateuGUIBox(CreateBox, _canvas, "createBox");

    }
    public void NoticeButton()
    {
        /*プレハブの作成と初期化*/
        GameObject tempObj = InstantiateuGUIBox(NoticeBox,_canvas,"noticeBox");
    }

    /*メソッド*/
    /// <summary>
    /// 【ユーザ定義】uGUI上にuiBOXを作成(create,login,notice).
    /// </summary>
    /// <param name="createObj">作成するオブジェクト</param>
    /// <param name="parentObj">親オブジェクト</param>
    /// <param name="objName">作成するオブジェクト名</param>
    private GameObject InstantiateuGUIBox(GameObject createObj,GameObject parentObj,string objName)
    {
        //プレハブの作成
        var tempObj = Instantiate(createObj);
        //親オブジェクトの設定
        tempObj.transform.SetParent(parentObj.transform);
        //オブジェクトの名前を入力
        tempObj.name = objName;
        //作成したオブジェクトの位置
        tempObj.GetComponent<RectTransform>().anchoredPosition= Vector3.zero;
        //retrun
        return tempObj;
    }
}
