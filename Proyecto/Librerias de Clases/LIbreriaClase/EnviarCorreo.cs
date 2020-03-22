using System;
using System.Net;
using System.Net.Mail;
using System.IO;
using Glimpse.AspNet.Tab;
using System.Reflection;

namespace LibreriaClase
{
    public class EnviarCorreo { 
    
        public void enviarCorreo(String correo, String msg, String subject)
        {
          /*  var random = new Random();
            Double NumConf = Math.Round((random.NextDouble() * 9000000) + 1000000);*/
            MailAddress dirOrigen = new MailAddress("galvarez024@ikasle.ehu.eus", "Ministerio del Interior, Gobierno de España");
            MailAddress dirDestino = new MailAddress(correo);
            MailMessage mensaje = new MailMessage(dirOrigen, dirDestino);

            mensaje.Subject = subject;

        //    string body = "EL ENLACE PARA RESTABLECER TU CONTRASEÑA YA ESTÁ LISTO :"+enlace;

            // var assembly = Assembly.GetExecutingAssembly();
            // string[] names = assembly.GetManifestResourceNames();
            // StreamReader reader = new StreamReader(assembly.GetManifestResourceStream("proyectoHADS.LIbreriaClase.EmailTemplate.html"));
            //  body = reader.ReadToEnd();
            // body = body.Replace("{URL}", enlace2);

            mensaje.Body = msg;
            SmtpClient cliente = new SmtpClient("smtp.ehu.eus", 587)
            {
                Credentials = new NetworkCredential("galvarez024@ikasle.ehu.eus", "********"),
                EnableSsl = true
            };

            try
            {
                cliente.Send(mensaje);
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
