using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//ネットワーク用
using System.Net;
using UnityEngine.Networking;

public class tCreateBox : MonoBehaviour
{
    //http用
    private string _hostUrl;

    /*ゲームオブジェクト変数*/
    GameObject _buttonBox;

    void Start()
    {
        /*ゲームオブジェクトの取得*/
        _hostUrl = GameObject.Find("tManager").GetComponent<tManager>().HostUrl;
        _buttonBox = GameObject.Find("buttonBox");

        /*buttonBoxを一時的に消す*/
        _buttonBox.SetActive(false);
    }

    /*ボタンメソッド*/
    //出願ボタン
    public void CreatePostB()
    {
        /*入力値の取得*/
        Debug.Log("create");
    }
    //戻るボタン
    public void CreateReturnB()
    {
        /*buttonBoxを再生成*/
        _buttonBox.SetActive(true);

        /*自身の削除*/
        Destroy(this.gameObject);
    }
}