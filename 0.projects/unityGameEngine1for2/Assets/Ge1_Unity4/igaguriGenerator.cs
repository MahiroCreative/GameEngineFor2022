using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class igaguriGenerator : MonoBehaviour
{
    public GameObject igaguriprefab;
    GameObject igaguri;
    Vector3 dir;
    Ray ray;

    private void Start()
    {
        dir = new Vector3(0,200,2000);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //��������̐���
            igaguri = Instantiate(igaguriprefab);

            //�ˏo�ʒu�̎擾
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            dir = ray.direction;//�����̕���
            dir = dir.normalized * 2000;//���K�����āA���x���|���Ă�B

            igaguri.GetComponent<igaguriController>().Shoot(dir);
        }
    }
}
