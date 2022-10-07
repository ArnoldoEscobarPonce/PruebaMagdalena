using MagdalenaBE;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;
using System.Web.Mvc;

namespace Prueba_Magdalena.Controllers
{
    public class InicioController : Controller
    {
        public ActionResult Inicio()
        {
            try
            {
                List<ActividadBE> vLista = new List<ActividadBE>();
                HttpClient _httpClient = new HttpClient();
                var url = "http://localhost:54600/Api/Actividad/Get_Activas";

                using (var content = new StringContent(JsonConvert.SerializeObject(new ActividadBE()), System.Text.Encoding.UTF8, "application/json"))
                {
                    HttpResponseMessage result = _httpClient.GetAsync(url).Result;
                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string jSon = result.Content.ReadAsStringAsync().Result;
                        vLista = JsonConvert.DeserializeObject<List<ActividadBE>>(jSon);
                        return View(vLista);
                    }
                    else
                        return View();
                }

                //dal.ActividadDAL dal = new dal.ActividadDAL();
                //var vLista = dal.Creadas_Listar(new ActividadBE());
                //return View(vLista);
            }
            catch (Exception ex)
            {
                Response.Write(@"<script language='javascript'>alert('" + ex.Message + "');</script>");
                return View();
            }
        }
        public ActionResult VerFinalizadas()
        {
            try
            {
                List<ActividadBE> vLista = new List<ActividadBE>();
                HttpClient _httpClient = new HttpClient();
                var url = "http://localhost:54600/Api/Actividad/Get_Finalizadas";

                using (var content = new StringContent(JsonConvert.SerializeObject(new ActividadBE()), System.Text.Encoding.UTF8, "application/json"))
                {
                    HttpResponseMessage result = _httpClient.GetAsync(url).Result;
                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string jSon = result.Content.ReadAsStringAsync().Result;
                        vLista = JsonConvert.DeserializeObject<List<ActividadBE>>(jSon);
                        return View(vLista);
                    }
                    else
                        return RedirectToAction("Inicio");
                }

                //dal.ActividadDAL dal = new dal.ActividadDAL();
                //var vLista = dal.Finalizadas_Listar(new ActividadBE());
                //return View(vLista);
            }
            catch (Exception ex)
            {
                Response.Write(@"<script language='javascript'>alert('" + ex.Message + "');</script>");
                return RedirectToAction("Inicio");
            }
        }
        [HttpGet]
        public ActionResult NuevaActividad()
        {
            try
            {
                List<PrioridadBE> vLista = new List<PrioridadBE>();
                HttpClient _httpClient = new HttpClient();
                var url = "http://localhost:54600/Api/Prioridad/";

                using (var content = new StringContent(JsonConvert.SerializeObject(new ActividadBE()), System.Text.Encoding.UTF8, "application/json"))
                {
                    HttpResponseMessage result = _httpClient.GetAsync(url).Result;
                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string jSon = result.Content.ReadAsStringAsync().Result;
                        vLista = JsonConvert.DeserializeObject<List<PrioridadBE>>(jSon);
                        ViewBag.ListaPrioridad = vLista;
                    }
                    else
                        ViewBag.ListaPrioridad = new List<PrioridadBE>();
                }

                var vNuevaActividad = new ActividadBE();
                return View(vNuevaActividad);
            }
            catch (Exception ex)
            {
                Response.Write(@"<script language='javascript'>alert('" + ex.Message + "');</script>");
                return View();
            }
        }
        [HttpPost]
        public ActionResult GrabarActividad(ActividadBE pActividad)
        {
            try
            {
                HttpClient _httpClient = new HttpClient();
                var url = "http://localhost:54600/Api/Actividad";

                using (var content = new StringContent(JsonConvert.SerializeObject(pActividad), System.Text.Encoding.UTF8, "application/json"))
                {
                    HttpResponseMessage result = _httpClient.PostAsync(url, content).Result;
                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                        return RedirectToAction("Inicio");
                    else
                        return View("NuevaActividad");
                }

                //var vNuevaActividad = new ActividadBE();
                //dal.ActividadDAL dal = new dal.ActividadDAL();
                //dal.Crear(pActividad);
                //return RedirectToAction("Inicio");
            }
            catch (Exception ex)
            {
                Response.Write(@"<script language='javascript'>alert('" + ex.Message + "');</script>");
                return View("NuevaActividad");
            }
        }
        [HttpGet]
        public ActionResult Finalizar(ActividadBE pActividad)
        {
            //return View("", pActividad);
            return View(pActividad);
        }
        [HttpPost]
        public ActionResult FinalizarTarea(ActividadBE pActividad)
        {
            try
            {
                HttpClient _httpClient = new HttpClient();
                var url = "http://localhost:54600/Api/Actividad/Marcar_Finalizada";

                using (var content = new StringContent(JsonConvert.SerializeObject(pActividad), System.Text.Encoding.UTF8, "application/json"))
                {
                    HttpResponseMessage result = _httpClient.PutAsync(url, content).Result;
                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                        return RedirectToAction("VerEnProceso");
                }

                //var vNuevaActividad = new ActividadBE();
                //dal.ActividadDAL dal = new dal.ActividadDAL();
                //dal.Marcar_Finalizada(pActividad);

                return RedirectToAction("VerEnProceso");
            }
            catch (Exception ex)
            {
                dal.ActividadDAL dal = new dal.ActividadDAL();
                var vLista = dal.Proceso_Listar(new ActividadBE());

                Response.Write(@"<script language='javascript'>alert('" + ex.Message + "');</script>");
                return View("Inicio", vLista);
            }
        }
        [HttpGet]
        public ActionResult VerEnProceso()
        {
            try
            {

                List<ActividadBE> vLista = new List<ActividadBE>();
                HttpClient _httpClient = new HttpClient();
                var url = "http://localhost:54600/Api/Actividad/Get_En_Proceso";

                using (var content = new StringContent(JsonConvert.SerializeObject(new ActividadBE()), System.Text.Encoding.UTF8, "application/json"))
                {
                    HttpResponseMessage result = _httpClient.GetAsync(url).Result;
                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string jSon = result.Content.ReadAsStringAsync().Result;
                        vLista = JsonConvert.DeserializeObject<List<ActividadBE>>(jSon);
                        return View(vLista);
                    }
                    else
                        return RedirectToAction("Inicio");
                }

                //dal.ActividadDAL dal = new dal.ActividadDAL();
                //var vLista = dal.Proceso_Listar(new ActividadBE());
                //return View(vLista);
            }
            catch (Exception ex)
            {
                Response.Write(@"<script language='javascript'>alert('" + ex.Message + "');</script>");
                return RedirectToAction("Inicio");
            }
        }
        public ActionResult EnProceso(ActividadBE pActividad)
        {
            try
            {
                HttpClient _httpClient = new HttpClient();
                var url = "http://localhost:54600/Api/Actividad/Marcar_En_Proceso";

                using (var content = new StringContent(JsonConvert.SerializeObject(pActividad), System.Text.Encoding.UTF8, "application/json"))
                {
                    HttpResponseMessage result = _httpClient.PutAsync(url, content).Result;
                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                        return RedirectToAction("Inicio");
                }

                //var vNuevaActividad = new ActividadBE();
                //dal.ActividadDAL dal = new dal.ActividadDAL();
                //dal.Marcar_En_Proceso(pActividad);

                return RedirectToAction("Inicio");
            }
            catch (Exception ex)
            {
                Response.Write(@"<script language='javascript'>alert('" + ex.Message + "');</script>");
                return View("VerEnProceso");
            }
        }

    }
}
