using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anime3D2 : MonoBehaviour
{
    //public��t���邱�ƂŁA�G�f�B�^�ォ��l����͂ł���
    public string parameter = "";
    Animator animator;
    bool flag=false;
    private void Start()
    {
        animator = this.GetComponent<Animator>();
    }
    void Update()
    {
        //�t���O�̏�����
        flag = false;
        //Key�̎�t
        if (Input.GetKey("down"))
        {
            flag = true;
        }
        //�A�j���[�V�����̕ύX
        animator.SetBool(parameter,flag);
    }
}
