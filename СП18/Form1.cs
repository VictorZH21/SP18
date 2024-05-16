using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;

namespace СП18
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManagementObjectCollection collection;
            using (var finddevice = new ManagementObjectSearcher(@"Select * From Win32_USBHub"))
                collection = finddevice.Get();
            foreach (var device in collection)
            {
                listBox1.Items.Add(device.GetPropertyValue("DeviceID"));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
                MessageBox.Show("Устройство успешно удалено!");
            }
            else
            {
                MessageBox.Show("Не выбрано устройство для удаления!");
            }
        }
    }
}
