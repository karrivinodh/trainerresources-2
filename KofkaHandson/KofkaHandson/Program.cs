using KafkaNet.Model;
using KafkaNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KofkaHandson
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            Uri uri = new Uri("http://localhost:9092");
            string topicName = "chat-message";
            var options = new KafkaOptions(uri);
            var brokerRouter = new BrokerRouter(options);
            var consumer = new Consumer(new ConsumerOptions(topicName, brokerRouter));
            foreach (var msg in consumer.Consume())
            {
                Console.WriteLine(Encoding.UTF8.GetString(msg.Value));
            }
            Console.ReadLine();
        }
    }
}
