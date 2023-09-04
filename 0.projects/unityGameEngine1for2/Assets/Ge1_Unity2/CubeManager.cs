using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    float del;
    GameObject cube1, cube2;
    Vector3 speed1, speed2, temp;
    Transform c1T, c2T;
    bool flag;


    // Start is called before the first frame update
    void Start()
    {
        //�I�u�W�F�N�g�̎擾
        cube1 = GameObject.Find("Cube1");
        cube2 = GameObject.Find("Cube2");
        //���]�p
        temp = new Vector3();

        //�݂��̕����ւ̃x�N�g�������̍쐬
        speed1 = new Vector3();
        speed1 = cube2.transform.position - cube1.transform.position;//sphere1����sphere2�ւ̃x�N�g��
        speed1 = speed1.normalized;//�P�ʃx�N�g����
        speed1 = speed1 / 50;//��������̂�1/50�ɁB
        speed2 = new Vector3();
        speed2 = cube1.transform.position - cube2.transform.position;//sphere2����sphere1�ւ̃x�N�g��
        speed2 = speed2.normalized;//�P�ʃx�N�g����
        speed2 = speed2 / 50;//��������̂�1/50�ɁB
        //��̃I�u�W�F�N�g�̃g�����X�t�H�[���̊m��
        c1T = cube1.transform;
        c2T = cube2.transform;

        //�����蔻��
        flag = true;
    }

    // Update is called once per frame
    void Update()
    {
        //�����蔻��
        flag = BoxCollision.CheckCubeCol(c1T,c2T);

        //���]����
        if (flag == true)
        {
            temp = speed1;
            speed1 = speed2;
            speed2 = temp;
            flag = false;
            Debug.Log("hit");
        }
    }
    private void FixedUpdate()
    {
        //�ړ�����
        cube1.transform.position += speed1;
        cube2.transform.position += speed2;
    }
}