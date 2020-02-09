using System;
using System.Net;
using System.Net.Mail;

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
            string html = @"<html>
	                      <body>
	                      <p> Sr/Sra Cliente</p>
	                      <p> <a ";
            string enlace = Convert.ToString("http://localhost/PracticaHAS/confirmar.aspx?mbr=pepe%40pepe.pepe&numconf=9715284");
            string enlace2 = enlace + NumConf+ "></a> </p></html>";
            string html2 = String.Concat(html, enlace2);

            mensaje.Body = html2;
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
