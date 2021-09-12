using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public Camera mainCamera;
    private LineRenderer _lineRenderer;
    private DistanceJoint2D _distanceJoint;
    private PlayerMove _playerMove;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = .3f;
        _distanceJoint = GetComponent<DistanceJoint2D>();
        _lineRenderer = GetComponent<LineRenderer>();
        _playerMove = GetComponent<PlayerMove>();
        _distanceJoint.enabled = false;
        _lineRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        print(timer);
        if(timer > 0)
        {
            timer -= 1 * Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(0) && timer <= 0)
        {

            Vector2 mousePos = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            if (hit.collider.gameObject.tag != null && Vector2.Distance(mousePos, transform.position) < 10)
            {
                timer = .3f;
                if (hit.collider.gameObject.tag == "ground")
                {
                    _distanceJoint.distance = Vector2.Distance(transform.position, mousePos) / 2;

                    _lineRenderer.SetPosition(0, mousePos);
                    _lineRenderer.SetPosition(1, transform.position);
                    _distanceJoint.connectedAnchor = mousePos;
                    _distanceJoint.enabled = true;
                    _lineRenderer.enabled = true;
                    _playerMove.enabled = false;

                }
                if (hit.collider.gameObject.tag == "enemy" || hit.collider.gameObject.tag == "fly")
                {
                    _lineRenderer.SetPosition(0, mousePos);
                    _lineRenderer.SetPosition(1, transform.position);
                    _lineRenderer.enabled = true;
                }



                //if (Input.mouseScrollDelta.y > 0)
                //{
                //    print("up");
                //    _distanceJoint.distance += 1;
                //}

            }

        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            print("up");
            _distanceJoint.enabled = false;
            _lineRenderer.enabled = false;
            _playerMove.enabled = true;

        }
        if (_distanceJoint.enabled)
        {
            _lineRenderer.SetPosition(1, transform.position);
        }
    }


}
