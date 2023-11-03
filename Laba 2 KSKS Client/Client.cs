using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Laba_2_KSKS_Client
{
    public partial class Client : Form
    {
        UdpClient udpClient = new UdpClient();
        IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 8080);
        string[] parames = new string[100];
        public Client()
        {
            InitializeComponent();
            udpClient.Connect("localhost", 8080);
            udpClient.Client.ReceiveBufferSize = 64000;
            udpClient.Client.SendBufferSize = 64000;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butSend_Click(object sender, EventArgs e)
        {
            infoLab.Visible = false;
            xLab.Visible = false;
            yLab.Visible = false;
            x1Lab.Visible = false;
            y1Lab.Visible = false;
            radxLab.Visible = false;
            radyLab.Visible = false;
            wLab.Visible = false;
            hLab.Visible = false;
            radLab.Visible = false;
            textLab.Visible = false;
            colorLab.Visible = false;

            xBox.Visible = false;
            yBox.Visible = false;
            x1Box.Visible = false;
            y1Box.Visible = false;
            radxBox.Visible = false;
            radyBox.Visible = false;
            wBox.Visible = false;
            hBox.Visible = false;
            radBox.Visible = false;
            textBox.Visible = false;
            colorBox.Visible = false;
            butSend.Visible = false;

            parames[1] = xBox.Text;
            parames[2] = yBox.Text;
            parames[3] = x1Box.Text;
            parames[4] = y1Box.Text;
            parames[5] = radxBox.Text;
            parames[6] = radyBox.Text;
            parames[7] = radBox.Text;
            parames[8] = wBox.Text;
            parames[9] = hBox.Text;
            parames[10] = colorBox.Text;
            parames[11] = textBox.Text;

            if (comBox.Text == "clear display")
            {
                var str = string.Join(" ", parames[10]);
                byte[] amountBytes = Encoding.ASCII.GetBytes(str);
                udpClient.Send(amountBytes, amountBytes.Length);
            }
            else if (comBox.Text == "draw pixel")
            {
                var str = string.Join(" ", parames[1] + "", parames[2] + "", parames[10]);
                byte[] amountBytes = Encoding.ASCII.GetBytes(str);
                udpClient.Send(amountBytes, amountBytes.Length);
            }
            else if (comBox.Text == "draw line")
            {
                var str = string.Join(" ", parames[1] + "", parames[2] + "", parames[3] + "", parames[4] + "", parames[10]);
                byte[] amountBytes = Encoding.ASCII.GetBytes(str);
                udpClient.Send(amountBytes, amountBytes.Length);
            }
            else if (comBox.Text == "draw rectangle")
            {
                var str = string.Join(" ", parames[1] + "", parames[2] + "", parames[8] + "", parames[9] + "", parames[10]);
                byte[] amountBytes = Encoding.ASCII.GetBytes(str);
                udpClient.Send(amountBytes, amountBytes.Length);
            }
            else if (comBox.Text == "fill rectangle")
            {
                var str = string.Join(" ", parames[1] + "", parames[2] + "", parames[8] + "", parames[9] + "", parames[10]);
                byte[] amountBytes = Encoding.ASCII.GetBytes(str);
                udpClient.Send(amountBytes, amountBytes.Length);
            }
            else if (comBox.Text == "draw ellipse")
            {
                var str = string.Join(" ", parames[1] + "", parames[2] + "", parames[5] + "", parames[6] + "", parames[10]);
                byte[] amountBytes = Encoding.ASCII.GetBytes(str);
                udpClient.Send(amountBytes, amountBytes.Length);
            }
            else if (comBox.Text == "fill ellipse")
            {
                var str = string.Join(" ", parames[1] + "", parames[2] + "", parames[5] + "", parames[6] + "", parames[10]);
                byte[] amountBytes = Encoding.ASCII.GetBytes(str);
                udpClient.Send(amountBytes, amountBytes.Length);
            }
            else if (comBox.Text == "draw circle")
            {
                var str = string.Join(" ", parames[1] + "", parames[2] + "", parames[7] + "", parames[10]);
                byte[] amountBytes = Encoding.ASCII.GetBytes(str);
                udpClient.Send(amountBytes, amountBytes.Length);
            }
            else if (comBox.Text == "fill circle")
            {
                var str = string.Join(" ", parames[1] + "", parames[2] + "", parames[7] + "", parames[10]);
                byte[] amountBytes = Encoding.ASCII.GetBytes(str);
                udpClient.Send(amountBytes, amountBytes.Length);
            }
            else if (comBox.Text == "draw rounded rectangle")
            {
                var str = string.Join(" ", parames[1] + "", parames[2] + "", parames[7] + "", parames[8] + "", parames[9] + "", parames[10]);
                byte[] amountBytes = Encoding.ASCII.GetBytes(str);
                udpClient.Send(amountBytes, amountBytes.Length);
            }
            else if (comBox.Text == "fill rounded rectangle")
            {
                var str = string.Join(" ", parames[1] + "", parames[2] + "", parames[7] + "", parames[8] + "", parames[9] + "", parames[10]);
                byte[] amountBytes = Encoding.ASCII.GetBytes(str);
                udpClient.Send(amountBytes, amountBytes.Length);
            }
            else if (comBox.Text == "draw text")
            {
                var str = string.Join(" ", parames[11] + "", parames[10] + "", parames[1] + "", parames[2]);
                byte[] amountBytes = Encoding.ASCII.GetBytes(str);
                udpClient.Send(amountBytes, amountBytes.Length);
            }
            else if (comBox.Text == "draw image")
            {
                Image image = Image.FromFile("C:\\Users\\user\\source\\repos\\Laba 2 KSKS Client\\Resources\\imresizer-1698963315290.png");
                MemoryStream ms = new MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] imageData = ms.ToArray();
                udpClient.Send(imageData, imageData.Length);
            }
            else
            {
                MessageBox.Show("Неверная команда!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comBox.Clear();
            }
        }

        private void butComm_Click(object sender, EventArgs e)
        {
            if (comBox.Text == "")
            {
                MessageBox.Show("Введите команду!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (comBox.Text == "clear display")
                {                   
                    infoLab.Visible = true;
                    colorLab.Visible = true;
                    colorBox.Visible = true;
                    butSend.Visible = true;
                    byte[] amountBytes = Encoding.ASCII.GetBytes(comBox.Text);
                    udpClient.Send(amountBytes, amountBytes.Length);
                }
                else if (comBox.Text == "draw pixel")
                {
                    infoLab.Visible = true;
                    xLab.Visible = true;
                    yLab.Visible = true;
                    colorLab.Visible = true;
                    xBox.Visible = true;
                    yBox.Visible = true;
                    colorBox.Visible = true;
                    butSend.Visible = true;
                    byte[] amountBytes = Encoding.ASCII.GetBytes(comBox.Text);
                    udpClient.Send(amountBytes, amountBytes.Length);
                }
                else if (comBox.Text == "draw line")
                {
                    infoLab.Visible = true;
                    xLab.Visible = true;
                    yLab.Visible = true;
                    x1Lab.Visible = true;
                    y1Lab.Visible = true;
                    colorLab.Visible = true;
                    xBox.Visible = true;
                    yBox.Visible = true;
                    x1Box.Visible = true;
                    y1Box.Visible = true;
                    colorBox.Visible = true;
                    butSend.Visible = true;
                    byte[] amountBytes = Encoding.ASCII.GetBytes(comBox.Text);
                    udpClient.Send(amountBytes, amountBytes.Length);
                }
                else if (comBox.Text == "draw rectangle")
                {
                    infoLab.Visible = true;
                    xLab.Visible = true;
                    yLab.Visible = true;
                    wLab.Visible = true;
                    hLab.Visible = true;
                    colorLab.Visible = true;
                    xBox.Visible = true;
                    yBox.Visible = true;
                    wBox.Visible = true;
                    hBox.Visible = true;
                    colorBox.Visible = true;
                    butSend.Visible = true;
                    byte[] amountBytes = Encoding.ASCII.GetBytes(comBox.Text);
                    udpClient.Send(amountBytes, amountBytes.Length);
                }
                else if (comBox.Text == "fill rectangle")
                {
                    infoLab.Visible = true;
                    xLab.Visible = true;
                    yLab.Visible = true;
                    wLab.Visible = true;
                    hLab.Visible = true;
                    colorLab.Visible = true;
                    xBox.Visible = true;
                    yBox.Visible = true;
                    wBox.Visible = true;
                    hBox.Visible = true;
                    colorBox.Visible = true;
                    butSend.Visible = true;
                    byte[] amountBytes = Encoding.ASCII.GetBytes(comBox.Text);
                    udpClient.Send(amountBytes, amountBytes.Length);
                }
                else if (comBox.Text == "draw ellipse")
                {
                    infoLab.Visible = true;
                    xLab.Visible = true;
                    yLab.Visible = true;
                    radxLab.Visible = true;
                    radyLab.Visible = true;
                    colorLab.Visible = true;
                    xBox.Visible = true;
                    yBox.Visible = true;
                    radxBox.Visible = true;
                    radyBox.Visible = true;
                    colorBox.Visible = true;
                    butSend.Visible = true;
                    byte[] amountBytes = Encoding.ASCII.GetBytes(comBox.Text);
                    udpClient.Send(amountBytes, amountBytes.Length);
                }
                else if (comBox.Text == "fill ellipse")
                {
                    infoLab.Visible = true;
                    xLab.Visible = true;
                    yLab.Visible = true;
                    radxLab.Visible = true;
                    radyLab.Visible = true;
                    colorLab.Visible = true;
                    xBox.Visible = true;
                    yBox.Visible = true;
                    radxBox.Visible = true;
                    radyBox.Visible = true;
                    colorBox.Visible = true;
                    butSend.Visible = true;
                    byte[] amountBytes = Encoding.ASCII.GetBytes(comBox.Text);
                    udpClient.Send(amountBytes, amountBytes.Length);
                }
                else if (comBox.Text == "draw circle")
                {
                    infoLab.Visible = true;
                    xLab.Visible = true;
                    yLab.Visible = true;
                    radLab.Visible = true;
                    colorLab.Visible = true;
                    xBox.Visible = true;
                    yBox.Visible = true;
                    radBox.Visible = true;
                    colorBox.Visible = true;
                    butSend.Visible = true;
                    byte[] amountBytes = Encoding.ASCII.GetBytes(comBox.Text);
                    udpClient.Send(amountBytes, amountBytes.Length);
                }
                else if (comBox.Text == "fill circle")
                {
                    infoLab.Visible = true;
                    xLab.Visible = true;
                    yLab.Visible = true;
                    radLab.Visible = true;
                    colorLab.Visible = true;
                    xBox.Visible = true;
                    yBox.Visible = true;
                    radBox.Visible = true;
                    colorBox.Visible = true;
                    butSend.Visible = true;
                    byte[] amountBytes = Encoding.ASCII.GetBytes(comBox.Text);
                    udpClient.Send(amountBytes, amountBytes.Length);
                }
                else if (comBox.Text == "draw rounded rectangle")
                {
                    infoLab.Visible = true;
                    xLab.Visible = true;
                    yLab.Visible = true;
                    wLab.Visible = true;
                    hLab.Visible = true;
                    radLab.Visible = true;
                    colorLab.Visible = true;
                    xBox.Visible = true;
                    yBox.Visible = true;
                    wBox.Visible = true;
                    hBox.Visible = true;
                    radBox.Visible = true;
                    colorBox.Visible = true;
                    butSend.Visible = true;
                    byte[] amountBytes = Encoding.ASCII.GetBytes(comBox.Text);
                    udpClient.Send(amountBytes, amountBytes.Length);
                }
                else if (comBox.Text == "fill rounded rectangle")
                {
                    infoLab.Visible = true;
                    xLab.Visible = true;
                    yLab.Visible = true;
                    wLab.Visible = true;
                    hLab.Visible = true;
                    radLab.Visible = true;
                    colorLab.Visible = true;
                    xBox.Visible = true;
                    yBox.Visible = true;
                    wBox.Visible = true;
                    hBox.Visible = true;
                    radBox.Visible = true;
                    colorBox.Visible = true;
                    butSend.Visible = true;
                    byte[] amountBytes = Encoding.ASCII.GetBytes(comBox.Text);
                    udpClient.Send(amountBytes, amountBytes.Length);
                }
                else if (comBox.Text == "draw text")
                {
                    infoLab.Visible = true;
                    xLab.Visible = true;
                    yLab.Visible = true;
                    textLab.Visible = true;
                    colorLab.Visible = true;
                    xBox.Visible = true;
                    yBox.Visible = true;
                    textBox.Visible = true;
                    colorBox.Visible = true;
                    butSend.Visible = true;
                    byte[] amountBytes = Encoding.ASCII.GetBytes(comBox.Text);
                    udpClient.Send(amountBytes, amountBytes.Length);
                }
                else if (comBox.Text == "draw image")
                {
                    butSend.Visible = true;
                    byte[] amountBytes = Encoding.ASCII.GetBytes(comBox.Text);
                    udpClient.Send(amountBytes, amountBytes.Length);       
                }
                else
                {
                    MessageBox.Show("Неверная команда!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comBox.Clear();
                }
            }          
        }

        private void butClear_Click(object sender, EventArgs e)
        {
            comBox.Clear();
        }
    }        
}