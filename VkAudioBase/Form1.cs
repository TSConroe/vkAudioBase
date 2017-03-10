using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using System.Threading;

namespace VkAudioBase
{
    public partial class Form1 : Form
    {
        IWebDriver Brouser;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            OpenQA.Selenium.Chrome.ChromeOptions co = new OpenQA.Selenium.Chrome.ChromeOptions();
            co.AddArgument(@"user-data-dir=c:\Users\Conroe\AppData\Local\Google\Chrome\User Data\");
            Brouser = new OpenQA.Selenium.Chrome.ChromeDriver(co);
            Brouser.Navigate().GoToUrl("https://vk.com/audio");
            
            IJavaScriptExecutor jse = Brouser as  IJavaScriptExecutor;
            //for (int i = 10; i > 0; i--)
            {
                jse.ExecuteScript("window.scrollBy(1000,2500000)");
                Thread.Sleep(2000);
            }
           // string stl_side = Brouser.FindElement(By.CssSelector("stl_side")).ToString();
            jse.ExecuteScript("window.scrollBy(1000,2500000)");
            List<IWebElement> VkAudioArtist = Brouser.FindElements(By.ClassName("audio_performer")).ToList();
            List<IWebElement> VkAudioTrack = Brouser.FindElements(By.ClassName("audio_title")).ToList();
            List<IWebElement> VkAudioTrackDuration = Brouser.FindElements(By.ClassName("audio_duration")).ToList();




            for (int i = 0; i < VkAudioArtist.Count; i++)
            {
                textBox1.AppendText( i + ": "+  VkAudioArtist[i].Text + "-" +  VkAudioTrack[i].Text + " " +VkAudioTrackDuration[i].Text + "\r\n");
            }
          //  textBox1.AppendText(stl_side);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
