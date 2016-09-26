using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.WebPages;
using AngularJSWebApiEmpty.Models;

namespace AngularJSWebApiEmpty.Controllers
{
    public class SerialController : ApiController
    {
        public static void ReceiveSerial()
        {
            SerialPort arduinoPort = new SerialPort("COM3");

            arduinoPort.BaudRate = 9600;
            arduinoPort.Parity = Parity.None;
            arduinoPort.StopBits = StopBits.One;
            arduinoPort.DataBits = 8;
            arduinoPort.Handshake = Handshake.None;
            arduinoPort.RtsEnable = true;

            arduinoPort.DataReceived += new SerialDataReceivedEventHandler(DataReceiverHandler);

            //arduinoPort.Open();

            while (true) ;

        }

        public static void DataReceiverHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            using (var db = new BreweryEntities())
            {
                var t = new test();
                t.value = indata.Trim();
                if (!t.value.IsEmpty())
                {
                    db.test.Add(t);
                    db.SaveChanges();
                }
            }
        }
    }
}
