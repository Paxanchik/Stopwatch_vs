using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stopwatch
{
    public partial class Form1 : Form
    {
        private int seconds = 0;
        private int minutes = 0;
        private int hours = 0;
        private bool isRunning = false;
        private DateTime startTime;
        private TimeSpan elapsedTime;
        public Form1()
        {
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("HH:mm:ss");
            label2.Text = DateTime.Now.ToString("d");
            label3.Text = DateTime.Now.ToString("dddd");
            seconds++;
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                // Остановить секундомер
                isRunning = false;
                elapsedTime += DateTime.Now - startTime;
                timer2.Stop();
                button1.Text = "Старт";
            }
            else
            {
                // Запустить секундомер
                isRunning = true;
                startTime = DateTime.Now;
                timer2.Start();
                button1.Text = "Стоп";
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            // Обновить отображение времени
            TimeSpan currentTime = DateTime.Now - startTime;
            TimeSpan totalTime = currentTime + elapsedTime;
            string timeString = string.Format("{0:00}:{1:00}:{2:00}",
                totalTime.Hours, totalTime.Minutes, totalTime.Seconds);
            label4.Text = timeString;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Сбросить секундомер
            isRunning = false;
            elapsedTime = TimeSpan.Zero;
            timer2.Stop();
            label4.Text = "00:00:00";
            button1.Text = "Старт";
            timer2.Interval = 1000;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer2.Interval += 100;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer2.Interval -= 100;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}