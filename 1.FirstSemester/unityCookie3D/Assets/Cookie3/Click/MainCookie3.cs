using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCookie3 : MonoBehaviour
{
    Vector3 _arrow1, _arrow2, _arrow3;
    Vector3 _delScale;
    Vector3 _firstSize;
    Quaternion _delQ, _delQIn, _delQout;
    bool _onClick, _inClick;

    // Start is called before the first frame update
    void Start()
    {
        //�C���X�^���X�̐���
        _arrow1 = new Vector3(0.0f, 0.0f, 1.0f);//��]�̐^��
        _delScale = new Vector3(0.02f, 0.02f, 0.01f);//�T�C�Y���傫���Ȃ�P�ʎ���

        //�ŏ��̃T�C�Y
        _firstSize = this.transform.localScale;

        //��]�x����
        _delQ = Quaternion.AngleAxis(0.4f, _arrow1);

        //�t���O������
        _onClick = false;
        _inClick = false;
    }
    private void FixedUpdate()
    {
        //�펞��]
        this.GetComponent<Rigidbody>().rotation = _delQ * this.transform.rotation;

        //�N���b�N���ɏk��
        if (_inClick)
        {
            this.transform.localScale -= _delScale;
        }

        //�T�C�Y���߂�
        if (_inClick == false && _onClick == true)
        {
            this.transform.localScale += _delScale * 1.5f;
        }

    }
    private void Update()
    {
        //�N���b�N��
        if (Input.GetMouseButtonDown(0) && _inClick == false)
        {
            Debug.Log("onClick");
            _onClick = true;
            _inClick = true;
        }

        //���̃T�C�Y�ɖ߂��Ă���Œ�
        if (this.transform.localScale.x < 0.8f)
        {
            Debug.Log("inClick");
            _inClick = false;
        }

        //���̃T�C�Y�ɖ߂�����
        if ((this.transform.localScale.x > _firstSize.x) && _onClick == true)
        {
            Debug.Log("outClick");
            this.transform.localScale = _firstSize;
            _onClick = false;
            _inClick = false;
        }
    }
}
