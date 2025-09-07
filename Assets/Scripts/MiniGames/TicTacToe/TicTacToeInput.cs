using GFrame;
using TicTacToe.Events;
using UnityEngine;

namespace TicTacToe.Game
{
    public class TicTacToeInput : MonoBehaviour
    {
        [SerializeField] private Camera raycastCamera;

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                RaycastCells(Input.mousePosition);
            }
        }

        private void RaycastCells(Vector3 fingerScreenPosition)
        {
            Vector3 fingerWorldPosition = raycastCamera.ScreenToWorldPoint(fingerScreenPosition);
            Vector3 cameraForward = raycastCamera.transform.TransformDirection(Vector3.forward);
            RaycastHit2D hit = Physics2D.Raycast(fingerWorldPosition, cameraForward, 20f);

            if (hit)
            {
                Cell hitCell = hit.transform.GetComponent<Cell>();
                GFrameManagers.EventManager.Send(CellTappedEvent.Create(hitCell));
                Debug.Log($"CellTappedEvent: {hitCell}");
            }
        }
    }
}

