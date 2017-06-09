using Case.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Case.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Mailer" in both code and config file together.
    public class Mailer : IMailer
    {
        //Create 15 SMTP connections to the server.
        //We don't want to create some sort of DoS (Denial-of-service) attack
        //because we don't want to create a new SMTP connection
        //for every email being sent.

        private const int _clientcount = 15;
        private SmtpClient[] _smtpClients = new SmtpClient[_clientcount + 1];
        private CancellationTokenSource _cancelToken;
        public Mailer()
        {
            setupSMTPClients();
        }

        public void StartEmailProcess(List<Messages> data)
        {
            try
            {
                ParallelOptions po = new ParallelOptions();
                //Create a cancellation token so you can cancel the task.
                _cancelToken = new CancellationTokenSource();
                po.CancellationToken = _cancelToken.Token;
                //Manage the MaxDegreeOfParallelism instead of .NET Managing this. We dont need 500 threads spawning for this.
                po.MaxDegreeOfParallelism = System.Environment.ProcessorCount * 2;
                try
                {
                    Parallel.ForEach(data, po, (Messages dataobject) =>
                    {
                        try
                        {
                            MailMessage msg = new MailMessage(dataobject.MessageFrom, dataobject.MessageTo);
                            msg.Subject = dataobject.Subject;
                            msg.Body = dataobject.Message;
                            msg.Priority = MailPriority.Normal;
                            SendEmail(msg);
                        }
                        catch (Exception ex)
                        {
                            //Log error
                        }
                    });
                }
                catch (OperationCanceledException e)
                {
                    //User has cancelled this request.
                }
            }
            finally
            {
                disposeSMTPClients();
            }
        }

        public void CancelEmailProcess()
        {
            _cancelToken.Cancel();
        }

        private void SendEmail(MailMessage msg)
        {
            try
            {
                bool _gotlocked = false;
                while (!_gotlocked)
                {
                    //Keep looping through all smtp client connections until one becomes available
                    for (int i = 0; i <= _clientcount; i++)
                    {
                        if (Monitor.TryEnter(_smtpClients[i]))
                        {
                            try
                            {
                                _smtpClients[i].Send(msg);
                            }
                            finally
                            {
                                Monitor.Exit(_smtpClients[i]);
                            }
                            _gotlocked = true;
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }
                    //Do this to make sure CPU doesn't ramp up to 100%
                    Thread.Sleep(10);
                }
            }
            finally
            {
                msg.Dispose();
            }
        }

        private void setupSMTPClients()
        {
            for (int i = 0; i <= _clientcount; i++)
            {
                try
                {
                    SmtpClient _client = new SmtpClient("127.0.0.1", 25);
                    //If your SMTP server requires authentication do the following below
                    _client.Credentials = new System.Net.NetworkCredential("yourusername", "yourpassword", "yourdomain");
                    _smtpClients[i] = _client;
                }
                catch (Exception ex)
                {
                    //Log Exception
                }
            }
        }

        private void disposeSMTPClients()
        {
            for (int i = 0; i <= _clientcount; i++)
            {
                try
                {
                    _smtpClients[i].Dispose();
                }
                catch (Exception ex)
                {
                    //Log Exception
                }
            }
        }
    }
}
