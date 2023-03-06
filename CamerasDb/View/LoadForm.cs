using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace CamerasDb.View
{
    public partial class LoadForm : Form
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        public LoadForm()
        {
            InitializeComponent();
            label1.Text = "Иде загрузка. Пожайлусста, подождите.";
            label1.Location = new Point((this.Width - label1.Width) / 2, (this.Height - label1.Height) / 2);
            progressBar1.Location = new Point((this.Width - progressBar1.Width) / 2, (this.Height - progressBar1.Height)/ 3);
            ThreadPool.QueueUserWorkItem((obj) => { FillProgressBar(progressBar1, cts.Token); });
           
        }

        private async void FillProgressBar(object x, CancellationToken token)
        {
            await Task.Run(() =>
            {
                ProgressBar pb = (ProgressBar)x;

                while (pb.Value < pb.Maximum)
                {
                    try
                    {
                        if (token.IsCancellationRequested == true) break;
                        if (this.InvokeRequired) this.Invoke(new Action(() => pb.Value++));
                        Thread.Sleep(30);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }
                cts.Cancel();
                this.Close();
            });
            
        }
    }
}
