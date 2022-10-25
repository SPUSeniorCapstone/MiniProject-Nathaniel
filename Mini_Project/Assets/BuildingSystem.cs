using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// credit to this: https://weeklyhow.com/rts-building-system-with-raycast/

public class BuildingSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject _placeholderBuilding;
    private GameObject _placeholder;


    [SerializeField]
    private GameObject _building;

    private Vector3 _mousePosition;
    private float _previousX;
    private float _previousZ;

    // Start is called before the first frame update
    void Start()
    {
        _placeholder = Instantiate(_placeholderBuilding);
    }

    // Update is called once per frame
    void Update()
    {

        _mousePosition = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(_mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            float positionX = hit.point.x;
            float positionZ = hit.point.z;

            if (_previousX != positionX || _previousZ != positionZ)
            {
                _previousX = positionX;
                _previousZ = positionZ;

                _placeholder.transform.position = new Vector3(positionX, 0f, positionZ);


                //Debug.Log(_previousX + " / " + _previousZ);
            }

            if (Input.GetMouseButtonUp(0))
            {
                Instantiate(_building, _placeholder.transform.position, Quaternion.identity);
            }

        }
    }
}
