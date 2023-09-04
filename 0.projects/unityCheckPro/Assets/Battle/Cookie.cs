using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookie : MonoBehaviour
{
    Vector3 _move,_moveDamage,_firstPos;
    GameObject[] _hpList;
    GameObject _clearUI;
    GameObject _human;
    int timer;
    int hpCount;
    bool _damaging;

    // Start is called before the first frame update
    void Start()
    {
        _move = new Vector3(0, -0.04f, 0);
        _moveDamage = new Vector3(2.4f, 0 ,0);
        _firstPos = this.transform.position;
        _hpList = new GameObject[3];
        _hpList[0] = GameObject.Find("Canvas/Hp1");
        _hpList[1] = GameObject.Find("Canvas/Hp2");
        _hpList[2] = GameObject.Find("Canvas/Hp3");
        _clearUI = GameObject.Find("Canvas/ClearUI");
        _human = GameObject.Find("Human");
        hpCount = 0;
        timer = 0;
        _clearUI.SetActive(false);
        _damaging = false;
    }


    private void Update()
    {
        //�U�����󂯂���
        if(Human._attaking == true�@&& _damaging == false)
        {
            if (Mathf.Abs(this.transform.position.x - _human.transform.position.x) < 20.0f)
            {
                Human._attaking = false;
                _hpList[hpCount].SetActive(false);
                Debug.Log("hit");
                hpCount++;
                _damaging=true;
                timer=0;

                if(hpCount>2)
                {
                    _clearUI.SetActive(true);
                }
            }
        }
    }

    //�㉺�ړ����Ă邾��
    void FixedUpdate()
    {

        if(_damaging)//�_���[�W���󂯂��ۂ̓���
        {
            /**/
            this.transform.position += _moveDamage;

            //���]
            if (timer > 4)
            {
                this.transform.position = _firstPos;
                timer = 0;
                _damaging = false;
            }
        }
        else//�ʏ퓮��
        {
            /*�㉺�ړ�*/
            this.transform.position += _move;

            //���]
            if (timer > 75)
            {
                _move *= -1;
                timer = 0;
            }
        }


        //�^�C�}�X�V
        timer++;

    }
}
