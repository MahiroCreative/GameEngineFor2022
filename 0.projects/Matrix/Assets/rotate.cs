using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    GameObject rotateCube2;

    //物体の初期位置を入れる変数
    Vector3 firstPos;
    Vector3 lastPos;

    //行列変数の作成
    Matrix4x4 roMatrixZ,roMatrixX,tempMatrix;
    //角度用の変数
    float Angle=0;
    float delAngle;

    void Start()
    {
        //オブジェクトの取得
        rotateCube2 = GameObject.Find("rotateCube2");

        //物体の初期位置の代入
        firstPos = transform.position;
        lastPos = rotateCube2.transform.position;

        //角度の増加量の設定(Mathf.PI==π)
        delAngle = Mathf.PI * 0.001f;//1.8度

        //回転行列の初期化(単位行列の代入)
        roMatrixZ = Matrix4x4.identity;//z
        roMatrixX = Matrix4x4.identity;//x
        
    }

    // Update is called once per frame
    void Update()
    {
        //回転行列の更新(z軸回転)
        roMatrixZ.m00 = Mathf.Cos(Angle);
        roMatrixZ.m01 = -Mathf.Sin(Angle);
        roMatrixZ.m10 = Mathf.Sin(Angle);
        roMatrixZ.m11 = Mathf.Cos(Angle);

        ////回転行列の更新(x軸回転)
        //roMatrixX.m11 = Mathf.Cos(Angle);
        //roMatrixX.m12 = -Mathf.Sin(Angle);
        //roMatrixX.m21 = Mathf.Sin(Angle);
        //roMatrixX.m22 = Mathf.Cos(Angle);

        //行列の合成
        tempMatrix = roMatrixX * roMatrixZ;

        //回転の計算
        //青の回転
        transform.position =  tempMatrix * firstPos;
        //緑の回転
        rotateCube2.transform.position = tempMatrix * lastPos;

        //角度の増加
        Angle += delAngle;

        //角度の初期化
        if(Angle > 2 * Mathf.PI)
        {
            Angle = 0;
        }
    }
}
