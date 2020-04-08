using UnityEngine;

public sealed class PcInput : IInputMethod
{
    public float HorizontalAxis {get; private set;}

    private static PcInput m_instance;
    public static PcInput Instance
    {
        get
        {
            if (PcInput.m_instance == null)
                PcInput.m_instance = new PcInput();
            return PcInput.m_instance;
        }
        private set{}
    }

    private PcInput(){}

    public void CollectInput()
    {
        HorizontalAxis =  Input.GetAxis("Horizontal");
    }
}