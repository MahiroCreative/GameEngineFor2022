using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anime3D2Trigger : MonoBehaviour
{
    public string jumpName="";
    bool pushFlag = false;
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if(Input.GetKey("space"))//�����L�[���������
        {
            if(pushFlag == false)//�������ςȂ��łȂ����
            {
                pushFlag = true;
                anim.SetBool(jumpName,pushFlag);
            }
        }
        else
        {
            pushFlag =false;
        }
    }
}
