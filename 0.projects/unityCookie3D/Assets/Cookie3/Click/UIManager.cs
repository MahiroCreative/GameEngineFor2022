using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //�ϐ��쐬
    Text _coutUI;
    GameObject _warImage;
    Cookie3Generator _gene;
    bool _warFlag;
    int timer;

    // Start is called before the first frame update
    void Start()
    {
        //����������
        _coutUI = GameObject.Find("Canvas/Count").GetComponent<Text>();
        _warImage = GameObject.Find("Canvas/Warning");
        _gene = GameObject.Find("CookieGenerator").GetComponent<Cookie3Generator>();
        _warFlag = false;
        _warImage.SetActive(false);
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //UI�J�E���g�̍X�V
        _coutUI.text = Cookie3Generator.ClickCount.ToString();

        //64�N���b�N��Warning�����J�n
        if(Cookie3Generator.ClickCount == 64 && _warFlag == false)
        {
            _warImage.SetActive(true);
            _warFlag = true;
        }

        //32�N���b�N��Warning�����J�n
        if (Cookie3Generator.ClickCount == 32 && _warFlag==false)
        {
            _warImage.SetActive(true);
            _warFlag = true;
        }
    }

    private void FixedUpdate()
    {
        //Warining����
        if(_warFlag && timer <100)
        {
            if(timer < 30)
            {
                _warImage.SetActive(true);
            }
            else if(timer < 45)
            {
                _warImage.SetActive(false);
            }
            else if (timer < 75)
            {
                _warImage.SetActive(true);
            }
            else if (timer < 85)
            {
                _warImage.SetActive(false);
            }
            else if (timer < 100)
            {
                _warImage.SetActive(true);
            }

            //timer�X�V
            timer++;
        }
        else if(timer >=100)//����I�������V�[���J��
        {
            _warImage.SetActive(false);
            _warFlag = true;

            if (Cookie3Generator.ClickCount < 64)
            {
                timer = 0;
                Cookie3Generator.ClickCount++;
                SceneManager.LoadScene("Cookie3/Cookie3Run");
            }
            else
            {
                timer = 0;
                SceneManager.LoadScene("Cookie3/Cookie3Battle");
            }
            
        }
    }
}
