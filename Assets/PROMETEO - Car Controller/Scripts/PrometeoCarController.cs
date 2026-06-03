using UnityEngine;
using System.IO.Ports;

public class PrometeoCarController : MonoBehaviour
{
    public int maxSpeed = 10;
    public int maxReverseSpeed = 15;
    public float accelerationMultiplier = 0.5f;
    public int maxSteeringAngle = 45;
    public float steeringSpeed = 10f;

    public GameObject frontLeftMesh;
    public WheelCollider frontLeftCollider;
    public GameObject frontRightMesh;
    public WheelCollider frontRightCollider;
    public GameObject rearLeftMesh;
    public WheelCollider rearLeftCollider;
    public GameObject rearRightMesh;
    public WheelCollider rearRightCollider;

    private Rigidbody carRigidbody;
    private float steeringAxis;
    private float throttleAxis;
    private SerialPort serialPort;
    private bool switch0Activated = false;
    private bool switch1Activated = false;
    private bool switch2Activated = false;
    private bool switch3Activated = false;
    // Botones para acelerar y para frenar
    private bool button1Activated = false;
    private bool button1Deactivated = false;
    private bool button2Activated = false;
    private bool button2Deactivate = false;
    // con esta instancio corn collector  para poderla mandar a llamar en este script
    private CornCollector cornCollector; // Referencia al script CornCollector

    void Start()
    {
        carRigidbody = gameObject.GetComponent<Rigidbody>();
        carRigidbody.centerOfMass = new Vector3(0, -0.9f, 0);

        serialPort = new SerialPort("COM7", 115200);
        // con esta funcoin al empezar mando a llamar a corn collector 
        cornCollector = FindObjectOfType<CornCollector>();
        try
        {
            serialPort.Open();
            serialPort.ReadTimeout = 1;
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error al abrir el puerto serial: " + e.Message);
        }
    }

    void Update()
    {
        // Actualizr datos del serial, para hacer uso de los otros puertos
    ControlVehicleWithSerial();
    AnimateWheelMeshes();
    // Obtener la cantidad de maíz recolectado
    int cornCollected = cornCollector.GetCorn();
    // Convertir la cantidad de maíz recolectado a byte
    byte[] cornData = { (byte)cornCollected };
    // Enviar la cantidad de maíz recolectado a través del puerto serie
    SendDataToSerialPort(cornData);
    }

    //Funcion para el envio de datos al serial y las condiciones que necesitan
    void SendDataToSerialPort(byte[] data)
    {
     if (serialPort != null && serialPort.IsOpen)
     {
        try
        {
            serialPort.Write(data, 0, data.Length);
        }
        catch (System.Exception e)
        {
            Debug.LogWarning("Error al escribir datos en el puerto serial: " + e.Message);
        }
     }
    }
    
    //Ahi recibe los datos el vehiculo del serial 
    void ControlVehicleWithSerial()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            try
            {
                if (serialPort.BytesToRead > 0)
                {
                    byte[] data = new byte[1];
                    serialPort.Read(data, 0, 1);
                    ParseSerialData(data[0]);
                }
            }
            catch (System.Exception e)
            {
                Debug.LogWarning("Error al leer datos del puerto serial: " + e.Message);
            }
        }
    }

    //Comunicacion con los switches y botones
    void ParseSerialData(byte data)
    {
        Debug.Log("Dato recibido desde el puerto serial: " + data);

        if (data == 0x01) // Switch 0 arriba
        {
            switch0Activated = true;
            if (!switch1Activated)
            {
                GoForward();
            }
        }
        else if (data == 0x02) // Switch 0 abajo
        {
            switch0Activated = false;
            throttleAxis = 0;
            ApplyMotorTorque(throttleAxis);
        }
        else if (data == 0x03) // Switch 1 arriba
        {
            switch1Activated = true;
            if (!switch0Activated)
            {
                GoReverse();
            }
        }
        else if (data == 0x04) // Switch 1 abajo
        {
            switch1Activated = false;
            throttleAxis = 0;
            ApplyMotorTorque(throttleAxis);
        }
        else if (data == 0x05) // Switch 2 arriba
        {
            switch2Activated = true;
            TurnLeft();
        }
        else if (data == 0x06) // Switch 2 abajo
        {
            switch2Activated = false;
            steeringAxis = 0;
            ApplySteering();
        }
        else if (data == 0x07) // Switch 3 arriba
        {
            switch3Activated = true;
            TurnRight();
        }
        else if (data == 0x08) // Switch 3 abajo
        {
            //aqui va 0 pero esta funcionando bien 
            switch3Activated = false;
            steeringAxis = 1;
            ApplySteering();
        }

        // Esto es lo nuevo
        else if (data == 0x09) // boton 1 
        {
            button1Activated = true;
            boost();
        }
        else if (data == 0x0A)
        {
            button1Deactivated = false;
            DeactivateBoost();
        }
        
        else if (data == 0x0B) // boton 2
        {
            button2Activated = true; 
            breaktractor();
            
        }
        else if(data == 0x0C)
        {
            button2Deactivate = false;
            DeactivateBreakTractor();
        }
    }

    
    public void boost(){
        if(button1Activated){
            // Aca tiene que ir la condiciones para que se realice
            float boostMultiplier = 2.0f; // Esto seria el doble de velocidad
            ApplyMotorTorque(boostMultiplier); //Aca aplicamos el incremento del boostmultplier
            Debug.Log("Activacion de boost");
        } 
    }

    public void DeactivateBoost(){
        ThrottleOff();
    }

    public void breaktractor(){
        if(button2Activated){
            ApplyMotorTorque(0.0f);
            Debug.Log("Freno");
        }
    }

    public void DeactivateBreakTractor(){
        ThrottleOff();
    }

    public void TurnLeft()
    {
        if (switch2Activated && !switch3Activated)
        {
            steeringAxis = -1f;
            ApplySteering();
        }
    }

    public void TurnRight()
    {
        if (switch3Activated && !switch2Activated)
        {
            steeringAxis = 1f;
            ApplySteering();
        }
    }

    void ApplySteering()
    {
        var steeringAngle = steeringAxis * maxSteeringAngle;
        frontLeftCollider.steerAngle = steeringAngle;
        frontRightCollider.steerAngle = steeringAngle;
    }

    public void GoReverse()
    {
        if (switch1Activated && !switch0Activated)
        {
            throttleAxis = -1f;
            ApplyMotorTorque(throttleAxis);
        }
    }

    public void GoForward()
    {
        if (switch0Activated && !switch1Activated)
        {
            throttleAxis = 1f;
            ApplyMotorTorque(throttleAxis);
        }
    }

    void ApplyMotorTorque(float throttle)
    {
        float torque = accelerationMultiplier * 50f * throttle;
        frontLeftCollider.motorTorque = torque;
        frontRightCollider.motorTorque = torque;
        rearLeftCollider.motorTorque = torque;
        rearRightCollider.motorTorque = torque;
    }

    void ThrottleOff()
    {
        throttleAxis = 0;
        frontLeftCollider.motorTorque = 0;
        frontRightCollider.motorTorque = 0;
        rearLeftCollider.motorTorque = 0;
        rearRightCollider.motorTorque = 0;
    }

    void AnimateWheelMeshes()
    {
        UpdateWheelPose(frontLeftCollider, frontLeftMesh);
        UpdateWheelPose(frontRightCollider, frontRightMesh);
        UpdateWheelPose(rearLeftCollider, rearLeftMesh);
        UpdateWheelPose(rearRightCollider, rearRightMesh);
    }

    void UpdateWheelPose(WheelCollider collider, GameObject mesh)
    {
        Vector3 pos;
        Quaternion rot;
        collider.GetWorldPose(out pos, out rot);
        mesh.transform.position = pos;
        mesh.transform.rotation = rot;
    }

    void OnDestroy()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
        }
    }
    
}