using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PAGAW
{
    public partial class Ayuda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          //int[] rolesPermitidos = { 2 };
            //Utilidades.escogerMenu(Page, rolesPermitidos);
            //username.InnerText = "Bienvenid@ " + Session["nombreCompleto"].ToString();
            //txtUsuario.Text = Session["nombreCompleto"].ToString();

        }

        protected void btnEnviarCorreo_Click(object sender, EventArgs e)
        {
            EnviarCorreo();
        }


        public void EnviarCorreo()
        {
            /*-------------------------MENSAJE DE CORREO----------------------*/

            //Creamos un nuevo Objeto de mensaje
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            //Direccion de correo electronico a la que queremos enviar el mensaje
            //mmsg.To.Add("josevalverde93@gmail.com");
            mmsg.To.Add("smtplannamme@gmail.com");
            //Nota: La propiedad To es una colección que permite enviar el mensaje a más de un destinatario

            //Asunto
            mmsg.Subject = txtAsunto.Text;
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            //Direccion de correo electronico que queremos que reciba una copia del mensaje
            mmsg.Bcc.Add("smtplannamme@gmail.com"); //Opcional

            //Cuerpo del Mensaje

            mmsg.Body ="El usuario:"+txtUsuario.Text +" envía:"+txtMensaje.Text;
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = false; //Si no queremos que se envíe como HTML

            //Correo electronico desde la que enviamos el mensaje
            mmsg.From = new System.Net.Mail.MailAddress("smtplannamme@gmail.com");


            /*-------------------------CLIENTE DE CORREO----------------------*/

            //Creamos un objeto de cliente de correo
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

            //Hay que crear las credenciales del correo emisor
            cliente.Credentials =
                new System.Net.NetworkCredential("smtplannamme@gmail.com", "lanammeUCR");


            cliente.Port = 587;
            cliente.EnableSsl = true;


            cliente.Host = "smtp.gmail.com"; //Para Gmail "smtp.gmail.com";


            /*-------------------------ENVIO DE CORREO----------------------*/

            try
            {
                //Enviamos el mensaje      
                cliente.Send(mmsg);
                txtMensaje.Text = "Exito... enviado";
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                txtMensaje.Text = "Error:" + ex;
                //Aquí gestionamos los errores al intentar enviar el correo
            }
        }
    }
}