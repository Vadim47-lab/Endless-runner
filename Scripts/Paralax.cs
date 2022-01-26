using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class Paralax : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _imagePositionY;
    [SerializeField] private float _positionX;

    private RawImage _image;
    private float _imagePositionX;

    private void Start()
    {
        _image = GetComponent<RawImage>();
    }
    private void Update()
    {
        _imagePositionX += _speed * Time.deltaTime;

        if (_imagePositionX > _positionX)
        {
            _imagePositionX = _imagePositionY;
        }

        _image.uvRect = new Rect(_imagePositionX, _imagePositionY, _image.uvRect.width, _image.uvRect.height);
    }
}