using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacBasic_Two
{

    public interface IMobileServive
    {
        void Execute();
    }


    public class SMSService : IMobileServive
    {
        public void Execute()
        {
            Console.WriteLine("SMS service executing.");
        }
    }



    public interface IMailService
    {
        void Execute();
    }



    public class EmailService : IMailService
    {
        public void Execute()
        {
            Console.WriteLine("Email service Executing.");
        }
    }

    //NotificationSender class that is dependent on both MobileService and MailService. 
    public class NotificationSender                                  
    {
        public IMobileServive ObjMobileSerivce = null;
        public IMailService ObjMailService = null;

                                                                    
        public NotificationSender(IMobileServive tmpService)   //Injection through constructor 
        {
            ObjMobileSerivce = tmpService;
        }

       
        public IMailService SetMailService                     //Injection through property  
        {
            set { ObjMailService = value; }
        }
        public void SendNotification()
        {
            ObjMobileSerivce.Execute();
            ObjMailService.Execute();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<SMSService>().As<IMobileServive>();
            builder.RegisterType<EmailService>().As<IMailService>();
            var container = builder.Build();

            container.Resolve<IMobileServive>().Execute();
            container.Resolve<IMailService>().Execute();
            Console.ReadLine();
        }
    }
}
