using UnityEngine;
using UnityEngine.EventSystems;

public class Hover : MonoBehaviour, IPointerEnterHandler
{

    [SerializeField]
    VertDirection vertDirection;

    [SerializeField]
    HorzDirection horzDirection;

    [SerializeField]
    OfficeMovement movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IPointerEnterHandler.OnPointerEnter(UnityEngine.EventSystems.PointerEventData eventData){
        
        Debug.Log($"moving {vertDirection.ToString()}");
        if(vertDirection == VertDirection.up){

            movement.RotUp(TargetDirection.up);
        }
        if(vertDirection == VertDirection.down){

            movement.RotDown(TargetDirection.down);
        }
        if(horzDirection == HorzDirection.left){

            movement.RotLeft(TargetDirection.left);
        }
        if(horzDirection == HorzDirection.right){

            movement.RotRight(TargetDirection.right);
        }
    }
}
