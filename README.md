# InventorAPI - (Assignment 1 - InventorAddIn)

## Description:
InventorAddIn is a project that utilizes the Inventor API to create an add-in for Autodesk Inventor. This add-in provides functionality to interact with Inventor's 3D modeling environment programmatically.

## Features
1. **Connect to Inventor:** Allows the user to connect to an active instance of Autodesk Inventor or create a new instance if none is found.
2. **Create 3D Shapes:** Demonstrates how to create basic 3D shapes, such as rectangles, using the sketching and extrusion features of Inventor.
3. **Customize Sketches:** Shows how to customize sketches by changing the appearance (color) of sketch lines.
4. **Simple UI:** Provides a simple Windows Forms UI for interacting with the add-in.


## Classes Used
**Inventor.Application:** Represents an instance of Autodesk Inventor.
**PartDocument:** Represents a part document in Inventor, which contains 3D geometry.
**PartComponentDefinition:** Represents the component definition of a part document, which defines the shape and properties of a part.
**PlanarSketch:** Represents a 2D sketch plane in Inventor, used for sketching 2D profiles that can be extruded into 3D shapes.
**SketchLine:** Represents a 2D sketch line in a sketch.
**TransientGeometry:** Provides methods for creating transient geometric objects, such as points and vectors.

## How to Use
1. Clone the repository to your local machine.
2. Open the project in Visual Studio.
3. Build the project to create the add-in DLL.
4. Open Autodesk Inventor.
5. Load the add-in DLL using the Add-In Manager in Inventor.
6. Use the provided UI to interact with the add-in and create 3D shapes.

## User Interface

![image](https://github.com/rashmi-kulkarni-ct402/InventorAPI/assets/158051740/965ef648-32b4-423f-b32b-3992c4dfeec6)

## Output

![image](https://github.com/rashmi-kulkarni-ct402/InventorAPI/assets/158051740/c5575b6e-50ed-4282-90c7-223d573a6e20)
