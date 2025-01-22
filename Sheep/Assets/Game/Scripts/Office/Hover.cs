using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField]
    VertDirection vertDirection;

    [SerializeField]
    HorzDirection horzDirection;

    [SerializeField]
    OfficeMovement movement;
    public bool hoveredAlready = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData){
        
        // Debug.Log("hovered already ?");
        if(hoveredAlready){

            // Debug.Log("true, returning.");
            return;
        }
        // Debug.Log("false. Continuing.");
        // Debug.Log($"hovered already: {hoveredAlready}");
        hoveredAlready = true;
        // Debug.Log($"hovered already: {hoveredAlready}");

        // Debug.Log($"moving {vertDirection.ToString()}");
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

    public void OnPointerExit(PointerEventData eventData){
        
        hoveredAlready = false;
    }
}
