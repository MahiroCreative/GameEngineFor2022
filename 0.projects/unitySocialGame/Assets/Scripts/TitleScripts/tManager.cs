using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//ネットワーク用
using System.Net;
using UnityEngine.Networking;

public class tManager : MonoBehaviour
{
    //http用
    [SerializeField]
    string _hostUrl = @"http://localhost/socialGame/";

    /*ゲームオブジェクト*/
    GameObject _buttonBox;
    GameObject _consoleBox;
    GameObject _nameInput;
    GameObject _postB;

    /*コンポーネント*/
    Image _consoleImage;
    Image _retunBImage;
    Text _consoleText;
    Text _namuText;


    private void Start()
    {
        /*ゲームオブジェクト*/
        _buttonBox = GameObject.Find("buttonBox");
        _consoleBox = GameObject.Find("consoleBox");
        _nameInput = GameObject.Find("nameInput");
        _postB = GameObject.Find("postB");

        /*コンポーネント*/
        _consoleImage = GameObject.Find("consoleImage").GetComponent<Image>();
        _consoleText = GameObject.Find("consoleText").GetComponent<Text>();
        _retunBImage = GameObject.Find("returnB").GetComponent<Image>();
        _namuText = _nameInput.GetComponent<Text>();

        /*初期化*/
        _buttonBox.SetActive(true);
        _consoleBox.SetActive(false);
        _postB.SetActive(false);
        _nameInput.SetActive(false);
    }


    public void FixedUpdate()
    {
        /*テキストの更新*/
        if (NetManager.s_httpResult != null)
        {
            _consoleText.text = NetManager.s_httpResult;
        }



    }


    /*ボタンメソッド*/
    public void LoginButton()
    {
        _buttonBox.SetActive(false);
        _consoleBox.SetActive(true);
        _consoleText.text = "接続中です... 。";
        _consoleImage.sprite = Resources.Load<Sprite>("consoleImageLogin");
        _retunBImage.sprite = Resources.Load<Sprite>("returnImage");
    }
    public void CreateButton()
    {
        //UIセッティング
        _buttonBox.SetActive(false);
        _consoleBox.SetActive(true);
        _nameInput.SetActive(true);
        _consoleText.text = "接続中です... 。";
        _consoleImage.sprite = Resources.Load<Sprite>("consoleImageCreate");
        _retunBImage.sprite = Resources.Load<Sprite>("returnImage");

        //ネットワーク接続
        if(_nameInput)
        {

        }

    }
    public void NoticeButton()
    {
        //UIセッティング
        _buttonBox.SetActive(false);
        _consoleBox.SetActive(true);
        _consoleText.text = "接続中です... 。";
        _consoleImage.sprite = Resources.Load<Sprite>("consoleImageNotice");
        _retunBImage.sprite = Resources.Load<Sprite>("returnImage");

        //ネットワーク接続
        string passUrl = @"Notice.php";
        StartCoroutine(NetManager.HttpGetEnumerable(_hostUrl, passUrl));
    }
    public void ReturnButton()
    {
        //UIセッティング
        _buttonBox.SetActive(true);
        _consoleBox.SetActive(false);
        _nameInput.SetActive(false);

        //接続結果をnullに戻す。
        NetManager.s_httpResult = null;
    }

}
