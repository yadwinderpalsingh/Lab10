using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Windows.Forms;


namespace Lab10
{
    public partial class Form1 : Form
    {
        GMapOverlay markersOverlay;
        public Form1()
        {
            InitializeComponent();
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            markersOverlay = new GMapOverlay();
            gMapControl1.Overlays.Add(markersOverlay);

            gMapControl1.SetBounds(0,0,ClientRectangle.Width,ClientRectangle.Height);

            gMapControl1.MapProvider = OviTerrainMapProvider.Instance;
            GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gMapControl1.MinZoom = 1;
            gMapControl1.MaxZoom = 121;
            gMapControl1.Zoom = 4;
            gMapControl1.GrayScaleMode = true;

            pictureBox1.Parent = gMapControl1;
            pictureBox1.SetBounds(0, 0, ClientRectangle.Width, ClientRectangle.Height);

            gMapControl1.Position = new PointLatLng(43.3894038,-80.4065549);
            gMapControl1.Zoom = 12;

        }

        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Drop a target on campus at a random location +/- 100 metres
            var r=new Random();
            //print random integer between -100 and 100
            double randomLat = 43.389758 + 0.0001 * r.Next(-100,100);
            double randomLon = -80.405068+ 0.0001 * r.Next(-100, 100);

            GMarkerGoogle marker =
                new GMarkerGoogle(new GMap.NET.PointLatLng(randomLat, randomLon),
                GMarkerGoogleType.red_big_stop);
            markersOverlay.Markers.Add(marker);
        }
    }
}
