using UnityEngine;

public sealed class AccelerometerInput : IInputMethod
{

    public float HorizontalAxis {get; private set;}

    private static AccelerometerInput m_instance;
    public static AccelerometerInput Instance
    {
        get
        {
            if (AccelerometerInput.m_instance == null)
                AccelerometerInput.m_instance = new AccelerometerInput();
            return AccelerometerInput.m_instance;
        }
        private set{}
    }

    private AccelerometerInput(){}

    public void CollectInput()
    {
        HorizontalAxis =  Input.acceleration.x;
    }
}