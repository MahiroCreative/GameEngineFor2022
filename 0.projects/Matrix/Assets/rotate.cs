using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    GameObject rotateCube2;

    //���̂̏����ʒu������ϐ�
    Vector3 firstPos;
    Vector3 lastPos;

    //�s��ϐ��̍쐬
    Matrix4x4 roMatrixZ,roMatrixX,tempMatrix;
    //�p�x�p�̕ϐ�
    float Angle=0;
    float delAngle;

    void Start()
    {
        //�I�u�W�F�N�g�̎擾
        rotateCube2 = GameObject.Find("rotateCube2");

        //���̂̏����ʒu�̑��
        firstPos = transform.position;
        lastPos = rotateCube2.transform.position;

        //�p�x�̑����ʂ̐ݒ�(Mathf.PI==��)
        delAngle = Mathf.PI * 0.001f;//1.8�x

        //��]�s��̏�����(�P�ʍs��̑��)
        roMatrixZ = Matrix4x4.identity;//z
        roMatrixX = Matrix4x4.identity;//x
        
    }

    // Update is called once per frame
    void Update()
    {
        //��]�s��̍X�V(z����])
        roMatrixZ.m00 = Mathf.Cos(Angle);
        roMatrixZ.m01 = -Mathf.Sin(Angle);
        roMatrixZ.m10 = Mathf.Sin(Angle);
        roMatrixZ.m11 = Mathf.Cos(Angle);

        ////��]�s��̍X�V(x����])
        //roMatrixX.m11 = Mathf.Cos(Angle);
        //roMatrixX.m12 = -Mathf.Sin(Angle);
        //roMatrixX.m21 = Mathf.Sin(Angle);
        //roMatrixX.m22 = Mathf.Cos(Angle);

        //�s��̍���
        tempMatrix = roMatrixX * roMatrixZ;

        //��]�̌v�Z
        //�̉�]
        transform.position =  tempMatrix * firstPos;
        //�΂̉�]
        rotateCube2.transform.position = tempMatrix * lastPos;

        //�p�x�̑���
        Angle += delAngle;

        //�p�x�̏�����
        if(Angle > 2 * Mathf.PI)
        {
            Angle = 0;
        }
    }
}
