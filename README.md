# Tractor Simulator — FPGA + Unity

## Project Overview

Agricultural tractor simulator in Unity controlled by FPGA (DE10-Lite). Implements real-time control logic in programmable logic for button, switch, and accelerometer inputs. Displays live metrics (harvest counter, speed) via serial connection.

### Key Features
- **FPGA Control**: Real-time button & switch processing via PLD (VHDL)
- **Accelerometer Input**: Acceleration-based control
- **Serial Communication**: Live data streaming to Unity
- **3D Visualization**: Agricultural tractor simulation
- **Real-time Metrics**: Harvest counter, speed, status display

---

## Performance Metrics
| Metric | Value |
|--------|-------|
| Communication Speed | 115200 baud |
| Update Rate | 30 Hz |
| FPGA Platform | DE10-Lite |
| Game Engine | Unity 2022+ |

---

## Tech Stack

### Hardware & FPGA
- **DE10-Lite** (Cyclone V FPGA)
- **VHDL** (Programmable Logic)
- **Quartus** (FPGA Design Suite)
- **Accelerometer** (Input Sensor)

### Software
- **Unity** (Game Engine)
- **C#** (Game Logic)
- **Serial Communication** (FPGA ↔ PC)

### Development
- **Quartus Prime**
- **Unity Editor**

---

## Prerequisites

### Hardware
- DE10-Lite FPGA Board
- Accelerometer Sensor
- USB-Serial Adapter
- Windows PC

### Software
- Quartus Prime 20.1+
- Unity 2022.3+ LTS
- .NET Framework 4.7.2+

---

## Installation

### FPGA Setup (Quartus)
```bash
# Open Quartus project
quartus fpga_project.qpf

# Compile and generate bitstream
# Program DE10-Lite using USB Blaster

# Verify serial communication
# Expected output: "FPGA READY"
```

### Unity Setup
```bash
# Clone repository
git clone https://github.com/RiosRosendo/tractor-simulator-fpga-unity.git

# Open in Unity Editor
# File → Open Project → tractor-simulator-fpga-unity

# Set COM port in settings (match FPGA serial port)
# Play scene to test
```

---

## Architecture

```
DE10-Lite (FPGA)
    ↓
Button/Switch/Accelerometer Input
    ↓
VHDL Logic Processing
    ↓
Serial Output (USB)
    ↓
Unity Game Engine
    ↓
3D Tractor Visualization
    ↓
Real-time Display (Speed, Harvest Counter)
```

---

## Usage

### Start Simulation
1. Program FPGA bitstream to DE10-Lite
2. Connect USB-Serial adapter
3. Open Unity project
4. Press Play in Editor
5. Interact via:
   - Buttons: Terrain controls
   - Switches: Mode selection
   - Accelerometer: Speed control

### Monitor Data
- Serial Monitor shows live metrics
- Unity displays 3D feedback
- Harvest counter increments on successful operations

---

## File Structure

```
tractor-simulator-fpga-unity/
├── Assets/
│   ├── Scenes/
│   │   └── MainSimulator.unity
│   ├── Scripts/
│   │   ├── FPGAController.cs
│   │   ├── TractorController.cs
│   │   └── UIManager.cs
│   ├── Models/
│   │   └── tractor_model.fbx
│   └── UI/
├── FPGA/
│   ├── vhdl/
│   │   ├── control_logic.vhd
│   │   └── serial_interface.vhd
│   └── Quartus/
│       └── fpga_project.qpf
├── Builds/
├── docs/
│   └── Tractor_Simulator_Report.pdf
└── README.md
```

---

## Contributors & Team

| Name | Matrícula | Role |
|------|-----------|------|
| **Roberto Raymundo Gómez Vargas** | A01285451 | FPGA Design & Control Logic |
| **Jesus Alberto García Gonzalez** | A01369587 | Unity Development & Integration |
| **Rosendo De Los Rios Moreno** | A01198515 | Tractor Simulator Development & FPGA Testing |
| **Hugo Daniel Castillo Ovando** | A00836025 | Hardware Setup & Validation |

**Team**: Tec de Monterrey - School of Engineering

---

## Demo Video
📹 [Watch the tractor simulator in action](https://www.youtube.com/watch?v=Fu5qLoS_6Co)

---

## Technical Documentation
See `/docs/Tractor_Simulator_Report.pdf` for detailed technical report, design decisions, and implementation details.

---

## References
- [Quartus Prime Documentation](https://www.intel.com/content/www/us/en/software/programmable/quartus/overview.html)
- [DE10-Lite Board Manual](https://www.terasic.com.tw/cgi-bin/page/archive.pl?Language=English&CategoryNo=205&No=1021)
- [Unity Manual](https://docs.unity3d.com/)
- [Serial Communication in Unity](https://docs.unity3d.com/Manual/ControllingGameObjectswithaScript.html)

---

## License
MIT License - See LICENSE file for details

---

## Contact
📧 Email: delosriosrosendo@gmail.com  
🔗 GitHub: [@RiosRosendo](https://github.com/RiosRosendo)  
🔗 LinkedIn: [delosriosrosendo](https://linkedin.com/in/delosriosrosendo)
