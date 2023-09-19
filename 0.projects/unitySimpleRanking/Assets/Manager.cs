using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
//追加
using UnityEngine.Networking;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    /*通信用*/
    //ServerURLの記入
    string Url = @"http://localhost/simpleRanking/";
    //受信用URL
    string _getUrl = "";
    //送信用Url
    string _postUrl = "";
    //UnityWebRequestの作成
    UnityWebRequest _getRequest;
    UnityWebRequest _postRequest;

    /*uGUI用*/
    Text _rankingLabel;
    InputField _nameField;
    InputField _scoreField;

    // Start is called before the first frame update
    void Start()
    {
        /*通信用*/
        //getUrlの作成
        _getUrl = Url + @"getRanking.php";
        //postUrlの作成
        _postUrl = Url + @"postRanking.php";
        //初回リクエスト処理(エラー回避)
        _getRequest = UnityWebRequest.Get(_getUrl);

        /*uGUI用*/
        _rankingLabel = GameObject.Find("rankingLabel").GetComponent<Text>();
        _nameField = GameObject.Find("nameField").GetComponent<InputField>();
        _scoreField = GameObject.Find("scoreField").GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        //ランキングの更新
        _rankingLabel.text = _getRequest.downloadHandler.text;
    }

    public void GetRanking()
    {
        //Unityでhttp通信を行うためには非同期通信が必要
        //そのためStartCoroutineメソッドを使って、別スレッドにメソッドを実行させる
        StartCoroutine(GetRequest());
    }
    public void PostRanking()
    {
        Debug.Log(_nameField.text);
        StartCoroutine(PostRequest());
    }

    /*コルーチンメソッド*/
    //別スレッドで処理をさせる(コルーチンとして処理をさせる)ためには  
    //IEnumeratorを返り値として持つ必要があります。
    //これは別スレッドから結果が返ってくるまで非同期に何度も結果を要求する必要があるためです。
    IEnumerator GetRequest()
    {
        /*GetRequest*/
        _getRequest = UnityWebRequest.Get(_getUrl);

        /*yield return*/
        //yield returnにより、結果が還るまでこのメソッド内の以降の処理が行われない。
        //メソッドの呼び出しもとに戻って別の処理を継続する。
        yield return _getRequest.SendWebRequest();

        //通信のエラー処理
        if (_getRequest.isNetworkError || _getRequest.isHttpError)
        {
            // エラーが起きた場合はエラー内容を表示
            Debug.Log(_getRequest.error);
        }
        else
        {
            // レスポンスをテキストで表示
            Debug.Log(_getRequest.downloadHandler.text);
        }
    }
    //Post通信を行うメソッド
    //こちらはデータの送信を行う。
    IEnumerator PostRequest()
    {
        /*フォームの作成*/
        //ポストはURLのみの通信ではなく、URLに大してFromを渡すことで通信する。
        //なのでフォームを作成する必要がある。
        WWWForm form = new WWWForm();
        form.AddField("name", _nameField.text);
        form.AddField("score", _scoreField.text);

        /*PostRequest*/
        _postRequest = UnityWebRequest.Post(_postUrl,form);

        /*yield return*/
        yield return _postRequest.SendWebRequest();

        /*エラー処理*/
        if (_postRequest.isNetworkError)
        {
            //通信失敗
            Debug.Log(_postRequest.error);
        }
        else
        {
            //通信成功
            Debug.Log(_postRequest.downloadHandler.text);
        }
    }
}

