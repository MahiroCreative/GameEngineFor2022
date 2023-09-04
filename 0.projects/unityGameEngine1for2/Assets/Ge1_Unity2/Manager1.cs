using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager1 : MonoBehaviour
{
    //�ϐ�
    GameObject _obj;
    GameObject[] _objs = new GameObject[4];
    Vector3[] _pos = new Vector3[4];
    int time = 0;
    int i = 0;
    bool delFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        // Cube�v���n�u��GameObject�^�Ŏ擾
        _obj = (GameObject)Resources.Load("Capsule");
        //�|�W�V�����̐ݒ�
        _pos[0] = new Vector3(0, 2.0f, 0);
        _pos[1] = new Vector3(-2.0f, 0, 0);
        _pos[2] = new Vector3(0, -2.0f, 0);
        _pos[3] = new Vector3(2.0f, 0, 0);
    }

    void FixedUpdate()
    {
        // Cube�v���n�u�����ɁA�C���X�^���X�𐶐��A
        if (time > 50 && delFlag == false)
        {
            _objs[i] = Instantiate(_obj, _pos[i], Quaternion.identity);
            i++;
            time = 0;

        }
        else if (time > 50 && delFlag == true)
        {
            Destroy(_objs[i]);
            i++;
            time = 0;
        }

        if (i > 3)
        {
            i = 0;
            if (delFlag == false)
            {
                delFlag = true;
            }
            else
            {
                delFlag = false;
            }
        }
        time++;
    }
}
