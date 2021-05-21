using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class Draw : MonoBehaviour
{
    private RectTransform drawingSpaceRectTransform;
    public RawImage drawingSpaceRawImage;

    private Texture2D manipulatedTexture;
    private Vector2 previousPoint = Vector2.zero;
    private Color[] colors;

    private JustPointer justPointer;

    public int inkSize = 10;

    public TextMeshProUGUI cornersText;
    public TextMeshProUGUI positionText;
    public TextMeshProUGUI insideRectangleText;
    public TextMeshProUGUI localPointInrectangle;
    private Vector3[] debugCorners = new Vector3[4];

    private void Awake()
    {
        justPointer = new JustPointer();
        justPointer.point.pointer.performed += OnAction;
        justPointer.point.pointer.canceled += OnAction;

        drawingSpaceRectTransform = drawingSpaceRawImage.gameObject.GetComponent<RectTransform>();

        //Gets the coordinates of the drawing space to create a texture of the same dimensions.
        drawingSpaceRectTransform.GetWorldCorners(debugCorners);
        float height = debugCorners[1].y - debugCorners[0].y;
        float width = debugCorners[3].x - debugCorners[0].x;

        manipulatedTexture = new Texture2D((int)width, (int)height);

        colors = new Color[inkSize * inkSize];
        for (int i = 0; i < colors.Length; i++)
        {
            colors[i] = Color.black;
        }

        ClearSignature();
    }

    private void Update()
    {
        manipulatedTexture.Apply();
        if (drawingSpaceRawImage.texture != manipulatedTexture) drawingSpaceRawImage.texture = manipulatedTexture;

        cornersText.text = string.Format("<pos=5%>{0}<pos=50%>{1}\n<pos=5%>{2}<pos=50%>{3}", debugCorners[1], debugCorners[2], debugCorners[0], debugCorners[3]);
    }

    private void OnEnable()
    {
        justPointer?.Enable();
    }

    private void OnDisable()
    {
        justPointer?.Disable();
    }

    protected void OnAction(InputAction.CallbackContext context)
    {
        Debug.Log(context.control);
        var drag = context.ReadValue<PointerInput>();

        if (drag.Contact)
        { 
            positionText.text = "<pos=5%>Touch active: " + drag.Position.ToString();
            OnTouch(drag, context.time);
        }
        else
        {
            positionText.text = "<pos=5%>Touch released: " + drag.Position.ToString();
            OnReleased(drag, context.time);
        }
    }

    private void OnTouch(PointerInput pointer, double time)
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(drawingSpaceRectTransform, pointer.Position))
        {
            //Converts touch position to local coordinates
            Vector2 vect;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(drawingSpaceRectTransform, pointer.Position, null, out vect);

            vect.x += drawingSpaceRectTransform.rect.width / 2;
            vect.y += drawingSpaceRectTransform.rect.height / 2;

            float xScale = manipulatedTexture.width / drawingSpaceRectTransform.rect.width;
            float yScale = manipulatedTexture.height / drawingSpaceRectTransform.rect.height;

            vect.x = vect.x * xScale;
            vect.y = vect.y * yScale;

            localPointInrectangle.text = "<pos=5%>Local coordinates: " + vect.ToString();

            if (previousPoint == Vector2.zero)
            {
                previousPoint = vect;
            }
            else
            {
                ConnectPixels(previousPoint, vect);
                previousPoint = vect;
            }

            insideRectangleText.text = "<pos=5%>Inside rectangle";
        }
        else insideRectangleText.text = "Outside of rectangle";
    }

    private void OnReleased(PointerInput input, double time)
    {
        previousPoint = Vector2.zero;
    }

    //Extrapolates the drawing between 2 given points. Used to make sure there are no white spaces if the cursor has moved too quickly
    private void ConnectPixels(Vector2 first, Vector2 second)
    {
        try
        {
            Vector2 temp = first;

            float frac = 1 / Mathf.Sqrt(Mathf.Pow(second.x - first.x, 2) + Mathf.Pow(second.y - first.y, 2));
            float counter = 0;

            while ((int)temp.x != (int)second.x || (int)temp.y != (int)second.y)
            {
                temp = Vector2.Lerp(first, second, counter);
                counter += frac;
                if ((int)temp.x > inkSize && (int)temp.x < manipulatedTexture.width - inkSize && (int)temp.y > inkSize && (int)temp.y < manipulatedTexture.height - inkSize)
                {
                    manipulatedTexture.SetPixels((int)temp.x, (int)temp.y, inkSize, inkSize, colors);
                }
            }
        }
        catch (Exception e) { Debug.Log(e, this); }
    }

    public void ClearSignature()
    {
        Color32[] resetColorArray = manipulatedTexture.GetPixels32();

        for (int i = 0; i < resetColorArray.Length; i++)
        {
            resetColorArray[i] = new Color32(255, 255, 255, 255);
        }

        manipulatedTexture.SetPixels32(resetColorArray);
        manipulatedTexture.Apply();
    }
}
