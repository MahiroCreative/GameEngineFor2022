using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class C3RunCookie : MonoBehaviour
{
    Vector3 _speed, _firstSpeed, _jumpSpeed, _leftMove, _rightMove;
    Rigidbody _rb;
    int _state;
    int _timer;
    bool _jumpNow,_jump;

    // Start is called before the first frame update
    void Start()
    {
        //�R���|�[�l���g�擾
        _rb = this.gameObject.GetComponent<Rigidbody>();

        //���l�ݒ�
        _firstSpeed = new Vector3(0, 0, 3.2f);
        _speed = _firstSpeed;
        _jumpSpeed = new Vector3(0, 16.0f, 3.2f);
        _leftMove = new Vector3(-2.0f, 0, 0);//��
        _rightMove = new Vector3(2.0f, 0, 0);//�E

        //��ԕϐ�
        _state = 0;
        _timer = 0;

        //�t���O������
        _jumpNow = false;
    }

    // Update is called once per frame
    void Update()
    {
        //MoveCheck
        _state = MoveControll.MoveCheck();

        //�W�����v
        if (_state == 1 && _jumpNow == false)
        {
            _jumpNow = true;
            _speed = _jumpSpeed;
            Debug.Log("jump");
        }
        //��
        if (_state == 2)
        {
            _rb.position += _leftMove;
        }
        //�E
        if (_state == 3)
        {
            _rb.position += _rightMove;
        }

    }

    void FixedUpdate()
    {
        //�������x�œ���
        _rb.AddForce( _speed);

        //�W�����v�t���O������
        if (_jumpNow == true)
        {
            //�^�C�}�X�V
            _timer++;

            //�X�s�[�g������
            if (_timer > 32)
            {
                _speed = _firstSpeed;
                Debug.Log("endUp");
            }

            //�t���O������
            if(_timer > 56)
            {
                _jumpNow = false;
                _timer = 0;
                Debug.Log("endJump");
            }
        }
    }
}

//�X���C�v����
public static class MoveControll
{
    static int ans = 0;
    static float first = 0;
    static float last = 0;
    static float del = 0;
    static int inputState = 0;

    /// <summary>
    /// ���E�E�E��̂����ꂩ�̈ړ�����.
    ///�Ԃ�l(int).�����Ȃ�:0,jump:1,��2:,�E:3
    /// </summary>
    /// <returns></returns>
    public static int MoveCheck()
    {
        //������
        if (inputState == 2)
        {
            ans = 0;
            first = 0;
            last = 0;
            del = 0;
            inputState = 0;
        }
        //�N���b�N���Ɏn�_���W����
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            first = Input.mousePosition.x;
            inputState = 1;
        }
        //�N���b�N�𗣂����ۂɏI�_���W����
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            last = Input.mousePosition.x;
            inputState = 2;
            //�ړ��������o��
            del = first - last;
            //�ړ����������߂�B
            if (del < -100)
            {
                ans = 3;//�E
            }
            else if (del > 100)
            {

                ans = 2;//��
            }
            else
            {
                ans = 1;//Jump
            }
        }

        return ans;
    }
}
