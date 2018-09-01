#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OpenPop.Mime;
using OpenPop.Pop3;

#endregion

namespace Souq.Bindings.Hooks
{
    public class MailRepository
    {
        private Pop3Client _client { get; set; }

        public void Connect(string hostname, string username, string password, int port, bool isUseSsl)
        {
            _client = new Pop3Client();
            _client.Connect(hostname, port, isUseSsl);
            _client.Authenticate(username, password);
        }

        public List<Message> GetMail()
        {
            var messageCount = _client.GetMessageCount();

            var allMessages = new List<Message>(messageCount);

            for (var i = messageCount; i > 0; i--) allMessages.Add(_client.GetMessage(i));

            return allMessages;
        }

        public List<Pop3Mail> GetMail(string toAddress)
        {
            var messageCount = _client.GetMessageCount();

            var allMessages = new List<Pop3Mail>();

            for (var i = messageCount; i > 0; i--)
            {
                var msg = _client.GetMessage(i);

                allMessages.Add(new Pop3Mail {MailMsg = msg, MessageNumber = i});
            }

            var relevantMail = allMessages.Where(m => m.MailMsg.Headers.To.Any(n => n.Address == toAddress)).ToList();

            return relevantMail;
        }

        public List<Pop3Mail> GetMail(string toAddress, string fromAddress)
        {
            var messageCount = _client.GetMessageCount();

            var allMessages = new List<Pop3Mail>();

            for (var i = messageCount; i > 0; i--)
            {
                var msg = _client.GetMessage(i);

                allMessages.Add(new Pop3Mail {MailMsg = msg, MessageNumber = i});
            }

            var relevantMail = allMessages.Where(m =>
                    m.MailMsg.Headers.From.Address == fromAddress &&
                    m.MailMsg.Headers.To.Any(n => n.Address == toAddress))
                .ToList();

            return relevantMail;
        }

        public List<string> GetAttachments(Message msg)
        {
            var getAttachments = new List<string>();

            var attachments = msg.FindAllAttachments();
            var attachmentdirectory = @"c:\temp\mail\attachments";

            Directory.CreateDirectory(attachmentdirectory);

            foreach (var att in attachments)
            {
                var filename = string.Format(@"{0}{1}_{2}{3}", attachmentdirectory,
                    Path.GetFileNameWithoutExtension(att.FileName), DateTime.Now.ToString("MMddyyyyhhmmss"),
                    Path.GetExtension(att.FileName));
                att.Save(new FileInfo(filename));

                getAttachments.Add(filename);
            }

            return getAttachments;
        }

        public void DeleteAll()
        {
            _client.DeleteAllMessages();
        }

        public void Delete(int msgNumber)
        {
            _client.DeleteMessage(msgNumber);
        }
    }

    public class Pop3Mail
    {
        public int MessageNumber { get; set; }
        public Message MailMsg { get; set; }
    }
}