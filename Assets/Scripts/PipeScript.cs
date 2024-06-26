using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;

    void Start()
    {

    }

    void Update()
    {
        this.transform.Translate(speed * Time.deltaTime * Vector3.left);
    }
}
/* [SerializeField] - �������, �� ������� ��, �� �������� ��� ����
* ���� ��������� ����� "��������".
* Translate - ����������
* Time.deltaTime - ���, �� ������ �� ������������ ������ (������� ������)
* �������� �� ��� (�������� �� Time.deltaTime) ������� FPS - �����������
* 
*/
