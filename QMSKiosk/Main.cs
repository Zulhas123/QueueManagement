using Microsoft.EntityFrameworkCore;
using QMSKiosk.Enum;
using QMSKiosk.Manager;
using QMSKiosk.Models;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using QMSKiosk.Interface.Manager;

namespace QMSKiosk
{
    public partial class Main : Form
    {
        private IServiceInfoManager _serviceInfoManager;
        private IServiceReceiverManager _serviceReceiverManager;
        private IOrganizationManager _organizationManager;
        private static Organization organization;
        private static int? lastServiceId;
        public Main()
        {
            InitializeComponent(); ;
            _organizationManager = new OrganizationManager(new QmsDbContext());
            var org = _organizationManager.GetOrganization();
            if (org != null && org.LogoBase64 != null)
            {
                organization = org;
                byte[] imageBytes = Convert.FromBase64String(org.LogoBase64);
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    tokenPrintBox.Image = Image.FromStream(ms);
                }
            }
            timer1.Start();

        }


        protected void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int id = Convert.ToInt32(button.Name);
            LoadService(id);

        }
        private void LoadService(int? serviceId)
        {
            lastServiceId = serviceId;
            var db = new QmsDbContext();
            tableLayoutPanel1.Controls.Clear();
            _serviceInfoManager = new ServiceInfoManager(db);
            var services = _serviceInfoManager.GetByParentId(serviceId);

            if (serviceId != null && services.Count == 0)
            {

                PrintToken(serviceId ?? 0);
                //Print
                LoadService(null);
            }
            else
            {
              //  int count = services.Count;
                int heigt = 100;
                int i = 0;
                //  int colIndex = 0;
                //  int loopCount = 0;
                foreach (var service in services)
                {
                    Button btn = new Button();
                    btn.Click += new EventHandler(button_Click);
                    btn.BackColor = Color.Green;
                    btn.ForeColor = Color.White;
                    btn.Font = new Font("Poppins", 22, FontStyle.Bold);
                    btn.Text = service.Name;
                    btn.Name = service.Id.ToString();
                    btn.Height = heigt;
                   btn.Width = 2000;
                   
                    tableLayoutPanel1.Controls.Add(btn, 0, i);
                   
                    i++;

                }
            }






        }
        #region .. Double Buffered function ..
        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                return;
            System.Reflection.PropertyInfo aProp = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            aProp.SetValue(c, true, null);
        }

        #endregion


        #region .. code for Flucuring ..

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        private string SaveUniqueSerial(int serviceId)
        {
            var db = new QmsDbContext();
            _serviceInfoManager = new ServiceInfoManager(db);
            string tokenNo = "";
            var getService = _serviceInfoManager.GetById(serviceId);
            if (getService != null)
            {
                _serviceName = getService.Name;
                _serviceReceiverManager = new ServiceReceiverManager(db);
                int serial = 101;
                var lastReceiver = _serviceReceiverManager.GetLastReceiver(serviceId);

                if (lastReceiver != null)
                {
                    serial = lastReceiver.SerialNo + 1;

                }
                ServiceReceiver serviceReceiver = new ServiceReceiver
                {
                    SerialNo = serial,
                    ServiceInfoId = serviceId,
                    TokenCreationDate = DateTime.Now,
                    TokenNo = getService.TokenStart + serial,
                    Status = (int)ServiceReceiverStatus.Waiting
                };
                tokenNo = serviceReceiver.TokenNo;
                _serviceReceiverManager.Add(serviceReceiver);
            }
            return tokenNo;

        }
        private static string _tokenNo = "";
        private static string _serviceName = "";
        public void PrintToken(int serviceId)
        {
            _tokenNo = SaveUniqueSerial(serviceId);
            //db.SaveChanges();
            PrintDialog pd = new PrintDialog();
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += Doc_PrintPage;
            pd.Document = doc;
            //if (pd.ShowDialog() == DialogResult.OK)
            doc.Print();

        }
        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            //Print image
            Bitmap bm = new Bitmap(100, 100);
            bm.MakeTransparent();
            Rectangle rectf = new Rectangle(35, 10, 150, 150);
            tokenPrintBox.DrawToBitmap(bm, rectf);
            e.Graphics.DrawImage(bm, 35, 10);
            
            //e.Graphics.TranslateTransform(190, 0);
            //e.Graphics.RotateTransform(90);
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            e.Graphics.DrawString(organization.Name, new Font("Poppins", 14, FontStyle.Bold), Brushes.Black, 10, 70);
            //e.Graphics.DrawString(organization.Address, new Font("Poppins", 10), Brushes.Black, 10, 88);
            e.Graphics.DrawString(_tokenNo, new Font("Poppins", 20), Brushes.Black, 50, 95);
            e.Graphics.DrawString(_serviceName, new Font("Poppins", 16), Brushes.Black, 30, 130);
            e.Graphics.DrawLine(pen, 10, 170, 250, 170);
            e.Graphics.DrawString("Please check display for your turn", new Font("Poppins", 9), Brushes.Black, 10, 190);
            e.Graphics.ResetTransform();
            bm.Dispose();
        }

        #endregion
        private void Main_Load(object sender, EventArgs e)
        {
            SetDoubleBuffered(tableLayoutPanel1);
            LoadService(null);

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            var getService = _serviceInfoManager.GetById(lastServiceId ?? 0);
            lastServiceId = getService == null ? null : getService.ParentId;
            LoadService(lastServiceId);

        }

        private static int clickCount = 0;
        private void label2_Click(object sender, EventArgs e)
        {
            clickCount++;
            if (clickCount == 5)
            {
                clickCount = 0;
                Form1 f = new Form1();
                f.ShowDialog();

            }
        }

        private int lastClickTime = 60000;
        private void timer1_Tick(object sender, EventArgs e)
        {
            lastClickTime--;
            if (lastClickTime == 0)
            {
                clickCount = 0;
                lastClickTime = 60000;
            }
        }
    }
}