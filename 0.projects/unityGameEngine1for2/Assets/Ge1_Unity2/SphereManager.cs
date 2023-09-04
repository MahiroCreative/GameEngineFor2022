using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SphereManager : MonoBehaviour
{
    float size,del;
    GameObject sphere1, sphere2;
    Vector3 speed1, speed2, temp, delVec;
    bool flag;

    // Start is called before the first frame update
    void Start()
    {
        //�I�u�W�F�N�g�̎擾
        sphere1 = GameObject.Find("Sphere1");
        sphere2 = GameObject.Find("Sphere2");
        //�x�N�g���Ԋm�ۗp
        delVec = new Vector3();
        //���]�p
        temp = new Vector3();

        //�݂��̕����ւ̃x�N�g�������̍쐬
        speed1 = new Vector3();
        speed1 = sphere2.transform.position - sphere1.transform.position;//sphere1����sphere2�ւ̃x�N�g��
        speed1 = speed1.normalized;//�P�ʃx�N�g����
        speed1 = speed1 / 50;//��������̂�1/50�ɁB
        speed2 = new Vector3();
        speed2 = sphere1.transform.position - sphere2.transform.position;//sphere2����sphere1�ւ̃x�N�g��
        speed2 = speed2.normalized;//�P�ʃx�N�g����
        speed2 = speed2 / 50;//��������̂�1/50�ɁB
        //�T�C�Y�擾
        size = sphere1.transform.localScale.x;
        //�t���O������
        flag= true;
    }

    // Update is called once per frame
    void Update()
    {
        //���΋����̍쐬
        delVec = sphere1.transform.position - sphere2.transform.position;
        del = delVec.magnitude;

        //�����蔻��
        if (del < 0.95f && flag)
        {
            temp = speed1;
            speed1 = speed2;
            speed2 = temp;
            flag= false;
            Debug.Log("SphereHit!");
        }
    }

    private void FixedUpdate()
    {
        //�ړ�����
        sphere1.transform.position += speed1;
        sphere2.transform.position += speed2;
    }
}
