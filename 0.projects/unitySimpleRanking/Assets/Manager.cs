using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
//�ǉ�
using UnityEngine.Networking;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    /*�ʐM�p*/
    //ServerURL�̋L��
    string Url = @"http://localhost/simpleRanking/";
    //��M�pURL
    string _getUrl = "";
    //���M�pUrl
    string _postUrl = "";
    //UnityWebRequest�̍쐬
    UnityWebRequest _getRequest;
    UnityWebRequest _postRequest;

    /*uGUI�p*/
    Text _rankingLabel;
    InputField _nameField;
    InputField _scoreField;

    // Start is called before the first frame update
    void Start()
    {
        /*�ʐM�p*/
        //getUrl�̍쐬
        _getUrl = Url + @"getRanking.php";
        //postUrl�̍쐬
        _postUrl = Url + @"postRanking.php";
        //���񃊃N�G�X�g����(�G���[���)
        _getRequest = UnityWebRequest.Get(_getUrl);

        /*uGUI�p*/
        _rankingLabel = GameObject.Find("rankingLabel").GetComponent<Text>();
        _nameField = GameObject.Find("nameField").GetComponent<InputField>();
        _scoreField = GameObject.Find("scoreField").GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        //�����L���O�̍X�V
        _rankingLabel.text = _getRequest.downloadHandler.text;
    }

    public void GetRanking()
    {
        //Unity��http�ʐM���s�����߂ɂ͔񓯊��ʐM���K�v
        //���̂���StartCoroutine���\�b�h���g���āA�ʃX���b�h�Ƀ��\�b�h�����s������
        StartCoroutine(GetRequest());
    }
    public void PostRanking()
    {
        Debug.Log(_nameField.text);
        StartCoroutine(PostRequest());
    }

    /*�R���[�`�����\�b�h*/
    //�ʃX���b�h�ŏ�����������(�R���[�`���Ƃ��ď�����������)���߂ɂ�  
    //IEnumerator��Ԃ�l�Ƃ��Ď��K�v������܂��B
    //����͕ʃX���b�h���猋�ʂ��Ԃ��Ă���܂Ŕ񓯊��ɉ��x�����ʂ�v������K�v�����邽�߂ł��B
    IEnumerator GetRequest()
    {
        /*GetRequest*/
        _getRequest = UnityWebRequest.Get(_getUrl);

        /*yield return*/
        //yield return�ɂ��A���ʂ��҂�܂ł��̃��\�b�h���̈ȍ~�̏������s���Ȃ��B
        //���\�b�h�̌Ăяo�����Ƃɖ߂��ĕʂ̏������p������B
        yield return _getRequest.SendWebRequest();

        //�ʐM�̃G���[����
        if (_getRequest.isNetworkError || _getRequest.isHttpError)
        {
            // �G���[���N�����ꍇ�̓G���[���e��\��
            Debug.Log(_getRequest.error);
        }
        else
        {
            // ���X�|���X���e�L�X�g�ŕ\��
            Debug.Log(_getRequest.downloadHandler.text);
        }
    }
    //Post�ʐM���s�����\�b�h
    //������̓f�[�^�̑��M���s���B
    IEnumerator PostRequest()
    {
        /*�t�H�[���̍쐬*/
        //�|�X�g��URL�݂̂̒ʐM�ł͂Ȃ��AURL�ɑ債��From��n�����ƂŒʐM����B
        //�Ȃ̂Ńt�H�[�����쐬����K�v������B
        WWWForm form = new WWWForm();
        form.AddField("name", _nameField.text);
        form.AddField("score", _scoreField.text);

        /*PostRequest*/
        _postRequest = UnityWebRequest.Post(_postUrl,form);

        /*yield return*/
        yield return _postRequest.SendWebRequest();

        /*�G���[����*/
        if (_postRequest.isNetworkError)
        {
            //�ʐM���s
            Debug.Log(_postRequest.error);
        }
        else
        {
            //�ʐM����
            Debug.Log(_postRequest.downloadHandler.text);
        }
    }
}

