using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CookieGenerator : MonoBehaviour
{
    //�ϐ�
    GameObject _obj;
    Vector3[] _pos = new Vector3[16];
    int i=0;
    int ClickCount = 0;
    Quaternion q;

    // Start is called before the first frame update
    void Start()
    {
        //���\�[�X����̎擾
        _obj = (GameObject)Resources.Load("SubCookie2");
        //��]
        q = Quaternion.Euler(0,180,0);
        //�|�W�V�����̐ݒ�
        _pos[0] = new Vector3(-4,24,12);
        _pos[1] = new Vector3(-8, 24, 12);
        _pos[2] = new Vector3(-12, 24, 12);
        _pos[3] = new Vector3(-16, 24, 12);
        _pos[4] = new Vector3(4, 24, 12);
        _pos[5] = new Vector3(8, 24, 12);
        _pos[6] = new Vector3(12, 24, 12);
        _pos[7] = new Vector3(16, 24, 12);
        _pos[8] = new Vector3(-4, 24, 20);
        _pos[9] = new Vector3(-8, 24, 20);
        _pos[10] = new Vector3(-12, 24, 20);
        _pos[11] = new Vector3(-16, 24, 20);
        _pos[12] = new Vector3(4, 24, 20);
        _pos[13] = new Vector3(8, 24, 20);
        _pos[14] = new Vector3(12, 24, 20);
        _pos[15] = new Vector3(16, 24, 20);
    }

    // Update is called once per frame
    void Update()
    {
        //�N���b�N��
        if (Input.GetMouseButtonDown(0))
        {
            i = Random.Range(0,16);
            Instantiate(_obj, _pos[i],q);
            ClickCount++;
        }

        //�w��N���b�N��ɃV�[������
        if(ClickCount >32)
        {
            SceneManager.LoadScene("Cookie2/RunCookie2");
        }
    }
}
