using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing.Constraints;
using System.Web.WebPages;
using AngularJSWebApiEmpty.Hubs;
using AngularJSWebApiEmpty.Models;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json.Linq;

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
            //arduinoPort.DiscardInBuffer();

            while (true) ;
        }

        public static void DataReceiverHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadLine();

            var beer = new BeerController();
            var beerId = JObject.Parse(beer.GetBeer().ToString()).ToObject<CompleteBeer>().Id;



            if (!indata.IsEmpty())
            {
                if (indata[0] != '#')
                {
                    ReadTemperature(indata, beerId);
                }
                else
                {
                    ReadPump(indata, beerId);
                }
                var hubcontext = GlobalHost.ConnectionManager.GetHubContext<BeerHub>();
                hubcontext.Clients.All.signalUpdate();
            }
        }

        public static void ReadTemperature(string data, int beerId)
        {
            var temp = new Temperatures
            {
                BeerId = beerId,
                Temp = float.Parse(data.Trim().Replace(".", ",")),
                Time = DateTime.Now,
            };
            using (var db = new BreweryEntities())
            {
                db.Temperatures.Add(temp);
                db.SaveChanges();
            }
        }

        public static void ReadPump(string data, int beerId)
        {
            int temp = int.Parse(data.Trim('#'));
        }

    }
}
