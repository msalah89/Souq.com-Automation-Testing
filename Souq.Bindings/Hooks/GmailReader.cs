#region

using HtmlAgilityPack;
using OpenPop.Pop3;

#endregion

namespace Souq.Bindings.Hooks
{
    public class GmailReader
    {
        private Pop3Client _client;

        public void Connect(string hostname, string username, string password, int port, bool isUseSsl)
        {
            _client = new Pop3Client();
            _client.Connect(hostname, port, isUseSsl);
            _client.Authenticate(username, password);
        }


        /// <summary>
        ///     Here we open Gmail inbox via pop and read last email received from Souq.com with subject Souq.com Password
        /// </summary>
        /// <returns></returns>
        public string GetResetPasswordLink()
        {
            var resetpasswordlink = "";
            var m = new MailRepository();
            m.Connect("pop.gmail.com", "automationroot@gmail.com", "reversalizer89", 995, true);
            var messsages = m.GetMail();

            foreach (var message in messsages)
                if (message.Headers.Subject.Contains("Souq.com Password"))
                {
                    //var body = mm.MessagePart.MessageParts[0].FindFirstHtmlVersion()
                    var emailHtml = new HtmlDocument();
                    emailHtml.LoadHtml(message.FindFirstHtmlVersion().GetBodyAsText());
                    foreach (var link in emailHtml.DocumentNode.SelectNodes("//a[@href]"))
                        if (link.InnerText == "reset password")
                        {
                            resetpasswordlink = link.Attributes["href"].Value;
                            return resetpasswordlink;
                        }
                }

            return resetpasswordlink;
        }
    }
}