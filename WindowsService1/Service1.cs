using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1
{
    public partial class Service1 : ServiceBase
    {
        String s = "";
        System.Threading.Thread listener = null;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            if (listener != null)
                listener = new System.Threading.Thread(new System.Threading.ThreadStart(startListening));
        }

        void startListening()
        {

        }
        protected override void OnStop()
        {
        }
    }
}
