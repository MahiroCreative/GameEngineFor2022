using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//�l�b�g���[�N�p
using System.Net;
using UnityEngine.Networking;

public class tCreateBox : MonoBehaviour
{
    //http�p
    private string _hostUrl;

    /*�Q�[���I�u�W�F�N�g�ϐ�*/
    GameObject _buttonBox;

    void Start()
    {
        /*�Q�[���I�u�W�F�N�g�̎擾*/
        _hostUrl = GameObject.Find("tManager").GetComponent<tManager>().HostUrl;
        _buttonBox = GameObject.Find("buttonBox");

        /*buttonBox���ꎞ�I�ɏ���*/
        _buttonBox.SetActive(false);
    }

    /*�{�^�����\�b�h*/
    //�o��{�^��
    public void CreatePostB()
    {
        /*���͒l�̎擾*/
        Debug.Log("create");
    }
    //�߂�{�^��
    public void CreateReturnB()
    {
        /*buttonBox���Đ���*/
        _buttonBox.SetActive(true);

        /*���g�̍폜*/
        Destroy(this.gameObject);
    }
}