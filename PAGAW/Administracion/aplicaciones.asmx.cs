﻿using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace PAGAW.Administracion
{/// <summary>
 /// Descripción breve de WebService1
    /*
     * 29/04/2018
     * Lucrecia Zuñiga Saenz
     * Web service creado para ser usado por datatables y creacion de archivos json
     * para consultas que devuelven miles de tuplas y que lo haga en el menor 
     * tiempo posible.
     */
   
    //necesario para que el metodo pueda ser reconocido como metodo en la ejecucion. Si no esta
    // este metodo generar error.
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]

    public class WebService1 : System.Web.Services.WebService
    {
        //UnidadAdministrativaServicios UAservices = new UnidadAdministrativaServicios();

        AplicacionServicios appServices = new AplicacionServicios();
        BitacoraDeVersionesServicios bitacoraServices = new BitacoraDeVersionesServicios();

        [WebMethod]
        public void getTodasAplicaciones(string tipoServidor) 
        {
            //se trae la lista como en cualquier metodo
            List<Aplicacion> listaAplicaciones = appServices.getAppsTipoServidor(tipoServidor);
            // en la variable se mete los datos necesario para que se genere el archivo json.
            var resultado = new
            {
                iTotalRecords = listaAplicaciones.Count,
                iTotalDisplayRecords = listaAplicaciones.Count,
                aaData = listaAplicaciones
            };
            //Se utiliza JavaScritp Serializer para poder crear el archivo json con los valores de la lista
            //el tamaño se setea al maximo ya que esto es para consultas que devuelvan miles de tuplas.
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(resultado));
        }

        [WebMethod]
        public void getDatosBitacora()
        {
            //se trae la lista como en cualquier metodo
            List<BitacoraDeVersiones> listaBitacoraVersiones = bitacoraServices.obtenerBitacoraVersiones();
            // en la variable se mete los datos necesario para que se genere el archivo json.
            var resultado = new
            {
                iTotalRecords = listaBitacoraVersiones.Count,
                iTotalDisplayRecords = listaBitacoraVersiones.Count,
                aaData = listaBitacoraVersiones
            };

            //Se utiliza JavaScritp Serializer para poder crear el archivo json con los valores de la lista
            //el tamaño se setea al maximo ya que esto es para consultas que devuelvan miles de tuplas.
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(resultado));
        }

        [WebMethod]
        public void getTodasUnidadesAdministrativas()
        {
            //se trae la lista como en cualquier metodo
            //List<UnidadAdministrativa> listaUnidades = UAservices.getUAs();
            // en la variable se mete los datos necesario para que se genere el archivo json.
           /* var resultado = new
            {
                iTotalRecords = listaUnidades.Count,
                iTotalDisplayRecords = listaUnidades.Count,
                aaData = listaUnidades
            };
            //Se utiliza JavaScritp Serializer para poder crear el archivo json con los valores de la lista
            //el tamaño se setea al maximo ya que esto es para consultas que devuelvan miles de tuplas.
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(resultado));*/
        }
    }
}
