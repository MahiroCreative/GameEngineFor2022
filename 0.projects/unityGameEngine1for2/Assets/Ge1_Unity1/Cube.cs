using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    //Quaternion
    Vector3 arrow = new Vector3(1.0f, 1.0f, 1.0f);//���x�N�g��
    Quaternion q;

    void Start()
    {
        //��]�ʂ��N�I�[�^�j�I���ō��B
        q = Quaternion.AngleAxis(1.0f,arrow);
    }

    // Update is called once per frame
    void Update()
    {
        //���̉�]�l�ƍ������ď㏑��
        this.transform.rotation = q * this.transform.rotation;
    }
}