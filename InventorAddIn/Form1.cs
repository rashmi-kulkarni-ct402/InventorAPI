using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Inventor;

namespace InventorAddIn
{
    public partial class Form1 : Form
    {
        Inventor.Application inventorApplication;

        public Form1()
        {
            InitializeComponent();
        }

        // connect button click event handler
        private void connect_Click(object sender, EventArgs e)
        {
            try
            {
                // try to get an active instance of Invento
                inventorApplication = (Inventor.Application)System.Runtime.InteropServices.
                    Marshal.GetActiveObject("Inventor.Application");
            }
            catch (Exception)
            {
                // if no active instance found, create a new instance
                Type invType = System.Type.GetTypeFromProgID("Inventor.Application");
                inventorApplication = System.Activator.CreateInstance(invType) as Inventor.Application;
                inventorApplication.Visible = true;
            }
        }

        // extrude button click event handler
        private void extrude_Click(object sender, EventArgs e)
        {
            // create a new part document
            PartDocument oPartDocument = (PartDocument)inventorApplication.Documents.
                Add(DocumentTypeEnum.kPartDocumentObject, inventorApplication.
                FileManager.GetTemplateFile(DocumentTypeEnum.kPartDocumentObject));

            // get the component definition of the part document
            PartComponentDefinition oPartComponentDefinition = oPartDocument.ComponentDefinition;

            // add a sketch to the part
            PlanarSketch oSketch = oPartComponentDefinition.Sketches.Add(oPartComponentDefinition.WorkPlanes[3]);

            // get the transient geometry object from the Inventor application
            TransientGeometry oTransientGeometry = inventorApplication.TransientGeometry;

            // create a rectangle sketch
            SketchEntitiesEnumerator oRectangle = oSketch.SketchLines.
                AddAsTwoPointRectangle(oTransientGeometry.CreatePoint2d(0,0), oTransientGeometry.CreatePoint2d(2,5));

            #region // color
            // get the first sketch line in the rectangle
            SketchLine oSketchLine = oRectangle[1] as SketchLine;
                        
            // change the color of the sketch line
            if (oSketchLine != null)
            {
                oSketchLine.OverrideColor = inventorApplication.TransientObjects.CreateColor(255, 0, 0);

            }
            #endregion

            // create a profile from the sketch
            Profile oProfile = oSketch.Profiles.AddForSolid();

            // create an extrude definition
            ExtrudeDefinition oExtrudeDefinition = oPartComponentDefinition.Features.
                ExtrudeFeatures.CreateExtrudeDefinition(oProfile, PartFeatureOperationEnum.kJoinOperation);
            oExtrudeDefinition.SetDistanceExtent(5, PartFeatureExtentDirectionEnum.kNegativeExtentDirection);

            // perform the extrusion
            ExtrudeFeature oExtrudeFeature = oPartComponentDefinition.Features.ExtrudeFeatures.Add(oExtrudeDefinition);
        }
    }
}
