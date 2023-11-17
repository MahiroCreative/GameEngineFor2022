using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class myQ3 : MonoBehaviour
{
    float _angle;
    Vector3 _axis;
    MyQuaternion q;

    // Start is called before the first frame update
    void Start()
    {
        //��]�p�x(�p���x�łȂ����Ƃɒ���)
        _angle = 2 * Mathf.PI * 0.001f;//0.36�x

        //��]���̍쐬
        _axis = new Vector3(1, 1, 1);

        //��]����P�ʍs��ɒ���(���K������)
        _axis.Normalize();

        //��]�N�H�[�^�j�I���̍쐬
        //(w:���� , ijk:���� �Ƃ���)
        //n: ijk����̒P�ʃx�N�g��(���ƂȂ�x�N�g��)
        //q = w cos(��/2) + n sin(��/2)
        q.w = Mathf.Cos(_angle);//����
        q.x = _axis.x * Mathf.Sin(_angle);
        q.y = _axis.y * Mathf.Sin(_angle);
        q.z = _axis.z * Mathf.Sin(_angle);
    }

    // Update is called once per frame
    void Update()
    {
        /*���W�ϊ�*/
        transform.position = q * transform.position;
    }
}
public struct MyQuaternion
{
    public float w,x, y, z;

    /*�R���X�g���N�^*/
    public MyQuaternion(float x, float y, float z, float w)
    {
        this.w = w;
        this.x = x;
        this.y = y;
        this.z = z;
    }

    /*���Z�q�I�[�o�[���[�h*/
    //MyQuaternion * MyQuaternion
    public static MyQuaternion operator *(MyQuaternion lQ, MyQuaternion rQ)
    {

        return new MyQuaternion();
    }
    //MyQuaternion * Vector3
    public static Vector3 operator *(MyQuaternion qRot, Vector3 right)
    {
        MyQuaternion qPos, qInv;
        Vector3 vPos;

        //3�������W���N�I�[�^�j�I���ɕϊ�
        qPos.w = 1.0f;
        qPos.x = right.x;
        qPos.y = right.y;
        qPos.z = right.z;

        //��]�N�H�[�^�j�I���̃C���o�[�X�̍쐬
        //�t�N�H�[�^�j�I�����o���̂͑�ςȂ̂ŁA
        //�R�������Ɠ����l�ɂȂ鋤���N�I�[�^�j�I���ō쐬(���������}�C�i�X���])
        qInv = new MyQuaternion(-qRot.w, -qRot.x, -qRot.y, qRot.z);

        //��]��̃N�I�[�^�j�I���̍쐬
        qPos = qRot * qPos * qInv;

        //�R�������W�ɖ߂�
        vPos.x = qPos.x;
        vPos.y = qPos.y;
        vPos.z = qPos.z;

        return vPos;
    }
}