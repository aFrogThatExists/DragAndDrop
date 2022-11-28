using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMovement : MonoBehaviour
{
    private bool _tiedToMouse = false;
    [SerializeField] private float _moveDistance;
    [SerializeField] private float _liftedY;
    [SerializeField] private float _placedY;
    [SerializeField] private Vector3 _playBorderStart;
    [SerializeField] private Vector3 _playBorderEnd;
    private GameHandler _gameHandler;
    private Vector3 _startPosition;

    void Start()
    {
        _gameHandler = GameObject.Find("GameHandler").GetComponent<GameHandler>();
        gameObject.transform.GetChild(0).localScale = new Vector3(_moveDistance,0.5f,_moveDistance);
        _startPosition = transform.position;
    }
    
    void OnMouseOver()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }
    void OnMouseExit()
    {
        if(!_tiedToMouse)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    void OnMouseDown()
    {
        
        _tiedToMouse = _gameHandler.tieMouse(gameObject);
        transform.position = new Vector3 (transform.position.x, _liftedY, transform.position.z);
        
    }
    void OnMouseUp()
    {
       
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        _gameHandler.untieMouse(gameObject);
        _tiedToMouse = false;
        transform.position = new Vector3 (transform.position.x, _placedY, transform.position.z);
        _startPosition = transform.position;
    } 
    void OnMouseDrag()
    {
        if(_tiedToMouse)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0,0,Camera.main.transform.position.y));
            mousePosition.x = Mathf.Clamp(mousePosition.x,_playBorderStart.x,_playBorderEnd.x);
            mousePosition.y = Mathf.Clamp(mousePosition.y,_playBorderStart.y,_playBorderEnd.y);
            mousePosition.z = Mathf.Clamp(mousePosition.z,_playBorderStart.z,_playBorderEnd.z);

            mousePosition.x = Mathf.Clamp(mousePosition.x,_startPosition.x-_moveDistance,_startPosition.x+_moveDistance);
            mousePosition.y = Mathf.Clamp(mousePosition.y,_startPosition.y-_moveDistance,_startPosition.y+_moveDistance);
            mousePosition.z = Mathf.Clamp(mousePosition.z,_startPosition.z-_moveDistance,_startPosition.z+_moveDistance);
            
            transform.position = new Vector3(mousePosition.x, _liftedY, mousePosition.z);
            gameObject.transform.GetChild(0).position = _startPosition;
            
            
        }
        
    }
    
}
