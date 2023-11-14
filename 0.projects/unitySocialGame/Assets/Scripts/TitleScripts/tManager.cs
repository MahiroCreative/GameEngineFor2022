using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//�l�b�g���[�N�p
using System.Net;
using UnityEngine.Networking;

public class tManager : MonoBehaviour
{
    //http�p
    [SerializeField]
    string _hostUrl = @"http://localhost/socialGame/";

    /*�Q�[���I�u�W�F�N�g*/
    GameObject _buttonBox;
    GameObject _consoleBox;
    GameObject _nameInput;
    GameObject _postB;

    /*�R���|�[�l���g*/
    Image _consoleImage;
    Image _retunBImage;
    Text _consoleText;
    Text _namuText;


    private void Start()
    {
        /*�Q�[���I�u�W�F�N�g*/
        _buttonBox = GameObject.Find("buttonBox");
        _consoleBox = GameObject.Find("consoleBox");
        _nameInput = GameObject.Find("nameInput");
        _postB = GameObject.Find("postB");

        /*�R���|�[�l���g*/
        _consoleImage = GameObject.Find("consoleImage").GetComponent<Image>();
        _consoleText = GameObject.Find("consoleText").GetComponent<Text>();
        _retunBImage = GameObject.Find("returnB").GetComponent<Image>();
        _namuText = _nameInput.GetComponent<Text>();

        /*������*/
        _buttonBox.SetActive(true);
        _consoleBox.SetActive(false);
        _postB.SetActive(false);
        _nameInput.SetActive(false);
    }


    public void FixedUpdate()
    {
        /*�e�L�X�g�̍X�V*/
        if (NetManager.s_httpResult != null)
        {
            _consoleText.text = NetManager.s_httpResult;
        }



    }


    /*�{�^�����\�b�h*/
    public void LoginButton()
    {
        _buttonBox.SetActive(false);
        _consoleBox.SetActive(true);
        _consoleText.text = "�ڑ����ł�... �B";
        _consoleImage.sprite = Resources.Load<Sprite>("consoleImageLogin");
        _retunBImage.sprite = Resources.Load<Sprite>("returnImage");
    }
    public void CreateButton()
    {
        //UI�Z�b�e�B���O
        _buttonBox.SetActive(false);
        _consoleBox.SetActive(true);
        _nameInput.SetActive(true);
        _consoleText.text = "�ڑ����ł�... �B";
        _consoleImage.sprite = Resources.Load<Sprite>("consoleImageCreate");
        _retunBImage.sprite = Resources.Load<Sprite>("returnImage");

        //�l�b�g���[�N�ڑ�
        if(_nameInput)
        {

        }

    }
    public void NoticeButton()
    {
        //UI�Z�b�e�B���O
        _buttonBox.SetActive(false);
        _consoleBox.SetActive(true);
        _consoleText.text = "�ڑ����ł�... �B";
        _consoleImage.sprite = Resources.Load<Sprite>("consoleImageNotice");
        _retunBImage.sprite = Resources.Load<Sprite>("returnImage");

        //�l�b�g���[�N�ڑ�
        string passUrl = @"Notice.php";
        StartCoroutine(NetManager.HttpGetEnumerable(_hostUrl, passUrl));
    }
    public void ReturnButton()
    {
        //UI�Z�b�e�B���O
        _buttonBox.SetActive(true);
        _consoleBox.SetActive(false);
        _nameInput.SetActive(false);

        //�ڑ����ʂ�null�ɖ߂��B
        NetManager.s_httpResult = null;
    }

}
