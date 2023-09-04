using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class C3Cookie : MonoBehaviour
{
    public bool _trigger = false;
    Rigidbody _rb;
    Vector3 _UpDown;
    int _timer;
    int _state;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _UpDown = new Vector3(0,0.01f,0);
        _timer = 0;
        _state = 0;
    }

    void FixedUpdate()
    {
        /*���[�V����*/
        //�ҋ@
        if (_state == 0)
        {
            Wait();
        }
    }


    /*�R���C�_�[*/
    void OnTriggerEnter(Collider other)
    {
        _trigger = true;
    }
    void OnTriggerExit(Collider other)
    {
        _trigger = false;
    }

    /*����*/
    //�ҋ@
    void  Wait()
    {
        /*���쏈��*/
        if(_timer < 50)
        {
            _rb.position += _UpDown;
        }
        else
        {
            _rb.position -= _UpDown;
        }

        /*timer�X�V*/
        _timer++;

        /*timer������*/
        if (_timer >= 100)
        {
            _timer = 0;
        }
    }
}
