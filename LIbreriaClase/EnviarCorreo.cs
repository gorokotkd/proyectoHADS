using System;
using System.Net;
using System.Net.Mail;
using System.IO;

namespace LibreriaClase
{
    public class EnviarCorreo { 
    
        public void enviarCorreo(String correo)
        {
            var random = new Random();
            Double NumConf = Math.Round((random.NextDouble() * 9000000) + 1000000);
            MailAddress dirOrigen = new MailAddress("iakigarcianoya@gmail.com", "Iñaki García");
            MailAddress dirDestino = new MailAddress(correo);
            MailMessage mensaje = new MailMessage(dirOrigen, dirDestino);

            mensaje.Subject = "Confirmación de correo";
            string enlace = Convert.ToString("http://localhost/PracticaHAS/confirmar.aspx?mbr=pepe%40pepe.pepe&numconf=");
            string enlace2 = enlace + NumConf;
            string body = string.Empty;

            using (StreamReader reader = new StreamReader(("~/EmailTemplate.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{URL}", enlace2);
            mensaje.Body = body;
            SmtpClient cliente = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("iakigarcianoya@gmail.com", "iakigarcianoya"),
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
